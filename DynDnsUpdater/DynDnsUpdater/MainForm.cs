/*
 * Erstellt mit SharpDevelop.
 * Benutzer: neurodeamon
 * Datum: 23.02.2012
 * Zeit: 00:51
 * 
 * CopyWare License (based on MIT license)
 * 
 * Copyright (c) 2012 neurodeamon
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense
 * and to permit persons to whom the Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 * It is NOT permitted to sell copies of the software and/or make any commercial use of it.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
 * NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES
 * OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 */
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace DynDnsUpdater
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		// Our secret cypher data (change before compiling!)
		const string passByteString = "133+5|>34|(";
		const string passWord = "|)`/|\\||)|\\|5|_||>|)4+3|2";
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// read our settings from xml file if available
			ReadFromXML();
			
			// lets get verbose & IP check
			textBox1.AppendText("Info: Starting up, need your public IP address.\r\n");
			textBox1.AppendText("Info: Getting IP.\r\n");
			string gmyIP = CheckIP("http://checkip.dyndns.com");
	        if (gmyIP != null) {
	        	textBox1.AppendText("Info: IP found.\r\n");
				lbl_ip.Text = gmyIP;
	        } else {
	        	textBox1.AppendText("Info: Error finding IP.\r\n");
				lbl_ip.Text = "Error: No internet?";
	        }
			
			// tray context menu init
			toolStripMenuItem1.Enabled = true;			
			toolStripMenuItem2.Enabled = false;
		}
		
		// we want the trackbar to display nice values in the UI when changing position
		public void TrackBar1Scroll(object sender, EventArgs e)
		{
			btn_save.Enabled = true;
			if (trackBar1.Value == 1) {
				lab_hour.Text = "hour";
			} else if (trackBar1.Value > 1) {
				lab_hour.Text = "hours";
			}
			lab_num.Text = trackBar1.Value.ToString();
			
		}
		
		public static string CheckIP(string strIPURL)
		{
		    // check the current public IP address
		    string ipString = string.Empty;
		    WebClient wc = new WebClient();
		    try
		    {
		    	string stringRegexIP = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";
		        string stringToSearch = wc.DownloadString(strIPURL);
				Regex ipMatch = new Regex(stringRegexIP,RegexOptions.IgnoreCase
                             			| RegexOptions.Multiline
                             			| RegexOptions.CultureInvariant
                             			| RegexOptions.IgnorePatternWhitespace);
		        string result = ipMatch.Match(stringToSearch).ToString();
		        return result;
		    }
		    catch (WebException)
		    {
		        string myException = null;
		        return myException;
		    }
		}
		
		public void UpdateDynDNS(string mUsername, string mPassword, string mDomain)
		{
			string ip = lbl_ip.Text.ToString();
			
			// DynDNS Update URL with placeholders (we're not using wildcard, mx and backmx ... for now)
			// and this application will only work with dyndns.org, but we'll see what the future brings ;-)
			string DYNDNSURL = "http://members.dyndns.org/nic/update?" +
			"hostname=" + mDomain +
			"&myip=" + ip +
			"&wildcard=NOCHG" +
			"&mx=NOCHG&backmx=NOCHG";

			// starting httpwebrequest
			Uri uri = new Uri(DYNDNSURL);
            HttpWebRequest wrq =  (HttpWebRequest)WebRequest.Create(uri);
            wrq.PreAuthenticate = true;
            // faking a browser
            wrq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:11.0) Gecko/20100101 Firefox/11.0";
            wrq.Headers.Add("Accept-Language", "en-US");
            wrq.Method = "GET";
            // forced authentication, sadly we need this because c# otherwise fails to auth
            SetBasicAuthHeader(wrq,textbox_username.Text.ToString(),textbox_password.Text.ToString());
			
            // now lets try to connect and read the server response
			try {
	            WebResponse wrs = wrq.GetResponse();
	            Stream strm = wrs.GetResponseStream();
	            StreamReader sr = new StreamReader(strm);
	            string line = "";
	            string response = "";
	            while( (line = sr.ReadLine() ) != null)
	            {
	            	// Debug.WriteLine(line);
	            	response += line;
	            }				
                
	            /*
 					splitting response (usually response code and ip address that has been passed)
 					we just want the response code which we will expand to full explanation)
	            */
	            string[] SplitResult = response.Split(' ');
	            
	            switch (SplitResult[0])
				{
				case "good":
	            textBox1.AppendText("DynDNS Response: IP updated to: " + SplitResult[1] + "\r\n");
				break;
				case "nochg":
				textBox1.AppendText("DynDNS Response: The update changed no settings, and is considered abusive.\r\nAdditional nochg updates will cause the hostname to become blocked.\r\n");
				break;
				case "badsys":
				textBox1.AppendText("DynDNS Response: The system parameter given is not valid. Valid system parameters are dyndns, statdns and custom\r\n");
				break;
				case "badagent":
				textBox1.AppendText("DynDNS Response: The user agent that was sent has been blocked for not following these specifications or no user agent was specified\r\n");
				break;
				case "badauth":
				textBox1.AppendText("DynDNS Response: The username or password specified are incorrect\r\n");
				break;
				case "!donator":
				textBox1.AppendText("DynDNS Response: An option available only to credited users (such as offline URL) was specified, but the user is not a credited user.\r\n");
				break;
				case "notfqdn":
				textBox1.AppendText("DynDNS Response: The hostname specified is not a fully-qualified domain name (not in the form hostname.dyndns.org or domain.com)\r\n");
				break;
				case "nohost":
				textBox1.AppendText("DynDNS Response: The hostname specified does not exist (or is not in the service specified in the system parameter)\r\n");
				break;
				case "!yours":
				textBox1.AppendText("DynDNS Response: The hostname specified exists, but not under the username specified\r\n");
				break;
				case "abuse":
				textBox1.AppendText("DynDNS Response: The hostname specified is blocked for update abuse\r\n");
				break;
				case "numhost":
				textBox1.AppendText("DynDNS Response: Too many or too few hosts found\r\n");
				break;
				case "dnserr":
				textBox1.AppendText("DynDNS Response: DNS error encountered\r\n");
				break;
				case "911":
				textBox1.AppendText("DynDNS Response: There is a serious problem on DynDNS side, such as a database or DNS server failure. The client should stop updating until notified via the status page that the service is back up.\r\n");
				// here deactivate update function
				break;
				default:
				textBox1.AppendText("DynDNS Response: Unknown result from dyndns service\r\n");
				break;
				}
			} catch (WebException e) {
            	// if something went wrong, output debug information
            	bool theError = e.Message.Contains("403");
				Debug.WriteLine(e);
				if (theError) {
					textBox1.AppendText("DynDNS Response: 403 Forbidden.\r\n");
				}
				textBox1.AppendText("Exception: Check configuration.\r\n");
				btn_go.Enabled = true;
				btn_stop.Enabled = false;
				timer_stdout.Enabled = false;
				textBox1.AppendText("Aborted service to prevent flooding.\r\n");
            }
		}
		
		// lets save our settings to a xml file (and encrypt the password before saving!)
		public void SaveToXML()
		{
			byte[] passByte = System.Text.Encoding.UTF8.GetBytes(passByteString);
			string encPassWord = EC_Rijndael.Encrypt(textbox_password.Text,passWord,passByte);
			
			string strBasename = System.IO.Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName);
			string configFilename = strBasename +".xml";
			// we create an empty datatable
			DataTable dt_config = new DataTable("config");
			// add the columns
			dt_config.Columns.Add("DynDNS_username");
			dt_config.Columns.Add("DynDNS_password");
			dt_config.Columns.Add("DynDNS_alias");
			dt_config.Columns.Add("DynDNS_interval");
			// and fill some rows with data
			DataRow dr_config = dt_config.NewRow();
			dr_config["DynDNS_username"]		= textbox_username.Text.ToString();
			dr_config["DynDNS_password"]	= encPassWord.ToString();
			dr_config["DynDNS_alias"]	= textbox_alias.Text.ToString();
			dr_config["DynDNS_interval"]	= trackBar1.Value.ToString();
			// put the rows into the datatable
			dt_config.Rows.Add(dr_config);
			// and save the data into an xml file
			dt_config.WriteXml(configFilename, XmlWriteMode.WriteSchema);
		}
		
		// read our settings from xml file (and decrypt the password which we will send to dyndns.org)
		public void ReadFromXML()
		{
			string strBasename = System.IO.Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName);
			string configFilename = strBasename +".xml";
			
			if (File.Exists(configFilename)) {
				// create the datatable
				DataTable dt_config = new DataTable("config");
				// read the file into the datatable (which magically does not need complex code - YAY!)
				dt_config.ReadXml(configFilename);
				// Fill the data to the datarow
				DataRow dr_config = dt_config.Rows[0];
				// let's pass the data to our UI
				byte[] passByte = System.Text.Encoding.UTF8.GetBytes(passByteString);
				string test = dr_config["DynDNS_password"].ToString();
				string decPassWord = EC_Rijndael.Decrypt(test,passWord,passByte);
				textbox_username.Text		= dr_config["DynDNS_username"].ToString();
				textbox_password.Text		= decPassWord;
				textbox_alias.Text			= dr_config["DynDNS_alias"].ToString();
				trackBar1.Value				= Convert.ToInt32(dr_config["DynDNS_interval"]);
			} else {
				// if we have no config file use these default values
				textbox_username.Text		= "";
				textbox_password.Text		= "";
				textbox_alias.Text			= "";
				trackBar1.Value				= 1;
			}
			
			// plural / singular handling of the trackbar label
			if (trackBar1.Value == 1) {
				lab_hour.Text = "hour";
			} else if (trackBar1.Value > 1) {
				lab_hour.Text = "hours";
			}
			
			// get the trackbar value, convert it to milliseconds and set timer interval
			lab_num.Text = trackBar1.Value.ToString();
			double Dtimespan = TimeSpan.FromHours(Convert.ToDouble(trackBar1.Value)).TotalMilliseconds;
			timer_stdout.Interval = Convert.ToInt32(Dtimespan);
			btn_save.Enabled = false;
		}
		// workaround (see description above)
		public void SetBasicAuthHeader(WebRequest req, String userName, String userPassword)
		{
		    string authInfo = userName + ":" + userPassword;
		    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
		    req.Headers["Authorization"] = "Basic " + authInfo;
		}
		// encode/decode MIME(BASE64) Strings
		private static string EDCode(string Text, bool Encode)
		{
			return (Encode) ? Convert.ToBase64String(UTF8Encoding.Unicode.GetBytes(Text)) : UTF8Encoding.Unicode.GetString(Convert.FromBase64String(Text));
		}
		
		// execute the update code through timer
		public void Timer_stdoutTick(object sender, EventArgs e)
		{
			UpdateDynDNS(textbox_username.Text.ToString(),textbox_password.Text.ToString(),textbox_alias.Text.ToString());
		}
		
		void Textbox_usernameTextChanged(object sender, EventArgs e)
		{
			btn_save.Enabled = true;
		}
		
		void Textbox_passwordTextChanged(object sender, EventArgs e)
		{
			btn_save.Enabled = true;
		}
		
		void Textbox_aliasTextChanged(object sender, EventArgs e)
		{
			btn_save.Enabled = true;
		}
		
		// save when clicking button
		void Btn_saveClick(object sender, EventArgs e)
		{
			SaveToXML();
			textBox1.AppendText("Info: Data saved to configuration file.\r\n");
			btn_save.Enabled = false;
		}

		// start update timer
		public void Btn_startClick(object sender, EventArgs e)
		{
			btn_go.Enabled = false;
			btn_stop.Enabled = true;
			timer_stdout.Enabled = true;
			UpdateDynDNS(textbox_username.Text.ToString(),textbox_password.Text.ToString(),textbox_alias.Text.ToString());
		}

		// stop update timer
		void Btn_stopClick(object sender, EventArgs e)
		{
			btn_go.Enabled = true;
			btn_stop.Enabled = false;
			timer_stdout.Enabled = false;
        }

		// catch the window state and set option availibility accordingly in the trayicon context menu
        private void ResizeEvent(object sender, EventArgs e)
        {
            if (this.WindowState.ToString() == "Minimized")
            {
			    toolStripMenuItem1.Enabled = false;			
			    toolStripMenuItem2.Enabled = true;
            }
            else if (this.WindowState.ToString() == "Normal")
            {
			    toolStripMenuItem1.Enabled = true;			
			    toolStripMenuItem2.Enabled = false;
            }
        }
	}
}

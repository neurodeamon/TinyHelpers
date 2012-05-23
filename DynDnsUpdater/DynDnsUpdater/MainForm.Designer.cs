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
namespace DynDnsUpdater
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
			notifyIcon1.Dispose();
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_go = new System.Windows.Forms.Button();
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.textbox_alias = new System.Windows.Forms.TextBox();
            this.lab_username = new System.Windows.Forms.Label();
            this.lab_password = new System.Windows.Forms.Label();
            this.lab_alias = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_num = new System.Windows.Forms.Label();
            this.lab_hour = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.timer_stdout = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.btn_stop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_go
            // 
            this.btn_go.CausesValidation = false;
            this.btn_go.Location = new System.Drawing.Point(273, 112);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(75, 40);
            this.btn_go.TabIndex = 6;
            this.btn_go.Text = "GO";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.Btn_startClick);
            // 
            // textbox_username
            // 
            this.textbox_username.Location = new System.Drawing.Point(20, 31);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(162, 20);
            this.textbox_username.TabIndex = 1;
            this.textbox_username.TextChanged += new System.EventHandler(this.Textbox_usernameTextChanged);
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(20, 58);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(162, 20);
            this.textbox_password.TabIndex = 2;
            this.textbox_password.UseSystemPasswordChar = true;
            this.textbox_password.TextChanged += new System.EventHandler(this.Textbox_passwordTextChanged);
            // 
            // textbox_alias
            // 
            this.textbox_alias.Location = new System.Drawing.Point(20, 85);
            this.textbox_alias.Name = "textbox_alias";
            this.textbox_alias.Size = new System.Drawing.Size(162, 20);
            this.textbox_alias.TabIndex = 3;
            this.textbox_alias.TextChanged += new System.EventHandler(this.Textbox_aliasTextChanged);
            // 
            // lab_username
            // 
            this.lab_username.Location = new System.Drawing.Point(188, 31);
            this.lab_username.Name = "lab_username";
            this.lab_username.Size = new System.Drawing.Size(58, 20);
            this.lab_username.TabIndex = 4;
            this.lab_username.Text = "Username";
            this.lab_username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_password
            // 
            this.lab_password.Location = new System.Drawing.Point(188, 58);
            this.lab_password.Name = "lab_password";
            this.lab_password.Size = new System.Drawing.Size(58, 20);
            this.lab_password.TabIndex = 5;
            this.lab_password.Text = "Password";
            this.lab_password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_alias
            // 
            this.lab_alias.Location = new System.Drawing.Point(188, 85);
            this.lab_alias.Name = "lab_alias";
            this.lab_alias.Size = new System.Drawing.Size(58, 20);
            this.lab_alias.TabIndex = 6;
            this.lab_alias.Text = "Hostname";
            this.lab_alias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(19, 134);
            this.trackBar1.Maximum = 24;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(162, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Update interval:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_num
            // 
            this.lab_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lab_num.Location = new System.Drawing.Point(173, 136);
            this.lab_num.Name = "lab_num";
            this.lab_num.Size = new System.Drawing.Size(25, 23);
            this.lab_num.TabIndex = 9;
            this.lab_num.Text = "1";
            this.lab_num.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_hour
            // 
            this.lab_hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab_hour.Location = new System.Drawing.Point(194, 136);
            this.lab_hour.Name = "lab_hour";
            this.lab_hour.Size = new System.Drawing.Size(44, 23);
            this.lab_hour.TabIndex = 10;
            this.lab_hour.Text = "hour";
            this.lab_hour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_hour);
            this.groupBox1.Controls.Add(this.lab_num);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 190);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btn_save
            // 
            this.btn_save.CausesValidation = false;
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(273, 21);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 77);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "SAVE DATA";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
            // 
            // timer_stdout
            // 
            this.timer_stdout.Interval = 86400000;
            this.timer_stdout.Tick += new System.EventHandler(this.Timer_stdoutTick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Your IP:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ip
            // 
            this.lbl_ip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_ip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_ip.Location = new System.Drawing.Point(107, 204);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(241, 31);
            this.lbl_ip.TabIndex = 15;
            this.lbl_ip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_stop
            // 
            this.btn_stop.CausesValidation = false;
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(273, 157);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 40);
            this.btn_stop.TabIndex = 7;
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.Btn_stopClick);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.CausesValidation = false;
            this.textBox1.Location = new System.Drawing.Point(8, 244);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(340, 186);
            this.textBox1.TabIndex = 17;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem1.Text = "&Minimize";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem2.Text = "&Restore";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem3.Text = "&Quit";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 438);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lab_alias);
            this.Controls.Add(this.lab_password);
            this.Controls.Add(this.lab_username);
            this.Controls.Add(this.textbox_alias);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_username);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DynDnsUpdater";
            this.Resize += new System.EventHandler(this.ResizeEvent);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btn_stop;
		private System.Windows.Forms.Label lbl_ip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer_stdout;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textbox_username;
		private System.Windows.Forms.TextBox textbox_password;
		private System.Windows.Forms.TextBox textbox_alias;
		private System.Windows.Forms.Label lab_username;
		private System.Windows.Forms.Label lab_password;
		private System.Windows.Forms.Label lab_alias;
		private System.Windows.Forms.Label lab_hour;
		private System.Windows.Forms.Label lab_num;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button btn_go;
		
		void ToolStripMenuItem1Click(object sender, System.EventArgs e)
		{
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			toolStripMenuItem1.Enabled = false;
			toolStripMenuItem2.Enabled = true;
		}
		
		void ToolStripMenuItem2Click(object sender, System.EventArgs e)
		{
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			toolStripMenuItem1.Enabled = true;			
			toolStripMenuItem2.Enabled = false;
		}
		
		void ToolStripMenuItem3Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Application.Exit();
		}
	}
}

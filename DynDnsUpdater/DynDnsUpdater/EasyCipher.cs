/*
 * Erstellt mit SharpDevelop.
 * Benutzer: neurodeamon
 * Datum: 23.02.2012
 * Zeit: 00:51
 * 
 * 
 * This class was found on http://coderbuddy.wordpress.com
 * There's no license information to be found. I have no idea where it came originally from.
 * Maybe I'll change this portion with other code.
 * 
 */
using System;
using System.IO;
using System.Net;
using System.Text;
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
	/// Description of EasyCipher.
	/// </summary>
public class EC_Rijndael
    {

        #region Encryption Stuff goes here

        /// <summary>
        /// Encrypts a given string using Rijndael algorithm, salted
        /// </summary>
        /// <param name="plain_text">The string you want to encrypt</param>
        /// <param name="password">Password used for encryption</param>
        ///<returns></returns>
        public static string Encrypt(string clearText, string Password)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            //Don't worry about the string "~t)o!o(s@a*l#t&y", you can replace it with your own string, it is better to make it unpredictable
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, Encoding.ASCII.GetBytes("~t)o!o(s@a*l#t&y"));
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// Encrypts a given string using Rijndael algorithm
        /// </summary>
        /// <param name="plain_text">The string you want to encrypt</param>
        /// <param name="password">Password used for encryption</param>
        /// <param name="salt">Salt value in bytes to stop dictionary attack, remember the same salt value must be used to decryption</param>
        ///<returns></returns>
        public static string Encrypt(string plain_text, string password, byte[] saltvalue)
        {
            byte[] plain_bytes = System.Text.Encoding.Unicode.GetBytes(plain_text);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, saltvalue);
            byte[] encrypted_data = Encrypt(plain_bytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encrypted_data);
        }

        /// <summary>
        /// Encrypts a byte array, instead of string
        /// </summary>
        /// <param name="plain_bytes">byte array to be encrypted</param>
        /// <param name="password">password for encryption</param>
        /// <param name="saltvalue">Salt value is any byte array that is attached to a password to stop dictionary attack</param>
        /// <returns>Encrypted byte array</returns>
        public static byte[] Encrypt(byte[] plain_bytes, string password, byte[] saltvalue)
        {
            PasswordDeriveBytes pwd = new PasswordDeriveBytes(password, saltvalue);
            byte[] encryptedData = Encrypt(plain_bytes, pwd.GetBytes(32), pwd.GetBytes(16));
            return encryptedData;
        }

        /// <summary>
        /// Encrypts a byte array, instead of string, salted
        /// </summary>
        /// <param name="plain_bytes">byte array to be encrypted</param>
        /// <param name="password">password for encryption</param>
        /// <returns>Encrypted byte array</returns>
        public static byte[] Encrypt(byte[] clearBytes, string Password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return encryptedData;
        }

        #endregion

        #region Decryption Stuff Goes here

        /// <summary>
        /// Decyphers an encrypted string, salted
        /// </summary>
        /// <param name="cipher_text">Encrytped string to be deciphered</param>
        /// <param name="password">password used for encrypting string</param>
        /// <returns>Plain deciphered string</returns>
        public static string Decrypt(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            //Don't worry about the string "~t)o!o(s@a*l#t&y", you can replace it with your own string, it is better to make it unpredictable
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, Encoding.ASCII.GetBytes("~t)o!o(s@a*l#t&y"));
            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        /// <summary>
        /// Decyphers an encrypted string
        /// </summary>
        /// <param name="cipher_text">Encrytped string to be deciphered</param>
        /// <param name="password">password used for encrypting string</param>
        /// <param name="saltvalue">Salt value is any byte array that is attached to a password to stop dictionary attack</param>
        /// <returns>Plain deciphered string</returns>
        public static string Decrypt(string cipher_text, string password, byte[] saltvalue)
        {
            byte[] cipher_bytes = Convert.FromBase64String(cipher_text);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, saltvalue);
            byte[] decrypted_data = Decrypt(cipher_bytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(decrypted_data);
        }

        /// <summary>
        /// Decyphers an encrypted byte array, salted
        /// </summary>
        /// <param name="cipher_bytes">Encrytped byte array to be deciphered</param>
        /// <param name="password">Salt value is any byte array that is attached to a password to stop dictionary attack</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] cipherBytes, string Password)
        {
            //Don't worry about the string "~t)o!o(s@a*l#t&y", you can replace it with your own string, it is better to make it unpredictable
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, Encoding.ASCII.GetBytes("~t)o!o(s@a*l#t&y"));
            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return decryptedData;
        }

        /// <summary>
        /// Decyphers an encrypted byte array
        /// </summary>
        /// <param name="cipher_bytes">Encrytped byte array to be deciphered</param>
        /// <param name="password">Salt value is any byte array that is attached to a password to stop dictionary attack</param>
        /// <param name="saltvalue">Plain deciphered byte array</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] cipher_bytes, string password, byte[] saltvalue)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, saltvalue);
            byte[] decrypted_data = Decrypt(cipher_bytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return decrypted_data;
        }

        #endregion

        #region Private Encryption Methods

        private static byte[] Encrypt(byte[] plain_bytes, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(plain_bytes, 0, plain_bytes.Length);
            cs.Close();
            byte[] encrypted_data = ms.ToArray();
            return encrypted_data;
        }

        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decrypted_data = ms.ToArray();
            return decrypted_data;
        }

        #endregion

    }
}

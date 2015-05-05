using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;

namespace PFSHelper.DataAccessLayer
{
    public abstract class PFSDataBaseAccess
    {
        #region Variable

        private static string m_sConnString = string.Empty;

        #endregion

        #region Property

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(m_sConnString))
                {
                    m_sConnString = ConfigurationManager.AppSettings.Get("ConnectionString");

                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("AppId")))
                    {
                        DecryptConnection(ConfigurationManager.AppSettings.Get("AppId"), m_sConnString, out m_sConnString);
                    }

                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("ConnectionTimeout")))
                    {
                        if (m_sConnString.Substring(m_sConnString.Length - 1, 1) != ";")
                        {
                            m_sConnString += ";";
                        }

                        m_sConnString += string.Format("Connection Timeout={0}", ConfigurationManager.AppSettings.Get("ConnectionTimeout"));
                    } 
                }

                return m_sConnString;
            }
        } 
        #endregion

        #region Method

        public static SqlConnection OpenConnection()
        {
            try
            {
                SqlConnection oConn = new SqlConnection(PFSDataBaseAccess.ConnectionString);
                if (oConn.State != System.Data.ConnectionState.Open)
                {
                    oConn.Open();
                }

                return oConn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CloseConnection(ref SqlConnection p_oConn)
        {
            if (p_oConn.State == ConnectionState.Open) p_oConn.Close();
        }

        static bool DecryptConnection(
            string p_sKey,
            string p_sContent,
            out string p_sOutput)
        {
            p_sOutput = string.Empty;

            try
            {
                using (AesManaged oAesManaged = new AesManaged())
                {
                    // Set Salt
                    byte[] bytSalt = new byte[8];
                    //PasswordDeriveBytes pdbSecretKey = new PasswordDeriveBytes(p_sKey, bytSalt);
                    Rfc2898DeriveBytes rdbSecretKey = new Rfc2898DeriveBytes(p_sKey, bytSalt);

                    oAesManaged.BlockSize = 128;
                    oAesManaged.KeySize = 256;

                    oAesManaged.Key = rdbSecretKey.GetBytes(oAesManaged.KeySize / 8);
                    oAesManaged.IV = rdbSecretKey.GetBytes(oAesManaged.BlockSize / 8);

                    // Decrypt the bytes to a string.
                    byte[] bytsDecryptedData = Convert.FromBase64String(p_sContent);
                    p_sOutput = DecryptStringFromBytes_Aes(bytsDecryptedData, oAesManaged.Key, oAesManaged.IV);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        static string DecryptStringFromBytes_Aes(
            byte[] p_bytContent,
            byte[] p_bytKey,
            byte[] p_ivIV)
        {
            // Check arguments. 
            if (p_bytContent == null || p_bytContent.Length <= 0)
                throw new ArgumentNullException("p_bytContent");
            if (p_bytKey == null || p_bytKey.Length <= 0)
                throw new ArgumentNullException("p_bytKey");
            if (p_ivIV == null || p_ivIV.Length <= 0)
                throw new ArgumentNullException("p_bytKey");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an Aes object 
            // with the specified key and p_ivIV. 
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = p_bytKey;
                aesAlg.IV = p_ivIV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(p_bytContent))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        } 
        #endregion
    }
}
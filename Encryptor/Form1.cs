using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace Encryptor
{
    public partial class Form1 : Form
    {
        List<Task> tasks = new List<Task>();

        //  Call this function to remove the key from memory after use for security
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Encrypt
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPath.Text)) MessageBox.Show("No path found");
            else if (String.IsNullOrEmpty(textBoxPassword.Text)) MessageBox.Show("Use a password");
            else
            {
                string password = textBoxPassword.Text;
                string path = textBoxPath.Text;
                
                int count = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                //InitBar(count);

                // For additional security Pin the password of your files
                GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

                //string[] allfiles = Directory.GetFiles("path/to/dir", "*.*", SearchOption.AllDirectories);

                // For each files in folder encrypt it
                foreach (string file in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
                {
                    if (file.EndsWith("aes")) continue;
                    //MessageBox.Show(file);
                    // Encrypt the file   
                    Task tmp = new Task(() =>
                    {
                        FileEncrypt(file, password);                        
                    });
                    tasks.Add(tmp);
                    tmp.Start();                  
                }
                Task.WaitAll(tasks.ToArray());                
                MessageBox.Show("ENCRYPT COMPLETE!");
                               
                // To increase the security of the encryption, delete the given password from the memory !
                ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                gch.Free();
            }
        }

        //Decrypt
        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPath.Text)) MessageBox.Show("No path found");
            else if (String.IsNullOrEmpty(textBoxPassword.Text)) MessageBox.Show("Use a password");
            else
            {
                string password = textBoxPassword.Text;
                string path = textBoxPath.Text;
                
                // For additional security Pin the password of your files
                GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

                //string[] allfiles = Directory.GetFiles("path/to/dir", "*.*", SearchOption.AllDirectories);

                // For each files in folder encrypt it
                foreach (string file in Directory.GetFiles(path, "*.aes", SearchOption.AllDirectories))
                {
                    //MessageBox.Show(file);
                    // Encrypt the file                    
                    Task tmp = new Task(() =>
                    {
                        FileDecrypt(file, password);
                        //pBar1.PerformStep();
                    });
                    tasks.Add(tmp);
                    tmp.Start();
                    //pBar1.PerformStep();
                    //FileDecrypt(file, password);
                    //pBar1.PerformStep();

                    //int percent = (int)(((double)pBar1.Value / (double)pBar1.Maximum) * 100);
                    //pBar1.Refresh();
                    //pBar1.CreateGraphics().DrawString(percent.ToString() + "%",
                    //    new Font("Arial", (float)8.25, FontStyle.Regular),
                    //    Brushes.Black,
                    //    new PointF(pBar1.Width / 2 - 10, pBar1.Height / 2 - 7));
                }
                Task.WaitAll(tasks.ToArray());                
                MessageBox.Show("DECRYPT COMPLETE!");

                // To increase the security of the encryption, delete the given password from the memory !
                ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                gch.Free();
            }
        }
        
        //private void InitBar(int number)
        //{
        //    // Display the ProgressBar control.
        //    //pBar1.Visible = true;
        //    // Set Minimum to 1 to represent the first file being copied.
        //    pBar1.Minimum = 1;
        //    // Set Maximum to the total number of files to copy.
        //    pBar1.Maximum = number;
        //    // Set the initial value of the ProgressBar.
        //    pBar1.Value = pBar1.Minimum;
        //    // Set the Step property to a value of 1 to represent each file being copied.
        //    pBar1.Step = 1;            
        //}

        public void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ChooseFolder();
        }
        
        /// <summary>
        /// Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }

            return data;
        }        

        private void FileEncrypt(string inputFile, string password)
        {
            //http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files

            //generate random salt
            byte[] salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            //Set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            //http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
            //"What it does is repeatedly hash the user password along with the salt." High iteration counts.
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            //Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
            AES.Mode = CipherMode.CFB;

            // write salt to the begining of the output file, so in this case can be random every time
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents(); // -> for responsive GUI, using Task will be better!
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();

                if (radioButtonRemove.Checked)
                {
                    DeletePermanently(inputFile);
                }
                //MessageBox.Show(scolor);
            }
        }        

        private void FileDecrypt(string inputFile, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(inputFile.Substring(0, inputFile.Length - 3), FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {                               
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }
                
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);                
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {                
                fsOut.Close();
                fsCrypt.Close();
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();

                if (radioButtonRemove.Checked)
                {
                    DeletePermanently(inputFile);
                }
            }
        }

        private bool IsPasswordCorrect(string inputFile, string password, CryptoStream cs)
        {       
            //TODO
            byte[] buffer = new byte[1048576];
            int read = cs.Read(buffer, 0, buffer.Length);
            if (read == 0)
            {
                //fsCrypt.Close();
                //cs.Close();
                return false;
            }
            else
            {
                //fsCrypt.Close();
                //cs.Close();
                return true;
            }
        }

        private void DeletePermanently(string path)
        {
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                
                cmd.StandardInput.WriteLine("sdelete -p 7 \"" + path + "\"");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                string output = cmd.StandardOutput.ReadToEnd();                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }

        private void textBoxPath_Click(object sender, EventArgs e)
        {
            textBoxPath.SelectAll();
        }
    }
}

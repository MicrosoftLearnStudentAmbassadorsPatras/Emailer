using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;
using System.Net.Mail;
using System.Net;
 
namespace Mailer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   
        private void zip()
        {
 
            ZipFile zip = new ZipFile();
                {
                    String[] filenames = System.IO.Directory.GetFileSystemEntries(Directory.GetCurrentDirectory());
                    progressBar1.Maximum = filenames.Length-2;
               
                    foreach (String filename in filenames)
                    {
 
 
                       
 
                        if (filename.Contains("Mailer") || (filename.Contains("Ionic")))
                            continue;
                        progressBar1.Value++;
                        progressBar1.Update();
 
                        listBox1.Items.Add(filename.ToString());
                        ZipEntry e= zip.AddFile(filename,"");
                    }
 
                    zip.Save("Mailer.zip");
                }
        }
        private void send()
        {
         
                MailMessage message = new MailMessage("ecexxxx@upnet.gr","paraliptis@something.com");
                Attachment data = new Attachment("Mailer.zip");
                message.Attachments.Add(data);
                SmtpClient client = new SmtpClient("patreas.upatras.gr");
                client.Credentials = CredentialCache.DefaultNetworkCredentials;
               
                client.Send(message);
 
               
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            progressBar1.Value = 0;
            zip();
            send();
            MessageBox.Show("Message Sent Succesfully");
        }
    }
}
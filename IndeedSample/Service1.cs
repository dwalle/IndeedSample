using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace IndeedSample {
    public partial class Service1 : ServiceBase {

        System.Timers.Timer serviceTimer;
        public Service1() {
            InitializeComponent();
        }

        public void OnDebug() {
            OnStart(null);
        }

        protected override void OnStart(string[] args) {
            //Here we are setting up our timer so we can auto send the email at a time interval (Specified in the 'SimpleParams' class file)
            serviceTimer = new System.Timers.Timer();
            serviceTimer.Elapsed += new System.Timers.ElapsedEventHandler(SendMail);
            serviceTimer.Interval = SimpleParams.time_interval_in_ms;
            serviceTimer.Enabled = true;
            serviceTimer.AutoReset = true;
            serviceTimer.Start();
        }

        public void SendMail(object sender, System.Timers.ElapsedEventArgs args) {
            //Here we are setting up our SMTP client with the credentials Specified in the 'SimpleParams' class file
            SmtpClient client = new SmtpClient(SimpleParams.SMTP_server, SimpleParams.SMTP_port);
            client.UseDefaultCredentials = false;//Remove any default credentials before we assign our specified credentials
            NetworkCredential cred = CreateCredentials();
            client.Credentials = cred;
            client.EnableSsl = true;//SSL will make sure our connection is secure
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//And we will require the internet
            try {
                DateTime nowTime = DateTime.Now;
                MailMessage msg = CreateMessage(nowTime);
                client.Send(msg);
                msg.Dispose();
                client.Dispose();
            } catch (System.Net.Mail.SmtpException ex) {
                //We only display the error message in debug mode
#if DEBUG
                Console.WriteLine(ex.ToString());
#endif
            } catch (Exception ex) {
                //We only display the error message in debug mode
#if DEBUG
                Console.WriteLine(ex.ToString());
#endif
            }
        }

        private NetworkCredential CreateCredentials() {
            return new NetworkCredential(SimpleParams.SMTP_Login, SimpleParams.SMTP_password);
        }

        private MailMessage CreateMessage(DateTime _nowTime) {
            MailMessage msg = new MailMessage();
            msg.To.Add(SimpleParams.EmailAddress);
            
            msg.Subject = "Indeed Sample " + _nowTime;

            msg.Body = SimpleParams.msg_body;
            msg.From = new MailAddress(SimpleParams.SMTP_Login);
            return msg;
        }
    }
}

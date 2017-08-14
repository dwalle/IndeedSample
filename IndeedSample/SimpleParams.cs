using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndeedSample {
    class SimpleParams {

        public static String SMTP_server = "smtp.mail.yahoo.com";//or you can use: "smtp.gmail.com"
        public static int SMTP_port = 587;
        public static String SMTP_Login = "your_email@host.com";
        public static String SMTP_password = "your_password";
        public static String EmailAddress = "to_email@host.com";

        public static String msg_body = "This is a sample";

        public static int time_interval_in_ms = 300000;//1 second == 1000 ms. 1 min(60 seconds) == 60000 ms. 5 min == 300000

    }
}

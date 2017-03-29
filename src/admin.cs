using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Properties;
using Network;
using UserControl;
using AuditRecord;
using Authentication;

namespace Administration {

    class AdminList { 

        public static void AddUser(string requestUser, Admin authProps) {

            authProps.Users.Add(requestUser);

        }

    }

}
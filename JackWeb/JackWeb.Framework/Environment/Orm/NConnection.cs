using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackWeb.Framework.Environment.Orm
{
    public class NConnection
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }

        public bool IsTesting { get; set; }

        public string Database { get; set; }

        public bool TrustedConnection { get; set; }
    }
}

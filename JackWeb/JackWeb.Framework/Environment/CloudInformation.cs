using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackWeb.Framework.Environment
{
    public partial class CloudInformation
    {
        public const string DEFAULT_DATABASE_CONNECTION_STRING_AZURE = "Server=tcp:gri1o5h8zq.database.windows.net,1433;Database=JackStore;User ID=jck@gri1o5h8zq;Password={your_password_here};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
        
        public CloudInformation()
        {
            InitialDatabaseConnectionString = DEFAULT_DATABASE_CONNECTION_STRING_AZURE;
        }

        public string InitialDatabaseConnectionString 
        {
            get; 
            set; 
        }
    }
}

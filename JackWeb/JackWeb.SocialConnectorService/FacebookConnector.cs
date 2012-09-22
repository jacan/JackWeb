using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace JackWeb.SocialConnectorService
{
    public class FacebookConnector : ISocialAuthenticate
    {

        public bool IsAuthenticated
        {
            get;
            set;
        }

        public void Authenticate()
        {
            throw new NotImplementedException();
        }
    }
}

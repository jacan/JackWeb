using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackWeb.SocialConnectorService
{
    public interface ISocialAuthenticate
    {
        bool IsAuthenticated { get; set; }
        
        void Authenticate();
    }
}

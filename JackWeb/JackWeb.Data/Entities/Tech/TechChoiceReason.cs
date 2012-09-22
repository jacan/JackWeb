using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackWeb.Data.Entities.Tech
{
    public class TechChoiceReason : IEntityStandardDefinition
    {
        public int Id
        {
            get;
            set;

        }

        public DateTime Created
        {
            get;
            set;
        }

        public DateTime Modified
        {
            get;
            set;
        }

        public DateTime Deleted
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Reason
        {
            get;
            set;
        }
    }
}

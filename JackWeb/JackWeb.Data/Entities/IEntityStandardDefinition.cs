using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackWeb.Data.Entities
{
    public interface IEntityStandardDefinition
    {
        int Id { get; set; }

        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        DateTime Deleted { get; set; }

        bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Interfaces
{
    public interface IntModel : MartenInterface<int>
    {
        public new int Id { get; set; }
    }
}

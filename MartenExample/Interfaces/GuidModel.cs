using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Interfaces
{
    public interface GuidModel: MartenInterface<Guid>
    {
        public new Guid Id { get; set; }
    }
}

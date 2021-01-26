using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Interfaces
{
    public interface MartenInterface<T>
    {
        public T Id { get; set; }
    }
}

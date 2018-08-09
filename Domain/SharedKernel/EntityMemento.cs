using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel
{
    public abstract class EntityMemento
    {
        public DateTimeOffset LastModified { get; set; }
    }
}

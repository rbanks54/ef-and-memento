using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel
{
    public interface IEntityMemento
    {
        public DateTimeOffset LastModified {get; init;}
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel
{
    interface IAggregateRoot
    {
    }

    public interface IHaveState<S>
    where S : IEntityMemento
    {
        S State { get; }
    }
}

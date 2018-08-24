using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mementos
{
    public sealed class BusRouteMemento : EntityMemento
    {
        public int Id { get; private set;  }
        internal BusRouteMemento(int id)
        {
            Id = id;
        }
    }
}

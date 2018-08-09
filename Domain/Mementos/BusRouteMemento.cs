using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mementos
{
    public sealed class BusRouteMemento : EntityMemento
    {
        public int Id { get; private set;  }
        public string Name { get; private set; }
        public BusRouteMemento(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

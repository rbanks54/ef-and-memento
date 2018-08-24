using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mementos
{
    //I wish C# 8.0 record types were already available...
    public sealed class BusMemento : EntityMemento
    {
        public Guid Id { get; private set; }
        public string BusNumber { get; private set; }
        public int SeatedCapacity { get; private set; }
        public int StandingCapacity { get; private set; }

        internal BusMemento(Guid id, string busNumber, int seatedCapacity, int standingCapacity)
        {
            Id = id;
            BusNumber = busNumber;
            SeatedCapacity = seatedCapacity;
            StandingCapacity = standingCapacity;
        }
    }
}

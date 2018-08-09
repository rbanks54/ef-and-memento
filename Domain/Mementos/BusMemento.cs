using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mementos
{
    //I wish C# 8.0 record types were already available...
    public sealed class BusMemento : EntityMemento
    {
        public Guid Id { get; }
        public string BusNumber { get; }
        public int SeatedCapacity { get; }
        public int StandingCapacity { get; }

        public BusMemento(Guid id, string busNumber, int seatedCapacity, int standingCapacity)
        {
            Id = id;
            BusNumber = busNumber;
            SeatedCapacity = seatedCapacity;
            StandingCapacity = standingCapacity;
        }
    }
}

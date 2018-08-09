using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Bus : IAggregateRoot
    {
        public BusId Id { get; }
        public string BusNumber { get; }
        public int SeatedCapacity { get; }
        public int StandingCapacity { get; }
    }

    public class BusId : Identity<Guid>
    {
        public BusId(Guid id) : base(id) { }
    }
}

using Domain.Mementos;
using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Bus : IAggregateRoot, IHaveState<BusMemento>
    {
        public BusId Id { get; }
        public string BusNumber { get; }
        public int SeatedCapacity { get; }
        public int StandingCapacity { get; }

        public Bus(BusId id, string number, int seating, int standing)
        {
            if (string.IsNullOrEmpty(number)) throw new ArgumentOutOfRangeException("number", "bus number must be supplied");
            if (seating <= 0) throw new ArgumentOutOfRangeException("seating");
            if (standing < 0) throw new ArgumentOutOfRangeException("standing");

            Id = id ?? throw new ArgumentNullException("id");
            BusNumber = number;
            SeatedCapacity = seating;
            StandingCapacity = standing;
        }

        public BusMemento State => new BusMemento(Id.Id, BusNumber, SeatedCapacity, StandingCapacity, DateTimeOffset.Now);

        public static Bus FromMemento(BusMemento memento)
        {
            var entity = new Bus(
                    new BusId(memento.Id),
                    memento.BusNumber,
                    memento.SeatedCapacity,
                    memento.StandingCapacity
                );
            return entity;
        }
    }

    public class BusId : Identity<Guid>
    {
        public BusId(Guid id) : base(id) { }
    }
}

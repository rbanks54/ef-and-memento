using System;
using Domain.Mementos;
using Domain.SharedKernel;

namespace Domain
{
    public class BusRoute : IAggregateRoot
    {
        public BusRouteId Id { get; }
        public string Name { get; }

        public BusRoute(BusRouteId id, string routeName)
        {
            Id = id;
            Name = routeName;
        }

        public BusRouteMemento State => new BusRouteMemento(Id.Id);

        public static BusRoute FromMemento(BusRouteMemento memento)
        {
            var entity = new BusRoute(
                    new BusRouteId(memento.Id),
                    memento.Id.ToString()
                );
            return entity;
        }

    }

    public class BusRouteId : Identity<int>
    {
        public BusRouteId(int id) : base(id) { }
    }
}
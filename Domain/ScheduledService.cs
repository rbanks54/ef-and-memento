using System;
using System.Collections.Generic;
using System.Text;
using Domain.Mementos;
using Domain.SharedKernel;

namespace Domain
{
    public class ScheduledService : IHaveState<ScheduledServiceMemento>
    {
        public ScheduledServiceId Id { get; }
        public BusId BusId { get; }
        public BusRouteId RouteId { get; }
        public bool IsActive { get; private set; }

        public ScheduledService(ScheduledServiceId id, BusId busId, BusRouteId routeId)
        {
            Id = id ?? throw new ArgumentNullException("id");
            BusId = busId ?? throw new ArgumentNullException("busId");
            RouteId = routeId ?? throw new ArgumentNullException("routeId");
            IsActive = false;
        }

        public void Activate()
        {
            if (IsActive) return;

            IsActive = true;
            //RaiseEvent("RouteActivated");
        }

        public ScheduledServiceMemento State => new ScheduledServiceMemento(Id.Id, BusId.Id, RouteId.Id, IsActive);

        public static ScheduledService FromMemento(ScheduledServiceMemento memento)
        {
            var entity = new ScheduledService(new ScheduledServiceId(memento.Id),
                new BusId(memento.BusId),
                new BusRouteId(memento.RouteId))
            {
                IsActive = memento.IsActive
            };
            return entity;
        }
    }

    public class ScheduledServiceId : Identity<Guid>
    {
        public ScheduledServiceId(Guid id) : base(id) { }
    }
}

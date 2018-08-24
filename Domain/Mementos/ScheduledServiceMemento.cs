using Domain.SharedKernel;
using System;

namespace Domain.Mementos
{
    public class ScheduledServiceMemento : EntityMemento
    {
        public Guid Id { get; private set; }
        public Guid BusId { get; private set; }
        public int RouteId { get; private set; }
        public bool IsActive { get; private set; }

        internal ScheduledServiceMemento(Guid id, Guid busId, int routeId, bool isActive)
        {
            Id = id;
            BusId = busId;
            RouteId = routeId;
            IsActive = isActive;
        }
    }
}
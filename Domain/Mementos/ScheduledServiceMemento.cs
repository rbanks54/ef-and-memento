using Domain.SharedKernel;
using System;

namespace Domain.Mementos
{
    public record ScheduledServiceMemento(Guid Id, Guid BusId, int RouteId, bool IsActive, DateTimeOffset LastModified) : IEntityMemento;
}
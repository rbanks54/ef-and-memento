using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mementos
{
    public record BusMemento(Guid Id,string BusNumber, int SeatedCapacity, int StandingCapacity, DateTimeOffset LastModified) : IEntityMemento;
}

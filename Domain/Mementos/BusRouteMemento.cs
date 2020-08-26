using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mementos
{
    public record BusRouteMemento(int Id, string Name, DateTimeOffset LastModified) : IEntityMemento;
}

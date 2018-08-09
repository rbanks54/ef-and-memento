using System;
using Domain.SharedKernel;

namespace Domain
{
    public class BusRoute : IAggregateRoot
    {
        public BusRouteId Id { get; set; }
        public string Name { get; set; }
    }

    public class BusRouteId : Identity<int>
    {
        public BusRouteId(int id) : base(id) { }
    }
}
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's just pretend this is a great UI, ok?");
            Console.WriteLine(@"
Commands are:
[Add Bus, Number, standing, seating]: AB xyz nnn nnn
[Add Route: name]: AR nnn
[Schedule Bus: number name]: SB xyz nnn
");

            var options = new DbContextOptionsBuilder<BusContext>()
                .UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=BusRoutes;Trusted_Connection=True;")
//                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            using (var db = new BusContext(options))
            {
                db.Database.Migrate();

                while (true)
                {
                    Console.Write("Command | ");
                    var input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        break;
                    var command = input.Substring(0, 2);
                    var opt = input.Split(' ');
                    switch (command)
                    {
                        case "AB":
                            AddBus(db, opt[1], opt[2], opt[3]);
                            break;
                        case "AR":
                            AddRoute(db, opt[1]);
                            break;
                        case "SB":
                            ScheduleBus(db, opt[1], opt[2]);
                            break;
                        default:
                            Console.WriteLine("Huh?");
                            break;
                    }
                }

                Console.WriteLine("--- Buses and Routes ---");

                var buses = GetBuses(db);
                foreach (var b in buses)
                    Console.WriteLine($"Bus {b.BusNumber} can seat {b.SeatedCapacity} and stand {b.StandingCapacity}");

                var routes = GetRoutes(db);
                foreach (var r in routes)
                    Console.WriteLine($"Route {r.Name}");

                Console.WriteLine("--- YOUR BUS SCHEDULE ---");
                var schedule = GetSchedule(db);
                foreach (var s in schedule)
                    Console.WriteLine($"Trip: Bus {s.BusNumber} on Route {s.RouteNumber} is {(s.IsActive ? "active" : "inactive")} ");

            }
            Console.ReadLine();
        }

        public static void AddBus(BusContext db, string number, string seated, string standing)
        {
            var seatingCapacity = int.Parse(seated);
            var standingCapacity = int.Parse(standing);

            var id = new BusId(Guid.NewGuid());
            var b = new Bus(id, number, seatingCapacity, standingCapacity);

            db.Add(b.State);
            db.SaveChanges();
        }

        public static IEnumerable<Bus> GetBuses(BusContext db)
        {
            var queryResult = from b in db.Buses
                              select Bus.FromMemento(b);

            return queryResult.AsEnumerable();
        }

        public static void AddRoute(BusContext db, string name)
        {
            var id = new BusRouteId(int.Parse(name));
            var r = new BusRoute(id, name);

            db.Add(r.State);
            db.SaveChanges();
        }

        public static IEnumerable<BusRoute> GetRoutes(BusContext db)
        {
            var queryResult = from r in db.BusRoutes
                              select BusRoute.FromMemento(r);

            return queryResult.AsEnumerable();
        }

        public static void ScheduleBus(BusContext db, string busNumber, string routeName)
        {
            //pretend this is in a repository
            var bus = Bus.FromMemento(db.Buses.Single(b => b.BusNumber == busNumber));
            var route = BusRoute.FromMemento(db.BusRoutes.Single(r => r.Id == int.Parse(routeName)));

            var schedule = new ScheduledService(new ScheduledServiceId(Guid.NewGuid()), bus.Id, route.Id);

            if (busNumber.StartsWith("A"))
                schedule.Activate();

            db.Services.Add(schedule.State);
            db.SaveChanges();
        }

        public static IEnumerable<ScheduleDto> GetSchedule(BusContext db)
        {
            var queryResult = from s in db.Services
                              join b in db.Buses on s.BusId equals b.Id
                              join r in db.BusRoutes on s.RouteId equals r.Id
                              select new ScheduleDto
                              {
                                  RouteNumber = r.Id,
                                  BusNumber = b.BusNumber,
                                  IsActive = s.IsActive
                              };

            return queryResult.AsEnumerable();
        }

        public class ScheduleDto
        {
            public int RouteNumber { get; set; }
            public string BusNumber { get; set; }
            public bool IsActive { get; set; }
        }

    }
}

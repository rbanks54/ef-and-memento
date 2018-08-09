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
[Add Bus, Number, standing, seating]: AB nnn nnn nnn
[Add Route: name]: AR xyz
[Schedule Bus: number name]: SB nnn xyz
");

            var options = new DbContextOptionsBuilder<BusContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            using (var db = new BusContext(options))
            {
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
                        //case "AR":
                        //    AddRoute(db, opt[1]);
                        //    break;
                        //case "SB":
                        //    ScheduleBus(db, opt[1], opt[2]);
                        //    break;
                        default:
                            Console.WriteLine("Huh?");
                            break;
                    }
                }

                Console.WriteLine("--- YOUR BUS SCHEDULE ---");
                //var schedule = GetSchedule();
                //foreach (var t in schedule.trips)
                //    Console.WriteLine($"Trip: Bus {t.BusNumber} on Route {t.RouteName}");
                var buses = GetBuses(db);
                foreach (var b in buses)
                    Console.WriteLine($"Bus {b.BusNumber} can seat {b.SeatedCapacity} and stand {b.StandingCapacity}");


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
            db.SaveChangesAsync();
        }

        public static IEnumerable<Bus> GetBuses(BusContext db)
        {
            var queryResult = from b in db.Buses
                              select Bus.Factory.FromMemento(b);

            return queryResult.AsEnumerable();
        }
    }
}

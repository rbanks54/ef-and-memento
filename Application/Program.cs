using System;

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
            while(true)
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
                        AddBus(opt[1], opt[2], opt[3]);
                        break;
                    //case "AR":
                    //    AddRoute(opt[1]);
                    //    break;
                    //case "SB":
                    //    ScheduleBus(opt[1], opt[2]);
                    //    break;
                    default:
                        Console.WriteLine("Huh?");
                        break;
                }
            }

            //Console.WriteLine("--- YOUR BUS SCHEDULE ---");
            //var schedule = GetSchedule();
            //foreach (var t in schedule.trips)
            //    Console.WriteLine($"Trip: Bus {t.BusNumber} on Route {t.RouteName}");
            Console.ReadLine();
        }

        public static void AddBus(string number, string seated, string standing)
        {
            var busNumber = int.Parse(number);
            var seatingCapacity = int.Parse(seated);
            var standingCapacity = int.Parse(standing);

        }
    }
}

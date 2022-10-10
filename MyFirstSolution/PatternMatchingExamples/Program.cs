using System;
using System.Collections.Generic;

namespace PatternMatchingExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(5, 400, "AABB123");
            var airplane = new Airplane(200, 3000, 40);
            var ship = new Ship(500, 4000);

            var vehicles = new List<Vehicle> { car, airplane, ship };

            var randomVehicle = vehicles[new Random().Next(vehicles.Count)];

            //  C# 6.0
            if (randomVehicle is Car)
            {
                var c = randomVehicle as Car;   //  or cast it
                Console.WriteLine($"This is a car with plate number {c.PlateNumber}");
            }

            //  C# 7.0
            if (randomVehicle is Car c1)
            {
                Console.WriteLine($"This is a car with plate number {c1.PlateNumber}");
            }

            switch (randomVehicle)  //  switch statement on an object
            {
                case Car c2:
                    Console.WriteLine($"This is a car with plate number {c2.PlateNumber}");
                    break;
                case Airplane ap when ap.Capacity > 300:
                    Console.WriteLine($"This is a huge plane with capacity of {ap.Capacity}");
                    break;
                default:
                    Console.WriteLine("Just on ordinary vehicle");
                    break;
            }

            //  C# 8.0
            if (randomVehicle is Car { PlateNumber: "AABB123" } c3)
            {
                Console.WriteLine($"This is my car with plate number {c3.PlateNumber}");
            }

            //  switch expression (not switch statement)
            var vehicleText = randomVehicle switch
            {
                Car { Capacity: 7 } => "This is a car for a family",
                Car c => $"This is a car with platenumber {c.PlateNumber}",
                Airplane ap when ap.Capacity > 300 => "This is a huge airplane",
                Airplane _ => "This is an airplane",
                { Range: 1000 } => "Vehicle with range 1000",
                _ => "This is the default"
            };

            Console.WriteLine(vehicleText);

            //  C# 9.0
            if (randomVehicle is not Car)   //  not
            {
            }

            if (randomVehicle is Car { Range: > 300 and < 1000, Capacity: >= 5 } c4)    //  smaller and greater check
            {
                Console.WriteLine($"This is my car with plate number {c4.PlateNumber}");
            }

            //  switch expression
            var vehicleText2 = randomVehicle switch
            {
                Car { Capacity: 7 } => "This is a car for a family",
                Car { Capacity: <= 2 } c => $"This is a small or a sport car",
                _ => "This is the default"
            };

            Console.WriteLine(vehicleText);

            //   Tuple pattern
            State state = State.Open;
            Action action = Action.Close;
            var newState = (state, action) switch
            {
                (State.Open, Action.Close) => State.Closed,
                (State.Open, Action.Open) => throw new Exception("Cannot open."),
                (State.Closed, Action.Open) => State.Open,
                (State.Closed, Action.Close) => throw new Exception("Cannot close."),
                _ => state
            };
        }
    }

    public enum State { Open, Closed }
    public enum Action { Open, Close }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingExamples
{
    internal abstract class Vehicle
    {
        public Vehicle(int capacity, int range)
        {
            this.Capacity = capacity;
            this.Range = range;
        }
        public int Capacity { get; private set; }
        public int Range { get; private set; }
    }

    internal class Car : Vehicle
    {
        public Car(int capacity, int range, string plateNumber)
            : base(capacity, range)
        {
            this.PlateNumber = plateNumber;
        }
        public string PlateNumber { get; private set; }
    }

    internal class Airplane : Vehicle
    {
        public Airplane(int capacity, int range, int wingSpan)
            : base(capacity, range)
        {
            this.WingSpan = wingSpan;
        }
        public double WingSpan { get; set; }
    }

    internal class Ship : Vehicle
    {
        public Ship(int capacity, int range)
            : base(capacity, range)
        {
        }
    }
}

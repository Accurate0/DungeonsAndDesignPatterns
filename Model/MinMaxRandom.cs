using System;

namespace DnDesignPattern.Model
{
    /// <summary>
    /// A simple class to wrap Random.next
    /// Since a lot of effects within this program
    /// use a range of values rather than
    /// an exact value
    /// </summary>
    public class MinMaxRandom
    {
        public static int? testValue = null;
        public int Min { get; }
        public int Max { get; }
        private static readonly Random random = new Random();
        // Initialize random number generator once

        public int Value {
            get => testValue.HasValue ? testValue.Value : random.Next(Min, Max + 1);
        }

        public MinMaxRandom(int min, int max)
        {
            if(min > max) {
                throw new ArgumentException("min must be less than or equal to max", "min");
            }

            Min = min;
            Max = max;
        }

        public override string ToString()
        {
            return $"{Min}-{Max}";
        }

        public static void SetTestValue(int val)
        {
            testValue = val;
        }
    }
}

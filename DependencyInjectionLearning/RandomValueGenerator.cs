using System;

namespace DependencyInjectionLearning
{
    public class RandomValueGenerator : IRandomValueGenerator
    {
        public int RandomValue { get; }

        public RandomValueGenerator()
        {
            RandomValue = new Random().Next(1000);
        }

        //public int GetRandomNumber()
        //{
        //    return new Random().Next(1000);
        //}
    }

    public interface IRandomValueGenerator
    {
        //public int GetRandomNumber();
        public int RandomValue { get; }
    }
}

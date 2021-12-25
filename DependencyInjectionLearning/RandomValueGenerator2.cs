using System;

namespace DependencyInjectionLearning
{
    public class RandomValueGenerator2 : IRandomValueGenerator2
    {
        private readonly IRandomValueGenerator randomValueGenerator;
        public int RandomValue { get; }

        public RandomValueGenerator2(IRandomValueGenerator RandomValueGenerator)
        {
            RandomValue = new Random().Next(1000);
            randomValueGenerator = RandomValueGenerator;
        }

        public int GetRandomValueGeneratorRandomNumber()
        {
            return randomValueGenerator.RandomValue;
        }
    }

    public interface IRandomValueGenerator2
    {
        public int RandomValue { get; }
        public int GetRandomValueGeneratorRandomNumber();
    }
}

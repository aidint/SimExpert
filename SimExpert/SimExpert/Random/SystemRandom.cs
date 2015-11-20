

using System;

namespace SimExpert
{
  public class SystemRandom : IRandom {
    private Random random;

    public SystemRandom() {
      random = new Random();
    }

    public SystemRandom(int seed) {
      random = new Random(seed);
    }
    public int Next() {
      return random.Next();
    }

    public int Next(int upperBound) {
      return random.Next(upperBound);
    }

    public int Next(int lowerBound, int upperBound) {
      return random.Next(lowerBound, upperBound);
    }

    public double NextDouble() {
      return random.NextDouble();
    }

    public void Reinitialise(int seed) {
      random = new Random(seed);
    }
  }
}

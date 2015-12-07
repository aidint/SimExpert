
namespace SimExpert
{
  public interface IRandom {
    int Next();
    int Next(int upperBound);
    int Next(int lowerBound, int upperBound);
    double NextDouble();

    void Reinitialise(int seed);
  }
}

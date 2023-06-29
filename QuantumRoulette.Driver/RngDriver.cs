using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using QuantumRoulette.Rng;

namespace QuantumRoulette.Driver;

public class RngDriver
{
    public static void Run() {
        {
            using (var sim = new QuantumSimulator())
            {
                var numNums = 50;
                Console.WriteLine($"Generating {numNums} numbers...");
                var quantumRandomNumbers = Enumerable.Range(0, numNums)
                    .Select(_ => QuantumRandomNumber.Run(sim).Result)
                    .ToList();

                Console.WriteLine(string.Join(", ", quantumRandomNumbers));
            }
        }
    }
}

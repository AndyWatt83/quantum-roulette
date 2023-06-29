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
                Console.WriteLine("Hello standard world!");
                QuantumRoulette.Rng.HelloQ.Run(sim);
            }
        }
    }
}

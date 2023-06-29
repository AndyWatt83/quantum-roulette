namespace QuantumRoulette.Rng {
    open Microsoft.Quantum.Arithmetic;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation QuantumRandomNumber() : Int {
        mutable result = 0;
        set result = 37; // Start with a value outside the desired range
        repeat {
            use register = Qubit[6] {
                ApplyToEach(H, register); // Put each qubit in superposition
                set result = MeasureInteger(LittleEndian(register)); // Measure the qubits
                ResetAll(register); // Reset all qubits before releasing them
            }
        }
        until (result <= 36);
        return result;
    }
}

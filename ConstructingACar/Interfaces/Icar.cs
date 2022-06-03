namespace ConstructingACar.Interfaces
{
    public interface ICar
    {
        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();

        void BrakeBy(int speed);

        void Accelerate(int speed);

        void FreeWheel();
    }
}
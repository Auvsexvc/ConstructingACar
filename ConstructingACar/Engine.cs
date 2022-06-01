using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class Engine : IEngine
        {
            private bool _isRunning = false;
            private IFuelTank _fuelTank;

            public bool IsRunning { get => _isRunning; }

            public Engine(IFuelTank fuelTank)
            {
                _fuelTank = fuelTank;
            }

            public void Consume(double liters)
            {
                if (_isRunning)
                {
                    _fuelTank.Consume(liters);
                    if (_fuelTank.FillLevel == 0)
                        Stop();
                }
            }

            public void Start()
            {
                _isRunning = true;
            }

            public void Stop()
            {
                _isRunning = false;
            }
        }
    }
}
using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class Engine : IEngine
    {
        private IFuelTank _fuelTank;
        
        private bool _isRunning = false;

        public bool IsRunning => _isRunning;

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

        public void Start() => _isRunning = true;

        public void Stop() => _isRunning = false;
    }
}
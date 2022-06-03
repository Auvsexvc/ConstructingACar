using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class FuelTank : IFuelTank
    {
        private const double _tankCap = 60;
        private const double _defaultFill = 20;
        private const double _reserve = 5;

        private double _fillLevel;

        public double FillLevel => _fillLevel;
        public bool IsOnReserve => _fillLevel < _reserve;
        public bool IsComplete => _fillLevel == _tankCap;

        public FuelTank()
        {
            _fillLevel = _defaultFill;
        }

        public FuelTank(double fuelLevel)
        {
            if (fuelLevel < 0)
                fuelLevel = 0;
            if (fuelLevel > _tankCap)
                fuelLevel = _tankCap;
            _fillLevel = fuelLevel;
        }

        public void Consume(double liters)
        {
            _fillLevel -= liters;
            _fillLevel = Math.Round(_fillLevel, 10);

            if (_fillLevel < 0)
                _fillLevel = 0;
        }

        public void Refuel(double liters)
        {
            _fillLevel += liters;
            if (_fillLevel > _tankCap)
                _fillLevel = _tankCap;
        }
    }
}
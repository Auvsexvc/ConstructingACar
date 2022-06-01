using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class FuelTank : IFuelTank
        {
            private double _fillLevel;
            private double _tankCap = 60;
            private double _defaultFill = 20;
            private double _reserve = 5;

            public double FillLevel { get => _fillLevel; }
            public bool IsOnReserve { get => _fillLevel < _reserve; }
            public bool IsComplete { get => _fillLevel == _tankCap; }

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
                if (_fillLevel > 0)
                {
                    _fillLevel -= liters;
                    _fillLevel = Math.Round(_fillLevel, 10);
                }
                else
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
}
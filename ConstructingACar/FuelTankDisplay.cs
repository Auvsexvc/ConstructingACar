using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class FuelTankDisplay : IFuelTankDisplay
        {
            private IFuelTank _fuelTank;

            public double FillLevel { get => Math.Round(_fuelTank.FillLevel, 2); }
            public bool IsOnReserve { get => _fuelTank.IsOnReserve; }
            public bool IsComplete { get => _fuelTank.IsComplete; }

            public FuelTankDisplay(IFuelTank fuelTank)
            {
                _fuelTank = fuelTank;
            }
        }
    }
}
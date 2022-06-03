using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class FuelTankDisplay : IFuelTankDisplay
    {
        private readonly IFuelTank _fuelTank;

        public double FillLevel => Math.Round(_fuelTank.FillLevel, 2);
        public bool IsOnReserve => _fuelTank.IsOnReserve;
        public bool IsComplete => _fuelTank.IsComplete;

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }
    }
}
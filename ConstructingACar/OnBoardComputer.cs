using ConstructingACar.Interfaces;
using static ConstructingACar.Constructing_a_car;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class OnBoardComputer : IOnBoardComputer // car #3
        {
            private IDrivingProcessor _drivingProcessor;
            private IFuelTankDisplay _fuelTankDisplay;
            private int _tripRealTime;
            private int _tripDrivingTime;
            private int _tripDrivenDistance;
            private int _totalRealTime;
            private int _totalDrivingTime;
            private int _totalDrivenDistance;
            private int _tripAverageSpeed;
            private int _totalAverageSpeed;
            private int _actualConsumptionByTime;


            public int TripRealTime => _tripRealTime;

            public int TripDrivingTime => _tripDrivingTime;

            public int TripDrivenDistance => _tripDrivenDistance;

            public int TotalRealTime => _totalRealTime;

            public int TotalDrivingTime => _totalDrivingTime;

            public int TotalDrivenDistance => _totalDrivenDistance;

            public double TripAverageSpeed => _tripAverageSpeed;

            public double TotalAverageSpeed => _totalAverageSpeed;

            public int ActualSpeed => _drivingProcessor.ActualSpeed;

            public double ActualConsumptionByTime => _actualConsumptionByTime;

            public double ActualConsumptionByDistance => throw new NotImplementedException();

            public double TripAverageConsumptionByTime => throw new NotImplementedException();

            public double TotalAverageConsumptionByTime => throw new NotImplementedException();

            public double TripAverageConsumptionByDistance => throw new NotImplementedException();

            public double TotalAverageConsumptionByDistance => throw new NotImplementedException();

            public int EstimatedRange => throw new NotImplementedException();

            public OnBoardComputer(IDrivingProcessor drivingProcessor, IFuelTankDisplay fuelTankDisplay)
            {
                _drivingProcessor = drivingProcessor;
                _fuelTankDisplay = fuelTankDisplay;
            }

            public void ElapseSecond()
            {
                
            }

            public void TotalReset()
            {
                throw new NotImplementedException();
            }

            public void TripReset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
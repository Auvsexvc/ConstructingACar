﻿using ConstructingACar.Interfaces;
using static ConstructingACar.Constructing_a_car;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class OnBoardComputer : IOnBoardComputer // car #3
        {
            private IDrivingProcessor _drivingProcessor;
            private IFuelTankDisplay _fuelTankDisplay;



            public int TripRealTime => throw new NotImplementedException();

            public int TripDrivingTime => throw new NotImplementedException();

            public int TripDrivenDistance => throw new NotImplementedException();

            public int TotalRealTime => throw new NotImplementedException();

            public int TotalDrivingTime => throw new NotImplementedException();

            public int TotalDrivenDistance => throw new NotImplementedException();

            public double TripAverageSpeed => throw new NotImplementedException();

            public double TotalAverageSpeed => throw new NotImplementedException();

            public int ActualSpeed => _drivingProcessor.ActualSpeed;

            public double ActualConsumptionByTime => _drivingProcessor.ActualConsumption;

            public double ActualConsumptionByDistance => _drivingProcessor.ActualConsumption;

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
                throw new NotImplementedException();
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
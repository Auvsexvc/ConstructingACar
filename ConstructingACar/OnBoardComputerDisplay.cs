using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
        {
            private readonly IOnBoardComputer _onBoardComputer;

            public int TripRealTime => throw new NotImplementedException();

            public int TripDrivingTime => throw new NotImplementedException();

            public double TripDrivenDistance => throw new NotImplementedException();

            public int TotalRealTime => throw new NotImplementedException();

            public int TotalDrivingTime => throw new NotImplementedException();

            public double TotalDrivenDistance => throw new NotImplementedException();

            public int ActualSpeed => throw new NotImplementedException();

            public double TripAverageSpeed => throw new NotImplementedException();

            public double TotalAverageSpeed => throw new NotImplementedException();

            public double ActualConsumptionByTime => throw new NotImplementedException();

            public double ActualConsumptionByDistance => throw new NotImplementedException();

            public double TripAverageConsumptionByTime => throw new NotImplementedException();

            public double TotalAverageConsumptionByTime => throw new NotImplementedException();

            public double TripAverageConsumptionByDistance => throw new NotImplementedException();

            public double TotalAverageConsumptionByDistance => throw new NotImplementedException();

            public int EstimatedRange => throw new NotImplementedException();

            public OnBoardComputerDisplay(IOnBoardComputer onBoardComputer)
            {
                _onBoardComputer = onBoardComputer;
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
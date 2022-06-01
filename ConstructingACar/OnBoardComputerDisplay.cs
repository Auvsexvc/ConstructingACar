using ConstructingACar.Interfaces;
using static ConstructingACar.Constructing_a_car;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
        {
            private readonly IOnBoardComputer _onBoardComputer;

            public int TripRealTime => _onBoardComputer.TripRealTime;

            public int TripDrivingTime => _onBoardComputer.TripDrivingTime;

            public double TripDrivenDistance => _onBoardComputer.TotalDrivenDistance;

            public int TotalRealTime => _onBoardComputer.TotalRealTime;

            public int TotalDrivingTime => _onBoardComputer.TotalDrivingTime;

            public double TotalDrivenDistance => _onBoardComputer.TotalDrivenDistance;

            public int ActualSpeed => _onBoardComputer.ActualSpeed;

            public double TripAverageSpeed => _onBoardComputer.TripAverageSpeed;

            public double TotalAverageSpeed => _onBoardComputer.TotalAverageSpeed;

            public double ActualConsumptionByTime => _onBoardComputer.ActualConsumptionByTime;

            public double ActualConsumptionByDistance => _onBoardComputer.ActualConsumptionByDistance;

            public double TripAverageConsumptionByTime => _onBoardComputer.TripAverageConsumptionByTime;

            public double TotalAverageConsumptionByTime => _onBoardComputer.TotalAverageConsumptionByTime;

            public double TripAverageConsumptionByDistance => _onBoardComputer.TripAverageConsumptionByDistance;

            public double TotalAverageConsumptionByDistance => _onBoardComputer.TotalAverageConsumptionByDistance;

            public int EstimatedRange => _onBoardComputer.EstimatedRange;

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
using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
    {
        private readonly IOnBoardComputer _onBoardComputer;

        public int TripRealTime => _onBoardComputer.TripRealTime;
        public int TripDrivingTime => _onBoardComputer.TripDrivingTime;
        public double TripDrivenDistance => Math.Round(Utils.ConvertToKMPS(_onBoardComputer.TripDrivenDistance), 2);
        public int TotalRealTime => _onBoardComputer.TotalRealTime;
        public int TotalDrivingTime => _onBoardComputer.TotalDrivingTime;
        public double TotalDrivenDistance => Math.Round(Utils.ConvertToKMPS(_onBoardComputer.TotalDrivenDistance), 2);
        public int ActualSpeed => _onBoardComputer.ActualSpeed;
        public double TripAverageSpeed => Math.Round(_onBoardComputer.TripAverageSpeed, 1);
        public double TotalAverageSpeed => Math.Round(_onBoardComputer.TotalAverageSpeed, 1);
        public double ActualConsumptionByTime => Math.Round(_onBoardComputer.ActualConsumptionByTime, 5);
        public double ActualConsumptionByDistance => Math.Round(_onBoardComputer.ActualConsumptionByDistance, 1);
        public double TripAverageConsumptionByTime => Math.Round(_onBoardComputer.TripAverageConsumptionByTime, 5);
        public double TotalAverageConsumptionByTime => Math.Round(_onBoardComputer.TotalAverageConsumptionByTime, 5);
        public double TripAverageConsumptionByDistance => Math.Round(_onBoardComputer.TripAverageConsumptionByDistance, 1);
        public double TotalAverageConsumptionByDistance => Math.Round(_onBoardComputer.TotalAverageConsumptionByDistance, 1);
        public int EstimatedRange => _onBoardComputer.EstimatedRange;

        public OnBoardComputerDisplay(IOnBoardComputer onBoardComputer)
        {
            _onBoardComputer = onBoardComputer;
        }

        public void TotalReset()
        {
            _onBoardComputer.TotalReset();
        }

        public void TripReset()
        {
            _onBoardComputer.TripReset();
        }
    }
}
using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class OnBoardComputer : IOnBoardComputer // car #3
    {
        private IDrivingProcessor _drivingProcessor;
        private IFuelTank _fuelTank;

        private List<double> tripConsumptionHistory;
        private List<double> totalConsumptionHistory;
        private List<int> tripSpeedHistory;
        private List<int> totalSpeedHistory;
        private List<int> tripDistanceHistory;
        private List<int> totalDistanceHistory;
        private List<double> tripConsumptionByDistanceHistory;
        private List<double> totalConsumptionByDistanceHistory;
        private List<double> factoryAndTotalConsumptionByTime;

        public int TripRealTime => tripSpeedHistory.Count;
        public int TripDrivingTime => tripSpeedHistory.Count(s => s > 0);
        public int TripDrivenDistance => tripDistanceHistory.Sum();
        public int TotalRealTime => totalSpeedHistory.Count();
        public int TotalDrivingTime => totalSpeedHistory.Count(s => s > 0);
        public int TotalDrivenDistance => totalDistanceHistory.Sum();
        public double TripAverageSpeed => tripSpeedHistory.Sum() / (double)tripSpeedHistory.Count(s => s > 0);
        public double TotalAverageSpeed => totalSpeedHistory.Sum() / (double)totalSpeedHistory.Count(s => s > 0);
        public int ActualSpeed => _drivingProcessor.ActualSpeed;
        public double ActualConsumptionByTime => tripConsumptionHistory.Last();
        public double ActualConsumptionByDistance => tripDistanceHistory.Last() == 0 ? double.NaN : 100.0 * tripConsumptionHistory.Last() / Utils.ConvertToKMPS(tripDistanceHistory.Last());
        public double TripAverageConsumptionByTime => tripConsumptionHistory.Any() ? tripConsumptionHistory.Sum() / tripConsumptionHistory.Count : 0;
        public double TotalAverageConsumptionByTime => totalConsumptionHistory.Any() ? totalConsumptionHistory.Sum() / totalConsumptionHistory.Count : 0;
        public double TripAverageConsumptionByDistance => tripConsumptionByDistanceHistory.Any() ? tripConsumptionByDistanceHistory.Average() : 0;
        public double TotalAverageConsumptionByDistance => totalConsumptionByDistanceHistory.Any() ? totalConsumptionByDistanceHistory.Average() : 0;
        public int EstimatedRange => (int)Math.Round(100 * _fuelTank.FillLevel / factoryAndTotalConsumptionByTime.Concat(tripConsumptionByDistanceHistory).ToList().TakeLast(100).Average(), 0);

        public OnBoardComputer(IDrivingProcessor drivingProcessor, IFuelTank fuelTank)
        {
            _drivingProcessor = drivingProcessor;
            _fuelTank = fuelTank;
            tripSpeedHistory = new List<int>();
            totalSpeedHistory = new List<int>();
            tripDistanceHistory = new List<int>();
            totalDistanceHistory = new List<int>();
            totalConsumptionHistory = new List<double>();
            tripConsumptionHistory = new List<double>();
            tripConsumptionByDistanceHistory = new List<double>();
            totalConsumptionByDistanceHistory = new List<double>();
            factoryAndTotalConsumptionByTime = new List<double>();
            factoryAndTotalConsumptionByTime.AddRange(Enumerable.Repeat(4.8, 100).ToList());
        }

        public void ElapseSecond()
        {
            //Log.Info($"ElapseSecond()");
            tripSpeedHistory.Add(ActualSpeed);
            totalSpeedHistory.Add(ActualSpeed);

            tripConsumptionHistory.Add(_drivingProcessor.ActualConsumption);
            totalConsumptionHistory.Add(_drivingProcessor.ActualConsumption);

            tripDistanceHistory.Add(ActualSpeed);
            totalDistanceHistory.Add(ActualSpeed);

            if (!Double.IsNaN(ActualConsumptionByDistance))
            {
                tripConsumptionByDistanceHistory.Add(Math.Round(ActualConsumptionByDistance, 2));
                totalConsumptionByDistanceHistory.Add(Math.Round(ActualConsumptionByDistance, 2));
            }
            else if (_drivingProcessor.ActualSpeed != 0)
            {
                tripConsumptionByDistanceHistory.Add(_drivingProcessor.ActualConsumption);
                totalConsumptionByDistanceHistory.Add(_drivingProcessor.ActualConsumption);
            }
            //Log.Info($"ActualConsumptionByDistance(OBC): {ActualConsumptionByDistance}");
        }

        public void TotalReset()
        {
            //Log.Info($"TotalReset()");
            totalSpeedHistory.Clear();
            totalDistanceHistory.Clear();
            totalConsumptionHistory.Clear();
            totalConsumptionByDistanceHistory.Clear();
            factoryAndTotalConsumptionByTime.Clear();
        }

        public void TripReset()
        {
            //Log.Info($"TripReset()");
            tripSpeedHistory.Clear();
            tripDistanceHistory.Clear();
            tripConsumptionHistory.Clear();
            tripConsumptionByDistanceHistory.Clear();
        }
    }
}
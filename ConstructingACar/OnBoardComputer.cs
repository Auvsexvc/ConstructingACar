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
            private IEngine _engine;
            private List<double> _tripConsumptionHistory;
            private List<double> _totalConsumptionHistory;
            private List<int> _tripSpeedHistory;
            private List<int> _totalSpeedHistory;
            private List<double> _tripDistanceHistory;
            private List<double> _totalDistanceHistory;

            public int TripRealTime => _tripSpeedHistory.Count;

            public int TripDrivingTime => _tripSpeedHistory.Count(s=>s>0);

            public double TripDrivenDistance => Math.Round(_tripDistanceHistory.Sum(), 2);

            public int TotalRealTime => _totalSpeedHistory.Count;

            public int TotalDrivingTime => _totalSpeedHistory.Count(s=>s>0);

            public double TotalDrivenDistance => Math.Round(_totalDistanceHistory.Sum(),2);

            public double TripAverageSpeed => Math.Round(_tripSpeedHistory.Sum() / (double)_tripSpeedHistory.Count, 1);

            public double TotalAverageSpeed => Math.Round(_totalSpeedHistory.Sum() / (double)_tripSpeedHistory.Count, 1);

            public int ActualSpeed => _drivingProcessor.ActualSpeed;

            public double ActualConsumptionByTime => _drivingProcessor.ActualConsumption;

            public double ActualConsumptionByDistance => _drivingProcessor.ActualConsumption;

            public double TripAverageConsumptionByTime => Math.Round(_tripConsumptionHistory.Sum() / _tripConsumptionHistory.Count, 5);

            public double TotalAverageConsumptionByTime => Math.Round(_totalConsumptionHistory.Sum() / _totalConsumptionHistory.Count, 5);

            public double TripAverageConsumptionByDistance => Math.Round(_tripConsumptionHistory.Sum() / (_tripConsumptionHistory.Count*100), 1);

            public double TotalAverageConsumptionByDistance => Math.Round(_totalConsumptionHistory.Sum() / (_totalConsumptionHistory.Count * 100), 1);

            public int EstimatedRange => (int)(_fuelTankDisplay.FillLevel/ (_totalConsumptionHistory.TakeLast(100).Sum()/100));

            public OnBoardComputer(IDrivingProcessor drivingProcessor, IFuelTankDisplay fuelTankDisplay, IEngine engine)
            {
                _drivingProcessor = drivingProcessor;
                _fuelTankDisplay = fuelTankDisplay;
                _engine = engine;
                _totalConsumptionHistory = Enumerable.Repeat(4.8, 100).ToList();
            }

            public void ElapseSecond()
            {
                //how to trigger???
                
                _tripSpeedHistory.Add(ActualSpeed);
                _totalSpeedHistory.Add(ActualSpeed);

                _tripConsumptionHistory.Add(_drivingProcessor.ActualConsumption);
                _totalConsumptionHistory.Add(_drivingProcessor.ActualConsumption);

                _tripDistanceHistory.Add(ActualSpeed * 0.000277778);
                _totalDistanceHistory.Add(ActualSpeed * 0.000277778);
            }

            public void TotalReset()
            {
                _tripSpeedHistory.Clear();
                _tripConsumptionHistory.RemoveRange(100, _tripConsumptionHistory.Count-100);
                _tripDistanceHistory.Clear();
            }

            public void TripReset()
            {
                _totalSpeedHistory.Clear();
                _totalConsumptionHistory.Clear();
                _totalDistanceHistory.Clear();
            }
        }
    }
}
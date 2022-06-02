using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class OnBoardComputer : IOnBoardComputer // car #3
        {
            private IDrivingProcessor _drivingProcessor;
            private IFuelTankDisplay _fuelTankDisplay;

            private List<double> _tripConsumptionHistory;
            private List<double> _totalAndFactoryConsumptionHistory;
            private List<int> _totalAndFactoryDistanceHistory;
            private List<double> _totalConsumptionHistory;
            private List<int> _tripSpeedHistory;
            private List<int> _totalSpeedHistory;
            private List<int> _tripDistanceHistory;
            private List<int> _totalDistanceHistory;


            public int TripRealTime => _tripSpeedHistory.Count;

            public int TripDrivingTime => _tripSpeedHistory.Count(s => s > 0);

            public int TripDrivenDistance => _tripDistanceHistory.Sum();

            public int TotalRealTime => _totalSpeedHistory.Count;

            public int TotalDrivingTime => _totalSpeedHistory.Count(s => s > 0);

            public int TotalDrivenDistance => _totalDistanceHistory.Sum();

            public double TripAverageSpeed => _tripSpeedHistory.Sum() / (double)_tripSpeedHistory.Count(s => s > 0);

            public double TotalAverageSpeed => _totalSpeedHistory.Sum() / (double)_totalSpeedHistory.Count(s => s > 0);

            public int ActualSpeed => _drivingProcessor.ActualSpeed;

            public double ActualConsumptionByTime => _tripConsumptionHistory.Last();

            public double ActualConsumptionByDistance => _tripDistanceHistory.Last() == 0 ? double.NaN : _tripConsumptionHistory.Last() / (_tripDistanceHistory.Last() * 0.000277778) * 100;

            public double TripAverageConsumptionByTime => _tripConsumptionHistory.Sum() / _tripConsumptionHistory.Count;

            public double TotalAverageConsumptionByTime => _totalConsumptionHistory.Sum() / _totalConsumptionHistory.Count;

            public double TripAverageConsumptionByDistance => !_tripDistanceHistory.Any(s => s > 0) ? 0 : _tripConsumptionHistory.Sum() / (_tripDistanceHistory.Sum() * 0.000277778) * 100;

            public double TotalAverageConsumptionByDistance => !_totalDistanceHistory.Any(s => s > 0) ? 0 : _totalConsumptionHistory.Sum() / (_totalDistanceHistory.Sum() * 0.000277778) * 100;

            public int EstimatedRange
            {
                get
                {
                    _totalAndFactoryConsumptionHistory.AddRange(_totalConsumptionHistory);
                    _totalAndFactoryDistanceHistory.AddRange(_totalDistanceHistory);
                    return (int)(_fuelTankDisplay.FillLevel / (_totalAndFactoryConsumptionHistory.TakeLast(100).Sum() / (_totalAndFactoryDistanceHistory.TakeLast(100).Sum() * 0.000277778)));
                }
            }

            public OnBoardComputer(IDrivingProcessor drivingProcessor, IFuelTankDisplay fuelTankDisplay)
            {
                _drivingProcessor = drivingProcessor;
                _fuelTankDisplay = fuelTankDisplay;
                _tripSpeedHistory = new List<int>();
                _totalSpeedHistory = new List<int>();
                _tripDistanceHistory = new List<int>();
                _totalDistanceHistory = new List<int>();
                _totalConsumptionHistory = new List<double>();
                _tripConsumptionHistory = new List<double>();
                _totalAndFactoryConsumptionHistory = Enumerable.Repeat(4.8 * 0.000277778, 100).ToList();
                _totalAndFactoryDistanceHistory = Enumerable.Repeat(0, 100).ToList();

            }

            public void ElapseSecond()
            {
                _tripSpeedHistory.Add(ActualSpeed);
                _totalSpeedHistory.Add(ActualSpeed);

                _tripConsumptionHistory.Add(_drivingProcessor.ActualConsumption);
                _totalConsumptionHistory.Add(_drivingProcessor.ActualConsumption);

                _tripDistanceHistory.Add(ActualSpeed);
                _totalDistanceHistory.Add(ActualSpeed);
                Console.Write(_tripDistanceHistory.Last() + ", ");
                Console.WriteLine("");
                Console.Write(_tripConsumptionHistory.Last() + ", ");
            }

            public void TotalReset()
            {
                _totalSpeedHistory.Clear();
                _totalConsumptionHistory.RemoveRange(100, _totalConsumptionHistory.Count - 100);
                _totalDistanceHistory.Clear();
            }

            public void TripReset()
            {
                _tripSpeedHistory.Clear();
                _tripConsumptionHistory.Clear();
                _tripDistanceHistory.Clear();
                ElapseSecond();
            }
        }
    }
}
using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class OnBoardComputer : IOnBoardComputer // car #3
        {
            private IDrivingProcessor _drivingProcessor;
            private IFuelTank _fuelTank;

            private List<double> _tripConsumptionHistory;
            private List<double> _totalConsumptionHistory;
            private List<int> _tripSpeedHistory;
            private List<int> _totalSpeedHistory;
            private List<int> _tripDistanceHistory;
            private List<int> _totalDistanceHistory;
            private List<double> _tripConsumptionByDistanceHistory;
            private List<double> _totalConsumptionByDistanceHistory;
            private List<double> _factoryConsumptionByDistanceHistory;
            private List<double> _factoryAndTotalConsumptionByDistanceHistory;

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
            public double ActualConsumptionByDistance => _tripDistanceHistory.Last() == 0 ? double.NaN : _tripConsumptionHistory.Last() / Conv(_tripDistanceHistory.Last()) * 100;
            public double TripAverageConsumptionByTime => _tripConsumptionHistory.Sum() / _tripConsumptionHistory.Count;
            public double TotalAverageConsumptionByTime => _totalConsumptionHistory.Sum() / _totalConsumptionHistory.Count;

            public double TripAverageConsumptionByDistance
            {
                get
                {
                    foreach (var item in _tripConsumptionByDistanceHistory.Skip(1))
                        Console.WriteLine(item);
                    if (!_tripConsumptionByDistanceHistory.Any())
                        return 0;
                    return _tripConsumptionByDistanceHistory.Skip(1).Any() ? _tripConsumptionByDistanceHistory.Skip(1).Average() : 0;
                }
            }

            public double TotalAverageConsumptionByDistance
            {
                get
                {
                    foreach (var item in _totalConsumptionByDistanceHistory.Skip(1))
                        Console.WriteLine($"_{item}");
                    if (!_totalConsumptionByDistanceHistory.Any())
                        return 0;
                    return _totalConsumptionByDistanceHistory.Skip(1).Any() ? _totalConsumptionByDistanceHistory.Skip(1).Average() : 0;
                }
            }

            public int EstimatedRange
            {
                get
                {
                    for (int i = 1; i < _totalConsumptionHistory.Count; i++)
                        _factoryAndTotalConsumptionByDistanceHistory.Add(_totalConsumptionHistory[i] / Conv(_totalDistanceHistory[i]) * 100);
                    return (int)Math.Round(_fuelTank.FillLevel / _factoryAndTotalConsumptionByDistanceHistory.TakeLast(100).Average() * 100, 0);
                }
            }

            public OnBoardComputer(IDrivingProcessor drivingProcessor, IFuelTank fuelTank)
            {
                _drivingProcessor = drivingProcessor;
                _fuelTank = fuelTank;
                _tripSpeedHistory = new List<int>();
                _totalSpeedHistory = new List<int>();
                _tripDistanceHistory = new List<int>();
                _totalDistanceHistory = new List<int>();
                _totalConsumptionHistory = new List<double>();
                _tripConsumptionHistory = new List<double>();
                _tripConsumptionByDistanceHistory = new List<double>();
                _totalConsumptionByDistanceHistory = new List<double>();
                _factoryConsumptionByDistanceHistory = Enumerable.Repeat(4.8, 100).ToList();
                _factoryAndTotalConsumptionByDistanceHistory = new List<double>();
                _factoryAndTotalConsumptionByDistanceHistory.AddRange(_factoryConsumptionByDistanceHistory);
            }

            public void ElapseSecond()
            {
                _tripSpeedHistory.Add(ActualSpeed);
                _totalSpeedHistory.Add(ActualSpeed);

                _tripConsumptionHistory.Add(_drivingProcessor.ActualConsumption);
                _totalConsumptionHistory.Add(_drivingProcessor.ActualConsumption);

                _tripDistanceHistory.Add(ActualSpeed);
                _totalDistanceHistory.Add(ActualSpeed);

                if (!Double.IsNaN(ActualConsumptionByDistance))
                    _tripConsumptionByDistanceHistory.Add(Math.Round(ActualConsumptionByDistance, 1));
                else
                    _tripConsumptionByDistanceHistory.Add(0);

                if (!Double.IsNaN(ActualConsumptionByDistance))
                    _totalConsumptionByDistanceHistory.Add(Math.Round(ActualConsumptionByDistance, 1));
                else
                    _totalConsumptionByDistanceHistory.Add(0);
            }

            public void TotalReset()
            {
                _totalSpeedHistory.Clear();
                //_totalConsumptionHistory.RemoveRange(100, _totalConsumptionHistory.Count - 100);
                _totalDistanceHistory.Clear();
                _totalConsumptionHistory.Clear();
                _totalConsumptionByDistanceHistory.Clear();
                ElapseSecond();
            }

            public void TripReset()
            {
                _tripSpeedHistory.Clear();
                _tripDistanceHistory.Clear();
                _tripConsumptionHistory.Clear();
                _tripConsumptionByDistanceHistory.Clear();
                ElapseSecond();
            }

            public double Conv(int speed) => speed / 3600.0;

            public double Conv(double speed) => speed / 3600.0;
        }
    }
}
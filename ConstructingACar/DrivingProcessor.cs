using ConstructingACar.Interfaces;
using static ConstructingACar.Constructing_a_car;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class DrivingProcessor : IDrivingProcessor // car #2
        {
            private IEngine _engine;
            private int _actualSpeed;
            private int _maxSpeed = 250;
            private int _acceleration = 10;
            private int _maxAcc = 20;
            private int _minAcc = 5;
            private int _maxBraking = 10;
            public double _actualConsumption = 0.0003;


            public int ActualSpeed => _actualSpeed;
            public double ActualConsumption => _engine.IsRunning ? _actualConsumption : 0;

            public DrivingProcessor(int acceleration, IEngine engine)
            {
                if (acceleration < _minAcc)
                    _acceleration = _minAcc;
                else if (acceleration > _maxAcc)
                    _acceleration = _maxAcc;
                else
                    _acceleration = acceleration;
                _actualConsumption = 0;
                _engine = engine;
            }

            public void IncreaseSpeedTo(int speed)
            {
                if (speed >= _maxSpeed)
                    speed = _maxSpeed;

                if (_actualSpeed < speed)
                {
                    if (speed >= _actualSpeed + _acceleration)
                        _actualSpeed += _acceleration;
                    else
                        _actualSpeed += speed - _actualSpeed;
                }
                if (ActualSpeed >= 1 && ActualSpeed <= 60)
                    _actualConsumption = 0.0020;
                else if (ActualSpeed >= 61 && ActualSpeed <= 100)
                    _actualConsumption = 0.0014;
                else if (ActualSpeed >= 101 && ActualSpeed <= 140)
                    _actualConsumption = 0.0020;
                else if (ActualSpeed >= 141 && ActualSpeed <= 200)
                    _actualConsumption = 0.0025;
                else if (ActualSpeed >= 141 && ActualSpeed <= 250)
                    _actualConsumption = 0.0030;
                else
                    _actualConsumption = 0.0003;
                
                _engine.Consume(_actualConsumption);
            }

            public void ReduceSpeed(int speed)
            {
                if (speed <= 0)
                {
                    speed = 0;
                }
                if (_actualSpeed >= speed)
                {
                    if (speed <= _maxBraking)
                        _actualSpeed -= speed;
                    else
                        _actualSpeed -= _maxBraking;
                }
                else
                    _actualSpeed -= _actualSpeed;
                
                _actualConsumption = 0.0003;
                _engine.Consume(_actualConsumption);
            }

            public void EngineStart()
            {
                _actualConsumption = 0.0003;
            }

            public void EngineStop()
            {
                _actualConsumption = 0.0000;
            }
        }
    }
}
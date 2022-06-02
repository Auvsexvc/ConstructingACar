using ConstructingACar.Interfaces;

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
            public double _actualConsumption;

            public int ActualSpeed => _actualSpeed;
            public double ActualConsumption => _actualConsumption;

            public DrivingProcessor(int acceleration, IEngine engine)
            {
                _engine = engine;

                if (acceleration < _minAcc)
                    _acceleration = _minAcc;
                else if (acceleration > _maxAcc)
                    _acceleration = _maxAcc;
                else
                    _acceleration = acceleration;
                _actualConsumption = 0;
            }

            public void IncreaseSpeedTo(int speed)
            {
                if (!_engine.IsRunning)
                    return;

                if (speed >= _maxSpeed)
                    speed = _maxSpeed;

                if (_actualSpeed < speed)
                {
                    if (speed >= _actualSpeed + _acceleration)
                        _actualSpeed += _acceleration;
                    else
                        _actualSpeed += speed - _actualSpeed;
                }

                Consume();
            }

            public void ReduceSpeed(int speed)
            {
                if (!_engine.IsRunning)
                    return;

                if (speed <= 0)
                {
                    speed = 0;
                    Consume();
                }

                if (_actualSpeed >= speed )
                {
                    if (speed <= _maxBraking)
                        _actualSpeed -= speed;
                    else
                        _actualSpeed -= _maxBraking;
                    if(_actualSpeed != 0) 
                        _actualConsumption = 0;
                    else
                        Consume();
                }
                else
                {
                    _actualSpeed -= _actualSpeed;
                    Consume();

                }
                
            }

            public void EngineStart()
            {
                //to do event
            }

            public void EngineStop()
            {
                //to do event
            }

            private void Consume()
            {
                if (!_engine.IsRunning)
                    return;

                _actualConsumption = 0.0003;
                if((_actualSpeed >= 1) && (_actualSpeed <= 60))
                    _actualConsumption = 0.0020;
                if ((_actualSpeed > 61) && (_actualSpeed <= 100))
                    _actualConsumption = 0.0014;
                if ((_actualSpeed > 141) && (_actualSpeed <= 200))
                    _actualConsumption = 0.0025;
                if ((_actualSpeed > 201) && (_actualSpeed <= 250))
                    _actualConsumption = 0.0030;

                _engine.Consume(_actualConsumption);
            }
        }
    }
}
using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class DrivingProcessor : IDrivingProcessor // car #2
    {
        private readonly IEngine _engine;

        private const int maxSpeed = 250;
        private const int minAcc = 5;
        private const int maxBraking = 10;

        private int actualSpeed;
        private readonly int maxAcc = 20;
        private double actualConsumption;

        public int ActualSpeed => actualSpeed;
        public double ActualConsumption => actualConsumption;

        public DrivingProcessor(int acceleration, IEngine engine)
        {
            _engine = engine;

            if (acceleration < minAcc)
            {
                acceleration = minAcc;
            }

            if (acceleration > maxAcc)
            {
                acceleration = maxAcc;
            }

            maxAcc = acceleration;
            actualConsumption = 0;
        }

        public void IncreaseSpeedTo(int speed)
        {
            if (!_engine.IsRunning)
            {
                return;
            }

            if (speed < actualSpeed)
            {
                actualSpeed--;
            }

            if (actualSpeed < speed)
            {
                actualSpeed = Math.Min(speed, actualSpeed + maxAcc);
            }

            if (actualSpeed > maxSpeed)
            {
                actualSpeed = maxSpeed;
            }

            Consume();

            //Log.Info($"ActualConsumption(DP): {ActualConsumption}");
        }

        public void ReduceSpeed(int speed)
        {
            if (!_engine.IsRunning)
            {
                return;
            }

            actualSpeed -= Math.Min(speed, maxBraking);

            if (speed == 1)
            {
                actualConsumption = 0;
            }

            if (actualSpeed <= 0)
            {
                actualSpeed = 0;
                actualConsumption = 0.0003;
                _engine.Consume(ActualConsumption);
            }
            else
            {
                actualConsumption = 0;
            }

            ////Log.Info($"ActualConsumption(DP): {ActualConsumption}");
        }

        public void EngineStart()
        {
            actualConsumption = 0;
            ////Log.Info($"ActualConsumption(DP): {ActualConsumption}");
        }

        public void EngineStop()
        {
            actualConsumption = 0;
            ////Log.Info($"ActualConsumption(DP): {ActualConsumption}");
        }

        private void Consume()
        {
            if (!_engine.IsRunning)
            {
                return;
            }

            actualConsumption = actualSpeed switch
            {
                int s when s <= 60 => 0.0020,
                int s when s <= 100 => 0.0014,
                int s when s <= 140 => 0.0020,
                int s when s <= 200 => 0.0025,
                int s when s <= 250 => 0.0030,
                _ => throw new ArgumentOutOfRangeException(),
            };

            ////Log.Info($"ActualConsumption: {ActualConsumption}");
            _engine.Consume(actualConsumption);
        }
    }
}
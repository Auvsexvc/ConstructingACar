using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class Car : ICar
    {
        private readonly IEngine _engine;
        private readonly IFuelTank _fuelTank;
        private readonly IDrivingProcessor _drivingProcessor;
        private readonly IOnBoardComputer _onBoardComputer; // car #3
        public IFuelTankDisplay _fuelTankDisplay;
        public IDrivingInformationDisplay _drivingInformationDisplay;
        public IOnBoardComputerDisplay _onBoardComputerDisplay; // car #3

        public bool EngineIsRunning => _engine.IsRunning;

        public Car(double fuelLevel = 20, int maxAcceleration = 10) // car #2
        {
            _fuelTank = new FuelTank(fuelLevel);
            _engine = new Engine(_fuelTank);
            _fuelTankDisplay = new FuelTankDisplay(_fuelTank);
            _drivingProcessor = new DrivingProcessor(maxAcceleration, _engine);
            _drivingInformationDisplay = new DrivingInformationDisplay(_drivingProcessor);
            _onBoardComputer = new OnBoardComputer(_drivingProcessor, _fuelTank);
            _onBoardComputerDisplay = new OnBoardComputerDisplay(_onBoardComputer);
            //Log.Info($"fuelLevel: {fuelLevel}, maxAcceleration: {maxAcceleration}");
        }

        public void EngineStart()
        {
            if (!EngineIsRunning && _fuelTank.FillLevel >= 0.0003)
            {
                //Log.Info($"EngineStart()");
                _engine.Start();
                _onBoardComputer.TripReset();
                _drivingProcessor.EngineStart();
                _onBoardComputer.ElapseSecond();
                //Log.Info($"fuel: {_fuelTank.FillLevel}");
            }
        }

        public void EngineStop()
        {
            //Log.Info($"EngineStop()");
            if (EngineIsRunning)
            {
                _engine.Stop();
                _drivingProcessor.EngineStop();
                _onBoardComputer.ElapseSecond();
            }
            //Log.Info($"fuel: {_fuelTank.FillLevel}");
        }

        public void Refuel(double liters) => _fuelTank.Refuel(liters);

        public void RunningIdle()
        {
            if (EngineIsRunning)
            {
                //Log.Info($"RunningIdle()");
                _drivingProcessor.ReduceSpeed(0);
                _onBoardComputer.ElapseSecond();
                //Log.Info($"fuel: {_fuelTank.FillLevel}");
            }
        }

        public void BrakeBy(int speed)
        {
            if (EngineIsRunning)
            {
                //Log.Info($"BrakeBy({speed})");
                _drivingProcessor.ReduceSpeed(speed);
                _onBoardComputer.ElapseSecond();
                //Log.Info($"fuel: {_fuelTank.FillLevel}");
            }
        }

        public void Accelerate(int speed)
        {
            if (EngineIsRunning)
            {
                //Log.Info($"Accelerate({speed})");
                _drivingProcessor.IncreaseSpeedTo(speed);
                _onBoardComputer.ElapseSecond();
                //Log.Info($"fuel: {_fuelTank.FillLevel}");
            }
        }

        public void FreeWheel()
        {
            if (EngineIsRunning)
            {
                //Log.Info($"FreeWheel()");
                _drivingProcessor.ReduceSpeed(1);
                _onBoardComputer.ElapseSecond();
                //Log.Info($"fuel: {_fuelTank.FillLevel}");
            }
        }
    }
}
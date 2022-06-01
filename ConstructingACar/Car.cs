using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    internal partial class Constructing_a_car
    {
        public class Car : ICar
        {
            public IFuelTankDisplay fuelTankDisplay;
            private IEngine engine;
            private IFuelTank fuelTank;
            public IDrivingInformationDisplay drivingInformationDisplay;
            private IDrivingProcessor drivingProcessor;
            public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3
            private IOnBoardComputer onBoardComputer; // car #3

            public bool EngineIsRunning => engine.IsRunning;

            public Car(double fuelLevel = 20, int maxAcceleration = 10) // car #2
            {
                fuelTank = new FuelTank(fuelLevel);
                engine = new Engine(fuelTank);
                fuelTankDisplay = new FuelTankDisplay(fuelTank);
                drivingProcessor = new DrivingProcessor(maxAcceleration, engine);
                drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
                onBoardComputer = new OnBoardComputer(drivingProcessor, fuelTankDisplay);
                onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
            }

            public void EngineStart()
            {
                if (!EngineIsRunning && fuelTank.FillLevel >= 0.0003)
                {
                    engine.Start();
                    drivingProcessor.EngineStart();
                }
            }

            public void EngineStop()
            {
                if (EngineIsRunning)
                {
                    engine.Stop();
                    drivingProcessor.EngineStop();
                }
            }

            public void Refuel(double liters)
            {
                fuelTank.Refuel(liters);
            }

            public void RunningIdle()
            {
                drivingProcessor.ReduceSpeed(0);
            }

            public void BrakeBy(int speed)
            {
                drivingProcessor.ReduceSpeed(speed);
            }

            public void Accelerate(int speed)
            {
                drivingProcessor.IncreaseSpeedTo(speed);
            }

            public void FreeWheel()
            {
                drivingProcessor.ReduceSpeed(1);
            }
        }
    }
}
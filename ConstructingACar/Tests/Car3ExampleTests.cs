using NUnit.Framework;

namespace ConstructingACar.Tests
{
    [TestFixture]
    public class Car3ExampleTests
    {
        [Test]
        public void TestRealAndDrivingTimeBeforeStarting()
        {
            var car = new Car();

            Assert.AreEqual(0, car._onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car._onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(0, car._onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car._onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeAfterDriving()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);

            car.Accelerate(30);

            Assert.AreEqual(11, car._onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(8, car._onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(11, car._onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(8, car._onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestActualSpeedBeforeDriving()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            Assert.AreEqual(0, car._onBoardComputerDisplay.ActualSpeed, "Wrong actual speed.");
        }

        [Test]
        public void TestAverageSpeed1()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            Assert.AreEqual(18, car._onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
            Assert.AreEqual(18, car._onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
        }

        [Test]
        public void TestAverageSpeedAfterTripReset()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            car._onBoardComputerDisplay.TripReset();

            car.Accelerate(20);

            car.Accelerate(20);

            Assert.AreEqual(15, car._onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
            Assert.AreEqual(20, car._onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
        }

        [Test]
        public void TestActualConsumptionEngineStart()
        {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car._onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(double.NaN, car._onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionRunningIdle()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();

            Assert.AreEqual(0.0003, car._onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(double.NaN, car._onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionAccelerateTo100()
        {
            var car = new Car(40, 20);

            car.EngineStart();

            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);

            Assert.AreEqual(0.0014, car._onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(5, car._onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionFreeWheel()
        {
            var car = new Car(40, 20);

            car.EngineStart();

            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);

            car.FreeWheel();

            Assert.AreEqual(0, car._onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(0, car._onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterEngineStart()
        {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car._onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0, car._onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(0, car._onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(0, car._onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterAccelerating()
        {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            Assert.AreEqual(0.0015, car._onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0.0015, car._onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(44, car._onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(44, car._onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterBraking()
        {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            Assert.AreEqual(0.0009, car._onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0.0009, car._onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(26.4, car._onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(26.4, car._onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestDrivenDistancesAfterEngineStart()
        {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car._onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0, car._onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestDrivenDistancesAfterAccelerating()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 30).ToList().ForEach(c => car.Accelerate(30));

            Assert.AreEqual(0.24, car._onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0.24, car._onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestEstimatedRangeAfterDrivingOptimumSpeedForMoreThan100Seconds()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 150).ToList().ForEach(c => car.Accelerate(100));

            Assert.AreEqual(393, car._onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
        }
    }
}
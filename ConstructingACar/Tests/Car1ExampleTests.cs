using NUnit.Framework;

namespace ConstructingACar.Tests
{
    [TestFixture]
    public class Car1ExampleTests
    {
        [Test]
        public void TestMotorStartAndStop()
        {
            var car = new Car();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

            car.EngineStart();

            Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");

            car.EngineStop();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestFuelConsumptionOnIdle()
        {
            var car = new Car(1);

            car.EngineStart();

            Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

            Assert.AreEqual(0.10, car._fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void Test_fuelTankDisplayIsComplete()
        {
            var car = new Car(60);

            Assert.IsTrue(car._fuelTankDisplay.IsComplete, "Fuel tank must be complete!");
        }

        [Test]
        public void Test_fuelTankDisplayIsOnReserve()
        {
            var car = new Car(4);

            Assert.IsTrue(car._fuelTankDisplay.IsOnReserve, "Fuel tank must be on reserve!");
        }

        [Test]
        public void TestRefuel()
        {
            var car = new Car(5);

            car.Refuel(40);

            Assert.AreEqual(45, car._fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }
    }
}
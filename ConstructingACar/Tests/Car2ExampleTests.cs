﻿using NUnit.Framework;

namespace ConstructingACar.Tests
{
    [TestFixture]
    public class Car2ExampleTests
    {
        [Test]
        public void TestStartSpeed()
        {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestFreeWheelSpeed()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            Assert.AreEqual(100, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            car.FreeWheel();
            car.FreeWheel();
            car.FreeWheel();

            Assert.AreEqual(97, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestAccelerateBy10()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            car.Accelerate(160);
            Assert.AreEqual(110, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(160);
            Assert.AreEqual(120, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(160);
            Assert.AreEqual(130, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(160);
            Assert.AreEqual(140, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(145);
            Assert.AreEqual(145, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestBraking()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            car.BrakeBy(20);

            Assert.AreEqual(90, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            car.BrakeBy(10);

            Assert.AreEqual(80, car._drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestConsumptionSpeedUpTo30()
        {
            var car = new Car(1, 20);

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            Assert.AreEqual(0.98, car._fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }
    }
}
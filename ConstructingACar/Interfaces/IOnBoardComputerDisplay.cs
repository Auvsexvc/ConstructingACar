using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructingACar.Interfaces
{
    internal interface IOnBoardComputerDisplay
    {
        int TripRealTime { get; }

        int TripDrivingTime { get; }

        double TripDrivenDistance { get; }

        int TotalRealTime { get; }

        int TotalDrivingTime { get; }

        double TotalDrivenDistance { get; }

        int ActualSpeed { get; }

        double TripAverageSpeed { get; }

        double TotalAverageSpeed { get; }

        double ActualConsumptionByTime { get; }

        double ActualConsumptionByDistance { get; }

        double TripAverageConsumptionByTime { get; }

        double TotalAverageConsumptionByTime { get; }

        double TripAverageConsumptionByDistance { get; }

        double TotalAverageConsumptionByDistance { get; }

        int EstimatedRange { get; }

        void TripReset();

        void TotalReset();
    }
}

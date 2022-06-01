using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructingACar.Interfaces
{
    public interface IDrivingProcessor // car #2
    {
        int ActualSpeed { get; }

        void IncreaseSpeedTo(int speed);

        void ReduceSpeed(int speed);
        double ActualConsumption { get; } // car #3
        void EngineStart(); // car #3
        void EngineStop(); // car #3
    }
}

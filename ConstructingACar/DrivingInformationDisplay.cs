using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
    {
        private readonly IDrivingProcessor _drivingProcessor;
        public int ActualSpeed => _drivingProcessor.ActualSpeed;

        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
            _drivingProcessor = drivingProcessor;
        }
    }
}
using ConstructingACar.Interfaces;

namespace ConstructingACar
{
    public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
    {
        private IDrivingProcessor _drivingProcessor;
        public int ActualSpeed { get => _drivingProcessor.ActualSpeed; }

        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
            _drivingProcessor = drivingProcessor;
        }
    }
}
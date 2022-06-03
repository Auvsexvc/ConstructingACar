namespace ConstructingACar
{
    public static class Utils
    {
        public static double ConvertToKMPS(int speed) => speed / 3600.0;

        public static double ConvertToKMPS(double speed) => speed / 3600.0;
    }
}
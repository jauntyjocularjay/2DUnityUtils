
namespace DMBTools
{
    public static class TimeUnit
    /* @class A static class that provides easy access to conversion of time units in miliseconds */
    {
        public static int Second = 1000;
        public static int Minute =   60 * TimeUnit.Second;
        public static int Hour   =   60 * TimeUnit.Minute;
        public static int Day    =   24 * TimeUnit.Hour;
        public static int Week   =    7 * TimeUnit.Day;
    }
}
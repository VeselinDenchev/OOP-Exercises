namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Constants
{
    public static class Constant
    {
        public const double AGGRESIVE_DRIVER_FUEL_CONSUMPTION_PER_KM = 2.7;
        public const double AGGRESIVE_DRIVER_SPEED_MULTIPLIER = 1.3;

        public const double ENDURACE_DRIVER_FUEL_CONSUMPTION_PER_KM = 1.5;

        public const double INITIAL_TOTAL_TIME = 0;

        public const double FUEL_TANK_MAX_CAPACITY = 160;
        public const string FUEL_AMOUNT_BELOW_ZERO_EXCEPTION = "Driver cannot continue the race!";

        public const double TYRE_DEGRADATION_STARTING_POINTS = 100;
        public const double HARD_TYRE_BLOWING_UP_DEGRADATION = 0;
        public const double ULTRASOFT_TYRE_BLOWING_UP_DEGRADATION = 30;
        
        public const string GRIP_NOT_POSITIVE_EXCEPTION = "Grip must be positive!";

        public const string NO_TIME_EXCEPTION = "There is no time! On lap ";

        public const string TYRE_BLOWING_UP_DEGRADATION_MESSAGE = "Blown tyre";
        public const string OUT_OF_FUEL_MESSAGE = "Out of fuel";
        public const string CRASH_MESSAGE = "Crashed";

        public const int OVERTAKING_TIME_INTERVAL = 2;
        public const int SPECIAL_CASES_OVERTAKING_TIME_INTERVAL = 3;

        public const double PITSTOP_TIME = 20;
    }
}

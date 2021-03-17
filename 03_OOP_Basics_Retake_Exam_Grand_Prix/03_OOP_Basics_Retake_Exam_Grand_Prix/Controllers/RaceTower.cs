namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Constants;
    using Factories;
    using Models.Drivers;
    using Models.Tyres;

    public class RaceTower
    {
        private DriverFactory driverFactory;
        private List<Driver> drivers;
        private List<Driver> dnfDrivers;
        private List<Driver> standings;
        private int totalLaps;
        private int trackLength;
        private int currentLap;
        private string weather;
        private double totalTime;
        private bool hasEnded;

        private StringBuilder stringBuilder = new StringBuilder();

        public RaceTower()
        {
            this.driverFactory =  new DriverFactory();
            this.drivers = new List<Driver>();
            this.dnfDrivers = new List<Driver>();
            this.standings = new List<Driver>();
            this.TotalLaps = totalLaps;
            this.TrackLength = trackLength;
            this.CurrentLap = 0;
            this.Weather = "Sunny";
            this.TotalTime = totalTime;
            this.HasEnded = false;
        }

        public DriverFactory DriverFactory { get; private set; }
        public List<Driver> Drivers { get; private set; }
        public List<Driver> DnfDrivers { get; private set; }
        public List<Driver> Standings { get; private set; }
        public int TotalLaps { get; set; }
        public int TrackLength { get; private set; }
        public string Weather { get; private set; }
        public double TotalTime { get; private set; }
        public int CurrentLap { get; private set; }
        public bool HasEnded { get; set; }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.TotalLaps = lapsNumber;
            this.TrackLength = trackLength;
        }
        public void RegisterDriver(List<string> commandArgs)
        {
            Driver driver = driverFactory.Create(commandArgs);
            this.drivers.Add(driver);
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            string reasonToBox = commandArgs[0];
            string driverName = commandArgs[1];

            foreach (Driver driver in standings)
            {
                if (driverName == driver.Name)
                {
                    driver.TotalTime += Constant.PITSTOP_TIME;

                    if (reasonToBox == "ChangeTyres")
                    {
                        string tyreType = commandArgs[2];
                        double tyreHardness = double.Parse(commandArgs[3]);

                        if (tyreType == "Hard")
                        {
                            HardTyre hardTyre = new HardTyre(tyreType, tyreHardness);
                            driver.Car.Tyre = hardTyre;
                        }
                        else if (tyreType == "Ultrasoft")
                        {
                            double grip = double.Parse(commandArgs[4]);

                            UltrasoftTyre ultrasoftTyre = new UltrasoftTyre(tyreType, tyreHardness, grip);
                            driver.Car.Tyre = ultrasoftTyre;
                        }
                    }
                    else if (reasonToBox == "Refuel")
                    {
                        double fuelAmount = double.Parse(commandArgs[2]);

                        driver.Car.FuelAmount = fuelAmount;
                    }
                }
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            string lapInfo = string.Empty;
            int lapsToBeDriven = int.Parse(commandArgs[0]);
            int sumOfCurrentLapsAndLapsToBeDriven = this.CurrentLap + lapsToBeDriven;

            if (sumOfCurrentLapsAndLapsToBeDriven <= this.TotalLaps)
            {
                for (int i = 0; i < lapsToBeDriven; i++)
                {
                    if (i == 0)
                    {
                        foreach (Driver driver in drivers)
                        {
                            driver.UpdateDriverTotalTime(this.TrackLength);
                            this.standings = this.drivers.OrderBy(x => x.TotalTime).ToList();
                            driver.CheckIfFuelIsEnough(this.TrackLength);
                            driver.Car.Tyre.ReduceTyreDegradation();
                            driver.CheckIfTyreIsBlown();
                        }
                    }
                    else
                    {
                        foreach (Driver driver in standings)
                        {
                            driver.UpdateDriverTotalTime(this.TrackLength);
                            this.standings = this.standings.OrderBy(x => x.TotalTime).ToList();
                            driver.CheckIfFuelIsEnough(this.TrackLength);
                            driver.Car.Tyre.ReduceTyreDegradation();
                            driver.CheckIfTyreIsBlown();
                        }
                    }

                    for (int j = this.standings.Count - 1; j >= 0; j--)
                    {
                        bool isLeader = j == 0;
                        if (isLeader)
                        {
                            break;
                        }

                        string currentDriverType = this.standings[j].Type;
                        string currentDriverTyresType = this.standings[j].Car.Tyre.Name;
                        double currentDriverTotalTime = this.standings[j].TotalTime;

                        double previousDriverTotalTime = this.standings[j - 1].TotalTime;

                        if (standings[j].ReasonForDnf == null)
                        {
                            if (((currentDriverType == "Aggressive" && currentDriverTyresType == "Ultrasoft" && this.Weather == "Foggy") ||
                            (currentDriverType == "Endurance" && currentDriverTyresType == "Hard" && this.Weather == "Rainy"))
                            && (currentDriverTotalTime - previousDriverTotalTime <= Constant.SPECIAL_CASES_OVERTAKING_TIME_INTERVAL))
                            {
                                this.standings[j].ReasonForDnf = Constant.CRASH_MESSAGE;

                                previousDriverTotalTime -= Constant.SPECIAL_CASES_OVERTAKING_TIME_INTERVAL;

                                continue;
                            }

                            if (currentDriverTotalTime - previousDriverTotalTime <= Constant.OVERTAKING_TIME_INTERVAL)
                            {
                                currentDriverTotalTime -= Constant.OVERTAKING_TIME_INTERVAL;
                                previousDriverTotalTime += Constant.OVERTAKING_TIME_INTERVAL;
                            }
                        }
                    }

                    for (int j = this.standings.Count - 1; j >= 0; j--)
                    {
                        if (standings[j].ReasonForDnf != null)
                        {
                            if (this.standings[j].DidNotFinish)
                            {
                                continue;
                            }
                            this.standings[j].DidNotFinish = true;
                            dnfDrivers.Add(standings[j]);
                            standings.RemoveAt(j);
                        }
                    }

                    this.standings = this.standings.OrderBy(x => x.TotalTime).ToList();
                }
                this.CurrentLap += lapsToBeDriven;

                if (sumOfCurrentLapsAndLapsToBeDriven == this.TotalLaps)
                {
                    Driver winner = standings.First();
                    lapInfo = $"{winner.Name} wins the race for {Math.Round(winner.TotalTime, 3)} seconds.";

                    this.HasEnded = true;
                }
                else
                {
                    lapInfo = $"Lap {this.CurrentLap} / {this.TotalLaps}";
                }
            }
            else
            {
                lapInfo = Constant.NO_TIME_EXCEPTION + $"{this.CurrentLap}.";
            }

            return lapInfo;
        }

        public string GetLeaderboard()
        {
            this.stringBuilder.Clear();

            for (int i = 0; i < this.standings.Count; i++)
            {
                if (this.standings[i].DidNotFinish == false)
                {
                    stringBuilder.AppendLine($"{i + 1} {this.standings[i].Name} {Math.Round(this.standings[i].TotalTime, 3)}");
                }
            }

            for (int i = 0; i < this.dnfDrivers.Count; i++)
            {
                stringBuilder.AppendLine($"{i + this.standings.Count + 1} {this.dnfDrivers[i].Name} {this.dnfDrivers[i].ReasonForDnf}");
            }

            string leaderboard = stringBuilder.ToString().TrimEnd();

            return leaderboard;
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            this.Weather = commandArgs[0];
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace HealthyLifestyle
{
    public partial class Users
    {
        /// <summary>
        /// Расчет общего количества съеденных калорий за день
        /// </summary>
        public double CaloriesInDay
        {
            get
            {
                DateTime dateTime = new DateTime();
                dateTime = DateTime.Today;
                List<DailyRation> dailyRation = DB.entities.DailyRation.Where(x => x.Date == dateTime &&  x.UserId == UserId).ToList();
                double remainingCalories = 0;
                double cal = Convert.ToDouble(Calories);
                for (int i = 0; i < dailyRation.Count; i++)
                {
                    remainingCalories +=  (double)dailyRation[i].Calories;
                }
                return remainingCalories;
            }
        }

        double RSK;
        /// <summary>
        /// Расчет калорий на денб, исходя из параметров
        /// </summary>
        public double CaloriesUsers
        {
            get
            {
                if (GenderId == 2)
                {
                    double c = 10 * Convert.ToDouble(Height);
                    double cc = 6.25 * Convert.ToDouble(Weight);
                    double ccc = 5 * Convert.ToDouble(DateOfBirth);
                    RSK = c + cc - ccc - 161;
                    if (ActivityId == 1)
                    {
                        RSK = RSK * 1.2;
                    }
                    else if (ActivityId == 2)
                    {
                        RSK = RSK * 1.375;
                    }
                    else if (ActivityId == 3)
                    {
                        RSK = RSK * 1.55;
                    }
                    else if (ActivityId == 4)
                    {
                        RSK = RSK * 1.725;
                    }
                    else
                    {
                        RSK = RSK * 1.9;
                    }

                    if (GoalId == 1)
                    {
                        double percent = RSK / 100;
                        RSK = RSK - (percent * 20);
                        return RSK;
                    }
                    else if (GoalId == 2)
                    {
                        double percent = RSK / 100;
                        RSK = RSK + (percent * 20);
                        return RSK;
                    }
                    else
                    {
                        return RSK;
                    }
                }
                else
                {
                    double c = 10 * Convert.ToDouble(Height);
                    double cc = 6.25 * Convert.ToDouble(Weight);
                    double ccc = 5 * Convert.ToDouble(DateOfBirth);
                    RSK = c + cc - ccc + 5;
                    if (ActivityId == 1)
                    {
                        RSK = RSK * 1.2;
                    }
                    else if (ActivityId == 2)
                    {
                        RSK = RSK * 1.375;
                    }
                    else if (ActivityId == 3)
                    {
                        RSK = RSK * 1.55;
                    }
                    else if (ActivityId == 4)
                    {
                        RSK = RSK * 1.725;
                    }
                    else
                    {
                        RSK = RSK * 1.9;
                    }

                    if (GoalId == 1)
                    {
                        double percent = RSK / 100;
                        RSK = RSK - (percent * 20);
                        return RSK;
                    }
                    else if (GoalId == 2)
                    {
                        double percent = RSK / 100;
                        RSK = RSK + (percent * 20);
                        return RSK;
                    }
                    else
                    {
                        return RSK;
                    }
                }
            }
        }

        //public double FatsCarbohydratesSquirrels()
        //{
        //    if(GoalId == )
        //}

    }
}

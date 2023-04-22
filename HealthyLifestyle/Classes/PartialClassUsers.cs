using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public partial class Users
    {
        public string CaloriesUsers
        {
            get
            {
                if (GenderId == 2)
                {
                    double c = 10 * Convert.ToDouble(Height);
                    double cc = 6.25 * Convert.ToDouble(Weight);
                    double ccc = 5 * Convert.ToDouble(DateOfBirth);
                    double RSK = c + cc - ccc - 161;
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
                        double calories = RSK - (percent * 20);
                        return Convert.ToString(calories);
                    }
                    else if (GoalId == 2)
                    {
                        double percent = RSK / 100;
                        double calories = RSK + (percent * 20);
                        return Convert.ToString(calories);
                    }
                    else
                    {
                        return Convert.ToString(RSK);
                    }
                }
                else
                {
                    double c = 10 * Convert.ToDouble(Height);
                    double cc = 6.25 * Convert.ToDouble(Weight);
                    double ccc = 5 * Convert.ToDouble(DateOfBirth);
                    double RSK = c + cc - ccc - 161;
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
                        double calories = RSK - (percent * 20);
                        return Convert.ToString(calories);
                    }
                    else if (GoalId == 2)
                    {
                        double percent = RSK / 100;
                        double calories = RSK + (percent * 20);
                        return Convert.ToString(calories);
                    }
                    else
                    {
                        return Convert.ToString(RSK);
                    }
                }
            }
        }
    }
}

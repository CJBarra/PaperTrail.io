using System;
using System.Collections.Generic;
using PaperTrail.Data.Models;

namespace PaperTrail.Services
{
    public class DataHelpers
    {
        public static IEnumerable<string> SimplifyBusinessHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach (var time in branchHours)
            {
                var day = SimplifyDay(time.DayOfWeek);
                var openTime = SimplifyTime(time.OpenHours);
                var closeTime = SimplifyTime(time.ClosedHours);

                var timeEntry = $"{day} {openTime} to {closeTime}";
                hours.Add(timeEntry);
            }
            return hours;
        }

        private static object SimplifyTime(int time)
        {
            return TimeSpan.FromHours(time).ToString("hh':'mm");
        }

        public static string SimplifyDay(int number)
        {
            // 1 correlates to -> 'Sunday' in database, so subtract 1 from number
            // to display correctly.
            return Enum.GetName(typeof(DayOfWeek), number - 1);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sadklouds.ExcerciseTracker.UserInpit
{
    public class Validator
    {
        public static bool IsValid(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            foreach (char c in id)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public static bool IsValidDateFormat(string date) => DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);

        public static bool IsValidEndDate(string endDate, DateTime startTime) => DateTime.ParseExact(endDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None) > startTime;
    }
}

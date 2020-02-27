using System;

namespace BankAccountApp
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        private const string CurrentDateFormat = "MM/dd/yyyy";

        public string FormattedCurrentDate => Today().ToString(CurrentDateFormat);

        protected virtual DateTime Today()
        {
            return DateTime.Today;
        }
    }
}
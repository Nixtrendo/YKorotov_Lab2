using System;

namespace YKorotov_Lab3
{
    class DatePastException : Exception
    {
        private readonly string _msg;
        private readonly DateTime _pastDate;

        public DatePastException(DateTime bDate)
        {
            _pastDate = bDate;
            _msg = $"Error. Can't input too old date. Date: {_pastDate}";
        }
        public override string Message
        {
            get { return _msg; }
        }
    }
}

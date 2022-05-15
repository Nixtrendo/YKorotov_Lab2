using System;

namespace YKorotov_Lab3
{
    class DateFutureException : Exception
    {
        private string _msg;
        private DateTime _futureDate;


        public DateFutureException(DateTime bDate)
        {
            _futureDate = bDate;
            _msg = $"Error: Can't input future date. Date: {_futureDate}";
        }

        public override string Message
        {
            get { return _msg; }
        }
    }
}

using System;

namespace YKorotov_Lab3
{
    internal class Person
    {
        private string _firstName;
        private string _lastName;
        private string _eMail;
        private DateTime _birthday;

        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;

        public Person(string firstName, string lastName, string eMail, DateTime dateOfBirthday)
        {
            _firstName = firstName;
            _lastName = lastName;
            _eMail = eMail;
            _birthday = dateOfBirthday;
            _isAdult = IsAdult();
            _sunSign = SunSign();
            _chineseSign = ChineseSign();

            IsValidDate(dateOfBirthday);
            IsValidEmail(eMail);
        }

        public Person(string firstName, string lastName, string eMail)
        {
            _firstName = firstName;
            _lastName = lastName;
            _eMail = eMail;
            _birthday = DateTime.Now;
            IsValidEmail(eMail);
        }

        public Person(string firstName, string lastName, DateTime dateOfBirthday)
        {
            _firstName = firstName;
            _lastName = lastName;
            _eMail = "";
            _birthday = dateOfBirthday;


            IsValidDate(dateOfBirthday);
        }

        public bool GetIsAdult
        {
            get { return _isAdult; }
        }

        public string GetSunSign
        {
            get { return _sunSign; }
        }

        public string GetChineseSign
        {
            get { return _chineseSign; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _eMail; }
            set
            {
                IsValidEmail(this._eMail);
                _eMail = value;
            }
        }

        public DateTime DateOfBirthday
        {
            get { return _birthday; }
            set {
                IsValidDate(this._birthday);
                _birthday = value;
            } 
        }
        private bool IsAdult()
        {
            if (DateTime.Today.DayOfYear < _birthday.DayOfYear)
                return DateTime.Today.Year - _birthday.Year - 1 >= 18;
            else
                return DateTime.Today.Year - _birthday.Year >= 18;  
        }

        private string ChineseSign()
        {
            string[] chineseSign = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            return chineseSign[(_birthday.Year + 8) % 12];       
        }

        private string SunSign()
        {
            string[] sunSign = { "Ram", "Bull", "Twins", "Crab", "Lion", "Virgin", "Scales", "Scorpion", "Archer", "Mountain Sea-Goat", "Water Bearer", "Fish" };
            int day = _birthday.Day;
            switch (_birthday.Month)
            {
                case 1:
                    return sunSign[day <= 20 ? 9 : 10];
                case 2:
                    return sunSign[day <= 19 ? 10 : 11];
                case 3:
                    return sunSign[day <= 20 ? 11 : 0];
                case 4:
                    return sunSign[day <= 20 ? 0 : 1];
                case 5:
                    return sunSign[day <= 20 ? 1 : 2];
                case 6:
                    return sunSign[day <= 20 ? 2 : 3];
                case 7:
                    return sunSign[day <= 21 ? 3 : 4];
                case 8:
                    return sunSign[day <= 22 ? 4 : 5];
                case 9:
                    return sunSign[day <= 21 ? 5 : 6];
                case 10:
                    return sunSign[day <= 21 ? 6 : 7];
                case 11:
                    return sunSign[day <= 21 ? 7 : 8];
                case 12:
                    return sunSign[day <= 21 ? 8 : 9];
                default:
                    return sunSign[0];
            }
        }

        private void IsValidDate(DateTime dateOfBirthday)
        {
            if (DateTime.Today.Year - dateOfBirthday.Year >= 135)
                throw new DatePastException(dateOfBirthday);
            if (dateOfBirthday > DateTime.Today)
                throw new DateFutureException(dateOfBirthday);
        }

        public void IsValidEmail(string eMail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(eMail);
            }
            catch
            {
                throw new EMailException("Incorrect e-mail: "+ eMail);
            }
        }
    }
}
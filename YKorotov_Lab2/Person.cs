using System;

namespace YKorotov_Lab2
{
    internal class Person
    {
        private string _firstName;
        private string _lastName;
        private string _eMail;
        private DateTime _dateOfBirthday;

        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;

        public Person(string firstName, string lastName, string eMail, DateTime dateOfBirthday)
        {
            _firstName = firstName;
            _lastName = lastName;
            _eMail = eMail;
            _dateOfBirthday = dateOfBirthday;
            _isAdult = IsAdult();
            _sunSign = SunSign();
            _chineseSign = ChineseSign();
        }
        public Person(string firstName, string lastName, string eMail)
        {
            _firstName = firstName;
            _lastName = lastName;
            _eMail = eMail;
            _dateOfBirthday = DateTime.Now;
        }

        public Person(string firstName, string lastName, DateTime dateOfBirthday)
        {
            _firstName = firstName;
            _lastName = lastName;
            _eMail = "";
            _dateOfBirthday = dateOfBirthday;
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
                _eMail = value;
            }
        }

        public DateTime DateOfBirthday
        {
            get { return _dateOfBirthday; }
            set {
                _dateOfBirthday = value;
            } 
        }

        private bool IsAdult()
        {
            int _age;

            if (DateTime.Today.DayOfYear < _dateOfBirthday.DayOfYear)
            {
                _age =  DateTime.Today.Year - _dateOfBirthday.Year - 1;
            }
            _age = DateTime.Today.Year - _dateOfBirthday.Year;

            return _age >= 18;           
        }

        private string ChineseSign()
        {
            string[] chineseSign = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            return chineseSign[(_dateOfBirthday.Year + 8) % 12];       
        }

        private string SunSign()
        {
            string[] sunSign = { "Ram", "Bull", "Twins", "Crab", "Lion", "Virgin", "Scales", "Scorpion", "Archer", "Mountain Sea-Goat", "Water Bearer", "Fish" };
            int day = _dateOfBirthday.Day;
            int sunSignNumber;
            switch (_dateOfBirthday.Month)
            {
                case 1:
                    sunSignNumber = day <= 20 ? 9 : 10;
                    break;
                case 2:
                    sunSignNumber = day <= 19 ? 10 : 11;
                    break;
                case 3:
                    sunSignNumber = day <= 20 ? 11 : 0;
                    break;
                case 4:
                    sunSignNumber = day <= 20 ? 0 : 1;
                    break;
                case 5:
                    sunSignNumber = day <= 20 ? 1 : 2;
                    break;
                case 6:
                    sunSignNumber = day <= 20 ? 2 : 3;
                    break;
                case 7:
                    sunSignNumber = day <= 21 ? 3 : 4;
                    break;
                case 8:
                    sunSignNumber = day <= 22 ? 4 : 5;
                    break;
                case 9:
                    sunSignNumber = day <= 21 ? 5 : 6;
                    break;
                case 10:
                    sunSignNumber = day <= 21 ? 6 : 7;
                    break;
                case 11:
                    sunSignNumber = day <= 21 ? 7 : 8;
                    break;
                case 12:
                    sunSignNumber = day <= 21 ? 8 : 9;
                    break;
                default:
                    sunSignNumber = 0;
                    break;
            }

            return sunSign[sunSignNumber];
        }

    }
}

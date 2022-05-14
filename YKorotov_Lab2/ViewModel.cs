using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace YKorotov_Lab2
{
    internal class ViewModel: INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _eMail;
        private DateTime _dateOfBirthday;
        private RelayCommand _signInCom;
        private readonly Action _signInAct;


        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string EMail
        {
            get { return _eMail; }
            set
            {
                _eMail = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirthday
        {
            get { return _dateOfBirthday; }
            set
            {
                _dateOfBirthday = value;
                OnPropertyChanged();
            }
        }

        private bool ValidDate(DateTime date)
        {
            return date < DateTime.Today && date.Year > 1920;
        }
        public static bool isValidEmail(string eMail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(eMail);
                return addr.Address == eMail;
            }
            catch
            {
                return false;
            }
        }

        public RelayCommand CloseCommand
        {
            get
            {
                return _signInCom ?? (_signInCom = new RelayCommand(SignInImpl, o => !String.IsNullOrWhiteSpace(_firstName) && !String.IsNullOrWhiteSpace(_lastName) && isValidEmail(_eMail) && ValidDate(_dateOfBirthday)));

            }
        }

        internal ViewModel(Action signInAct)
        {
            _signInAct = signInAct;
        }

        private async void SignInImpl(object o)
        {

            await Task.Run((() =>
            {
            }));

            _signInAct.Invoke();
        }
        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

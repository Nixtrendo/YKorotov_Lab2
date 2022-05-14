using System.Windows;
using System;
namespace YKorotov_Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel(ShowResultView);
        }

        private void ShowResultView()
        {
            ViewModel data = DataContext as ViewModel;
            if (data != null)
            {
                    Person person = new Person(data.FirstName, data.LastName, data.EMail, data.DateOfBirthday);
                    if(DateTime.Today.DayOfYear == person.DateOfBirthday.DayOfYear)
                        MessageBox.Show("Happy Birthday and have a nice day!");
                    MessageBox.Show($"First name: {person.FirstName}\n" + $"Last name: {person.LastName}\n" + $"E-mail: {person.Email}\n" + $"Date of birthday: {person.DateOfBirthday}\n" + $"Adult: {person.GetIsAdult}\n" + $"Sun Sign: {person.GetSunSign}\n" + $"Chinese Sign: {person.GetChineseSign}");
            }

        }
    }
}

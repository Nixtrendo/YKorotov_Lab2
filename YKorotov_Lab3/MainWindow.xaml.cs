using System.Windows;
using System;
namespace YKorotov_Lab3
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
            if (DataContext is ViewModel data)
            {
                try
                {
                    Person person = new Person(data.FirstName, data.LastName, data.EMail, data.DateOfBirthday);
                    if (DateTime.Today.DayOfYear == person.DateOfBirthday.DayOfYear)
                        MessageBox.Show("Happy Birthday and have a nice day!");
                    MessageBox.Show($"Full name: {person.FirstName}" + $" {person.LastName}\n" + $"Date of birthday: {person.DateOfBirthday.ToString("dd/MM/yyyy")}\n" + $"E-mail: {person.Email}\n"   + $"Sun Sign: {person.GetSunSign}\n" + $"Chinese Sign: {person.GetChineseSign}\n" + $"Is Adult: {person.GetIsAdult}");

                }
                catch (EMailException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (DateFutureException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (DatePastException e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }
    }
}

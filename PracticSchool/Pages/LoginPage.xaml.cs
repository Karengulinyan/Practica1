using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PracticSchool.AppData;
using PracticSchool.Pages;

namespace PracticSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        public static bool Admin = false;


        public void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((Log.Text == "karen") && (Pass.Password == "123"))
            {
                Log.Text = "";
                Pass.Password = "";
                Admin = true;
                MessageBox.Show("Вы вошли как администратор", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Nav.MainFrame.Navigate(new MainPage());
            }
            else
            {
                Log.Text = "";
                Pass.Password = "";
                Admin = false;
                MessageBox.Show("Пароль не верный");
            }
        }

        public void BtnGost_Click(object sender, RoutedEventArgs e)
        {
            Log.Text = "";
            Pass.Password = "";
            Admin = false; //false
            MessageBox.Show("Вы вошли как гость", "", MessageBoxButton.OK, MessageBoxImage.Information);
            Nav.MainFrame.Navigate(new MainPage());
        }

    }
}

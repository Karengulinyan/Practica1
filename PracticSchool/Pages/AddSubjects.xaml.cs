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

namespace PracticSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddSubjects.xaml
    /// </summary>
    public partial class AddSubjects : Page
    {
        Subjects sub;
        bool CheckNew;
        public AddSubjects(Subjects p)
        {
            InitializeComponent();
            if (p == null)
            {
                p = new Subjects();
                CheckNew = true;
            }
            else
                CheckNew = false;
            DataContext = sub = p;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {
                Connect.Contex.Subjects.Add(sub);
            }
            try
            {
                Connect.Contex.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
    

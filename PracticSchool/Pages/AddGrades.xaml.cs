using PracticSchool.AppData;
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

namespace PracticSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddGrades.xaml
    /// </summary>
    public partial class AddGrades : Page
    {
        Grades grade;
        bool CheckNew;
        public AddGrades(Grades p)
        {
            InitializeComponent();
            StudentsLV.ItemsSource = Connect.Contex.Students.ToList();
            StudentsLV1.ItemsSource = Connect.Contex.Students.ToList();
            SubjectsLV.ItemsSource = Connect.Contex.Subjects.ToList();

            if (p == null)
            {
                p = new Grades();
                CheckNew = true;
            }
            else
                CheckNew = false;
            DataContext = grade = p;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {
                Connect.Contex.Grades.Add(grade);
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

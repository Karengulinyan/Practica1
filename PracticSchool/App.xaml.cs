using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PracticSchool
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            SplashScreenWindow splashScreen = new SplashScreenWindow();
            splashScreen.Show();


            Task.Run(() =>
            {

                for (int i = 0; i <= 100; i++)
                {

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        splashScreen.SetStatus($"Загрузка: {i}%");
                        splashScreen.SetProgress(i);
                    });

                    Thread.Sleep(20);
                 
                }
             

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MainWindow main = new MainWindow();
                    main.Show();

                    splashScreen.Close();
                });
            });
          
        }
     
    }
}

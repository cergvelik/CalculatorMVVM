using System.Windows;
using Calculator.Classes.ViewModel;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow app = new MainWindow();
            this.MainWindow = app;
            CalculatorViewModel context = new CalculatorViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}

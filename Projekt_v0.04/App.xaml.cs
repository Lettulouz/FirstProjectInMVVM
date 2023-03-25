using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;
using Projekt_v0._04.Stores;

using Projekt_v0._04.ViewModels;
using NavigationService = Projekt_v0._04.Services.NavigationService;


namespace Projekt_v0._04
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateMainBrowserViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore),
            };
            MainWindow.Show();    
            base.OnStartup(e);
        }

        private MainBrowserViewModel CreateMainBrowserViewModel()
        {
            Login login = new Login("Gość","");
            login.CreateAccount(login);
            return new MainBrowserViewModel(new NavigationService(_navigationStore), login);
        }
    }
}
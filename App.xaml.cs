using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationMVVM
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    //fields
    private readonly AccountStore _accountStore;
    private readonly NavigationStore _navigationStore;
    private readonly NavigationBarViewModel _navigationBarViewModel;

    //constructor
    public App()
    {
      _accountStore  = new AccountStore();
      _navigationStore = new NavigationStore();
      _navigationBarViewModel = new NavigationBarViewModel(
        _accountStore,
        CreateHomeNavigationService(),
        CreateAccountNavigationService(),
        CreateLoginNavigationService());
    }
    protected override void OnStartup(StartupEventArgs e)
    {
      

      NavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
      homeNavigationService.Navigate();

      MainWindow = new MainWindow()
      {
        DataContext = new MainViewModel(_navigationStore)
      };
      MainWindow.Show();

      base.OnStartup(e);
    }
    private NavigationService<HomeViewModel> CreateHomeNavigationService()
    {
      return new NavigationService<HomeViewModel>(
        _navigationStore,
        () => new HomeViewModel(_navigationBarViewModel, CreateLoginNavigationService()));
    }
    private NavigationService<LoginViewModel> CreateLoginNavigationService()
    {
      return new NavigationService<LoginViewModel>(
        _navigationStore,
        () => new LoginViewModel(_accountStore, CreateAccountNavigationService()));
    }

    private NavigationService<AccountViewModel> CreateAccountNavigationService()
    {
      return new NavigationService<AccountViewModel>(
        _navigationStore,
        () => new AccountViewModel(_navigationBarViewModel, _accountStore, CreateHomeNavigationService()));
    }



  }
}

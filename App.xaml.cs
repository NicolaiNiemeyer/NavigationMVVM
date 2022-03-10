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


    //constructor
    public App()
    {
      _accountStore = new AccountStore();
      _navigationStore = new NavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      INavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
      homeNavigationService.Navigate();

      MainWindow = new MainWindow()
      {
        DataContext = new MainViewModel(_navigationStore)
      };
      MainWindow.Show();

      base.OnStartup(e);
    }
    private INavigationService<HomeViewModel> CreateHomeNavigationService()
    {
      return new LayoutNavigationService<HomeViewModel>(
        _navigationStore,
        () => new HomeViewModel(
          CreateLoginNavigationService()),
          CreateNavigationBarViewModel);
    }
    private INavigationService<LoginViewModel> CreateLoginNavigationService()
    {
      return new NavigationService<LoginViewModel>(
        _navigationStore,
        () => new LoginViewModel(
          _accountStore, 
          CreateAccountNavigationService()));
    }

    private INavigationService<AccountViewModel> CreateAccountNavigationService()
    {
      return new LayoutNavigationService<AccountViewModel>(
        _navigationStore,
        () => new AccountViewModel(
          _accountStore, 
          CreateHomeNavigationService()),
          CreateNavigationBarViewModel);
    }

    private NavigationBarViewModel CreateNavigationBarViewModel()
    {
      return new NavigationBarViewModel(
        _accountStore,
        CreateHomeNavigationService(),
        CreateAccountNavigationService(),
        CreateLoginNavigationService());
    }

  }
}

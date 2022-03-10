using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
  public class NavigationBarViewModel : ViewModelBase
  {
    private readonly AccountStore _accountStore;

    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateAccountCommand { get; }
    public ICommand NavigateLoginCommand { get; }

    public bool IsLoggedIn => _accountStore.IsLoggedIn;

    public NavigationBarViewModel(
      AccountStore accountStore,
      NavigationService<HomeViewModel> homeNavigationService, 
      NavigationService<AccountViewModel> AccountNavigationService, 
      NavigationService<LoginViewModel> LoginNavigationService)
    {
      _accountStore = accountStore;
      NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
      NavigateAccountCommand = new NavigateCommand<AccountViewModel>(AccountNavigationService);
      NavigateLoginCommand = new NavigateCommand<LoginViewModel>(LoginNavigationService);
    }
  }
}

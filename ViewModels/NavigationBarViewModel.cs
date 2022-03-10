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
    public ICommand LogoutCommand { get; }

    public bool IsLoggedIn => _accountStore.IsLoggedIn;

    public NavigationBarViewModel(
      AccountStore accountStore,
      INavigationService<HomeViewModel> homeNavigationService,
      INavigationService<AccountViewModel> AccountNavigationService,
      INavigationService<LoginViewModel> LoginNavigationService)
    {
      _accountStore = accountStore;
      NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
      NavigateAccountCommand = new NavigateCommand<AccountViewModel>(AccountNavigationService);
      NavigateLoginCommand = new NavigateCommand<LoginViewModel>(LoginNavigationService);
      LogoutCommand = new LogoutCommand(_accountStore);

      //reraise PropertyChanged for IsLoggedIn whenever user is logged out
      _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
    }

    private void OnCurrentAccountChanged()
    {
      //reevaluates if the logout and account button will show
      OnPropertyChanged(nameof(IsLoggedIn));
    }

    public override void Dispose()
    {
      _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
      base.Dispose();
    }
  }
}

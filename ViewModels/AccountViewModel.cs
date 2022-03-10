using NavigationMVVM.Commands;
using NavigationMVVM.Models;
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
  public class AccountViewModel : ViewModelBase
  {
    private readonly AccountStore _accountStore;

    public string Username => _accountStore.CurrentAccount?.Username;
    
    public ICommand NavigateHomeCommand { get; }

    public AccountViewModel(AccountStore accountStore, INavigationService<HomeViewModel> homeNavigationService)
    {
      _accountStore = accountStore;
      NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);

      //subscribes to account change event
      _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
    }

    //raised when account changes
    private void OnCurrentAccountChanged()
    {
      OnPropertyChanged(nameof(Username));
    }

    public override void Dispose()
    {
      _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
      base.Dispose();
    }
  }
}

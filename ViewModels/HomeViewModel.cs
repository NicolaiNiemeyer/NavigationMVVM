using NavigationMVVM.Commands;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
  public class HomeViewModel : ViewModelBase
  {
    public string WelcomeMessage => "Welcome to my app";

    public ICommand NavigateAccountCommand { get; }

    public HomeViewModel(NavigationStore navigationStore)
    {
      NavigateAccountCommand = new NavigateCommand<AccountViewModel>(
        navigationStore,
        () => new AccountViewModel(navigationStore));
    }
  }
}

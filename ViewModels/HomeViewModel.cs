using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace NavigationMVVM.ViewModels
{
  public class HomeViewModel : ViewModelBase
  {
    public string WelcomeMessage => "Welcome to my app";

    public ICommand NavigateAccountCommand { get; }

    public HomeViewModel(NavigationStore navigationStore)
    {
      NavigateAccountCommand = new NavigateCommand<LoginViewModel>(new NavigationService<LoginViewModel>(
        navigationStore, () => new LoginViewModel(navigationStore)));

    }
  }
}

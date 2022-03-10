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

    public ICommand NavigateLoginCommand { get; }

    public HomeViewModel(INavigationService<LoginViewModel> loginNavigationService)
    {
      NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
    }
  }
}

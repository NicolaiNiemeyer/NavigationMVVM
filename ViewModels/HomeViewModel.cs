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

    public NavigationBarViewModel NavigationBarViewModel { get; }

    public ICommand NavigateLoginCommand { get; }

    public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService)
    {
      NavigationBarViewModel = navigationBarViewModel;

      NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);

    }
  }
}

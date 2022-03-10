using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Commands
{
  public class NavigateCommand<TViewModel> : CommandBase      //<TViewModel> is a generic type and it inherits from ViewModelBase
    where TViewModel : ViewModelBase
  {
    private readonly NavigationService<TViewModel> _navigationService;

    public NavigateCommand(NavigationService<TViewModel> navigationService)
    {
      _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
      //Navigates to whatever is configured in the NavigationService callback Func<TViewModel> to create a view model
      _navigationService.Navigate();
    }
  }
}

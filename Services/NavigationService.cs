using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Services
{
  //Navigating views goes through this service
  public class NavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase        //'where' constraint so that TViewModel inherits from ViewModelBase
  {
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    //ctor used for instanciating a view model
    public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    {
      _navigationStore = navigationStore;
      _createViewModel = createViewModel;
    }

    //Set current view model to selected view model
    public void Navigate()
    {
      _navigationStore.CurrentViewModel = _createViewModel();
    }
  }
}

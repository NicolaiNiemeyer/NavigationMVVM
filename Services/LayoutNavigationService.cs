using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Services
{
  //Enables navigation through an interface
  public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
  {
    //fields
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;
    private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;    //Turning the navbar view model into a Func turns the navbar into a generic instead of instanciating it only once

    //ctor
    public LayoutNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel, Func<NavigationBarViewModel> createNavigationBarViewModel)
    {
      _navigationStore = navigationStore;
      _createViewModel = createViewModel;
      _createNavigationBarViewModel = createNavigationBarViewModel;
    }

    //set the view model to the LayoutViewModel
    public void Navigate()
    {
      _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel());
    }
  }
}

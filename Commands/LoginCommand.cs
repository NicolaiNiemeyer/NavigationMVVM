using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Commands
{
  public class LoginCommand : CommandBase
  {
    private readonly LoginViewModel _viewModel;
    private readonly NavigationStore _navigationStore;
    public override void Execute(object parameter)
    {
      
    }
  }
}

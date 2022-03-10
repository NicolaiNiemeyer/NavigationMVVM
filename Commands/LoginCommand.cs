using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationMVVM.Commands
{
  public class LoginCommand : CommandBase
  {
    private readonly LoginViewModel _viewModel;
    private readonly NavigationService<AccountViewModel> _navigationService;    //The login command navigates to the account view model

    public LoginCommand(LoginViewModel viewModel, NavigationService<AccountViewModel> navigationService)
    {
      _viewModel = viewModel;
      _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
      MessageBox.Show($"Logging in {_viewModel.Username}...");
      //Navigates to the account view model
      _navigationService.Navigate();  
    }
  }
}

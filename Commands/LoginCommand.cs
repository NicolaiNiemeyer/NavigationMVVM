using NavigationMVVM.Models;
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
    private readonly AccountStore _accountStore;
    private readonly NavigationService<AccountViewModel> _navigationService;    //The login command navigates to the account view model

    public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, NavigationService<AccountViewModel> navigationService)
    {
      _viewModel = viewModel;
      _accountStore = accountStore;
      _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
      Account account = new Account()
      {
        Username = $"{_viewModel.Username}"
      };

      //set logged in account to CurrentAccount
      _accountStore.CurrentAccount = account;
      //Navigates to the account view model
      _navigationService.Navigate();  
    }
  }
}

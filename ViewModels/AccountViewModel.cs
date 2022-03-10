﻿using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
  public class AccountViewModel : ViewModelBase
  {
    public string Name => "SingletonSean";

    public ICommand NavigateHomeCommand { get; }

    public AccountViewModel(NavigationStore navigationStore)
    {
      NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
        navigationStore, () => new HomeViewModel(navigationStore)));
    }
  }
}

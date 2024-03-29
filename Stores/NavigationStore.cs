﻿using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Stores
{
  //NavigationStore that acts as a mediator between view models
  public class NavigationStore
  {
    public event Action CurrentViewModelChanged;

    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
      get => _currentViewModel;
      set
      {
        _currentViewModel?.Dispose();   //by setting ?, the Dispose function wont run on the first page when the application starts
        _currentViewModel = value;
        OnCurrentViewModelChanged();
      }
    }

    private void OnCurrentViewModelChanged()
    {
      CurrentViewModelChanged?.Invoke();
    }
  }
}

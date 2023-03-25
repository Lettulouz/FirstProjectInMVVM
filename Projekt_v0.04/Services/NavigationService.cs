using System;
using Projekt_v0._04.Models;
using Projekt_v0._04.Stores;
using Projekt_v0._04.ViewModels;

namespace Projekt_v0._04.Services;

public class NavigationService
{
    private readonly NavigationStore _navigationStore;

    public NavigationService(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }
    public void Navigate(ViewModelBase viewModelBase)
    {
        _navigationStore.CurrentViewModel = viewModelBase;
    }
}

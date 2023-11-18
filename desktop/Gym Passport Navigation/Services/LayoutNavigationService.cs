﻿using Gym_Passport_Navigation.State.Accounts;
using Gym_Passport_Navigation.Stores;
using Gym_Passport_Navigation.ViewModels;
using System;

namespace Gym_Passport_Navigation.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly IAccountStore _accountStore;
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;

        public LayoutNavigationService(IAccountStore accountStore, NavigationStore navigationStore,
            Func<TViewModel> createViewModel,
            Func<NavigationBarViewModel> createNavigationBarViewModel)
        {
            _accountStore = accountStore;
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_accountStore, _createNavigationBarViewModel(), _createViewModel());
        }
    }
}

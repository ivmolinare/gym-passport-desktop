﻿using Gym_Passport_Navigation.Commands;
using Gym_Passport_Navigation.Models;
using Gym_Passport_Navigation.Services;
using Gym_Passport_Navigation.Services.GymServices;
using Gym_Passport_Navigation.Services.ProfileServices;
using Gym_Passport_Navigation.State.Accounts;
using Gym_Passport_Navigation.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Gym_Passport_Navigation.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        private readonly IAccountStore _accountStore;
        private readonly IGymService _gymService;

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public ICommand GetClientsCommand { get; }

        public ClientsViewModel(IAccountStore accountStore, IGymService gymService)
        {
            _accountStore = accountStore;
            _gymService = gymService;
            GetClientsCommand = new GetClientsCommand(this, gymService, accountStore);
            GetClientsCommand.Execute(null);
        }
    }
}
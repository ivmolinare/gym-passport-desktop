﻿using GymPassport.Domain.Models;
using GymPassport.WPF.State.Clients;
using GymPassport.WPF.State.Navigators;
using GymPassport.WPF.ViewModels;

namespace GymPassport.WPF.Commands
{
    public class AddClientCommand : AsyncCommandBase
    {
        private readonly AddClientViewModel _addClientViewModel;
        private readonly ClientsStore _clientsStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddClientCommand(AddClientViewModel addClientViewModel, ClientsStore clientsStore, ModalNavigationStore modalNavigationStore)
        {
            _addClientViewModel = addClientViewModel;
            _clientsStore = clientsStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _addClientViewModel.ErrorMessage = null;
            _addClientViewModel.IsSubmitting = true;

            Client client = new Client
            {
                Name = _addClientViewModel.Name,
                Role = _addClientViewModel.Role,
                Username = _addClientViewModel.Username,
                Password = _addClientViewModel.Password,
            };

            try
            {
                await _clientsStore.Add(client);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                _addClientViewModel.ErrorMessage = "Error al añadir al cliente. Por favor, intentelo de nuevo.";
            }
            finally
            {
                _addClientViewModel.IsSubmitting = false;
            }
        }
    }
}

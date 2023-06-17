﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class ClientViewModel: INotifyPropertyChanged
    {
        public Client Model { get; set; }
        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        public ClientViewModel(Client client)
        {
            Model = client;
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
        }

        public ClientViewModel()
        {
            Model = new Client();
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
        }

        public void Add()
        {
            ClientService.Current.Add(Model);
        }

        public void Search()
        {
            NotifyPropertyChanged("Clients");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
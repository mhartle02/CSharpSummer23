﻿using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticePanther.MAUI.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public Employee Model { get; set; }


        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddProjectCommand { get; private set; }
        public ICommand ShowProjectsCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ExecuteDelete(int id)
        {
            EmployeeService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId={id}");
        }

        public void ExecuteAddProject()
        {
            AddOrUpdate(); // Save the employee so that we have an id to link the project to
                           // TODO: if we cancel the creation of this employee, we need to delete it on cancel.
            Shell.Current.GoToAsync($"//ProjectDetail?employeeId={Model.Id}");
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (e) => ExecuteDelete((e as EmployeeViewModel).Model.Id));
            EditCommand = new Command(
                (e) => ExecuteEdit((e as EmployeeViewModel).Model.Id));
        }

        public EmployeeViewModel(Employee employee)
        {
            Model = employee;
            SetupCommands();
        }

        public EmployeeViewModel(int employeeId)
        {
            if (employeeId == 0)
            {
                Model = new Employee();
            }
            else
            {
                Model = EmployeeService.Current.Get(employeeId);
            }
            SetupCommands();
        }

        public EmployeeViewModel()
        {
            Model = new Employee();
            SetupCommands();
        }

        public void AddOrUpdate()
        {
            EmployeeService.Current.AddOrUpdate(Model);
        }
    }
}

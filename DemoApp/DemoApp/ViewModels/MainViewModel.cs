using DemoApp.Models;
using DemoApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DemoApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Employee> _employeesList;

        public List<Employee> EmployeesList
        {
            get { return _employeesList; }
            set
            {
                _employeesList = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            var employeesServices = new EmployeesServices();
            EmployeesList = employeesServices.GetEmployee();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

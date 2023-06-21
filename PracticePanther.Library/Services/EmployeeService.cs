﻿
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class EmployeeService
    {
        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
        }

        private List<Employee> employees;

        private static EmployeeService? instance;

        public static EmployeeService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeService();
                }
                return instance;
            }
        }
        private EmployeeService()
        {
            employees = new List<Employee>
            {

            };
        }

        public void Delete(int id)
        {
            var employeeToDelete = Employees.FirstOrDefault(c => c.Id == id);
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }
        }

        public void Add(Employee e)
        {
            if (e.Id == 0)
            {
                //add
                e.Id = LastId + 1;
            }

            Employees.Add(e);
        }

        public Employee? Get(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }

        private int LastId
        {
            get
            {
                return Employees.Any() ? Employees.Select(e => e.Id).Max() : 0;
            }
        }


        public List<Employee> Search(string query)
        {


            return Employees.Where(e => e.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public void AddOrUpdate(Employee e)
        {
            if (e.Id == 0)
            {
                //add
                e.Id = LastId + 1;
                Employees.Add(e);
            }
        }
    }
}

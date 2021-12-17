using HealthyTeeth.POCO_Classes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTeeth.Services
{
    public class UserService
    {
        public readonly APIService apiService;
        private static UserService instance;
        private UserService() 
        {
            apiService = new APIService();
            restClient = new RestClient(apiService.apiConnection);
        }
        public static UserService Instance => instance ?? (instance = new UserService());
        public readonly RestClient restClient;
        public Employee Employee { get; private set; }
        public void SetEmployee(Employee employee)
        {
            Employee = employee;
        }
    }
}

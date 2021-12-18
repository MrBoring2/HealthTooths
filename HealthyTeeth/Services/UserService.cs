using HealthyTeeth.POCO_Classes;
using Microsoft.AspNetCore.SignalR.Client;
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
        private static UserService instance;
        public readonly APIService apiService;
        private UserService() 
        {
            apiService = new APIService();
            restClient = new RestClient(apiService.apiConnection);
        }
        public static UserService Instance => instance ?? (instance = new UserService());
        public readonly RestClient restClient;
        public HubConnection HubConnection { get; private set; }
        public Employee Employee { get; private set; }
        public void SetEmployee(Employee employee)
        {
            Employee = employee;
        }
        public void InitializeHubConnection()
        {
            HubConnection = new HubConnectionBuilder()
                .WithUrl($"{apiService.apiConnection}MainHub")
                .WithAutomaticReconnect()
                .Build();
        }
        public void Logout()
        {
            Employee = null;
        }
    }
}

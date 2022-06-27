
using HealthyToothsModels;
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
            RestClient = new RestClient(APIService.apiConnection);
        }
        public string Token { get; set; }

        public static UserService Instance => instance ?? (instance = new UserService());
        public RestClient RestClient { get; private set; }
        public HubConnection HubConnection { get; private set; }
        public Employee Employee { get; private set; }
        public void SetClient(string user_name, string full_name, int role_id, int user_id, string token)
        {
            Token = token;
            Employee = new Employee()
            {
                Login = user_name,
                RoleId = role_id,
                EmployeeId = user_id,
                FullName = full_name
            };
        }
        public void InitializeHubConnection()
        {
            HubConnection = new HubConnectionBuilder()
                .WithUrl($"{APIService.apiConnection}mainHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(Token);
                })
                .WithAutomaticReconnect()
                .Build();
        }
        public async void Logout()
        {
            Employee = null;
            await HubConnection.StopAsync();
        }
    }
}

using HealthyToothsModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTeeth.Services
{
    public class APIService
    {
        public const string apiConnection = "http://localhost:5556/";
        public APIService()
        {

        }
        public static Task<IRestResponse> Authorize(string login, string password)
        {
            try
            {
                RestRequest request = new RestRequest($"{apiConnection}token", Method.POST);
                request.AddJsonBody(new { login = login, password = password});
                var response = UserService.Instance.RestClient.ExecuteAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async static Task<IRestResponse> GetRequest(string url)
        {
            var response = await UserService.Instance.RestClient.ExecuteAsync(CreateRequest(url, Method.GET));
            return response;
        }
        public async static Task<IRestResponse> GetRequestWithParameter(string url, string parameterName, object parameter)
        {
            var response = await UserService.Instance.RestClient.ExecuteAsync(CreateRequestWithParameter(url, Method.GET, parameterName, parameter));
            return response;
        }
        public static Task<IRestResponse> GetRequest(string url, int id)
        {
            var response = UserService.Instance.RestClient.ExecuteAsync(CreateRequest(url, Method.GET, id));
            return response;
        }

        public async static Task<IRestResponse> PostRequest(string url, object data)
        {
            var response = await UserService.Instance.RestClient.ExecuteAsync(CreateRequest(url, Method.POST, data));
            return response;
        }
        public async static Task<IRestResponse> PostEmployeeRequest(string url, object data)
        {
            var response = await UserService.Instance.RestClient.ExecuteAsync(CreateRequestEmployee(url, Method.POST, data));
            return response;
        }
        public async static Task<IRestResponse> PostRequestWithParameter(string url, string parameterName, object parameter, object body)
        {
            var response = await UserService.Instance.RestClient.ExecuteAsync(CreateRequestWithParameterAndBody(url, Method.POST, parameterName, parameter, body));
            return response;
        }
        public async static Task<IRestResponse> DeleteRequest(string url, int id)
        {
            var response = await UserService.Instance.RestClient.ExecuteAsync(CreateRequest(url, Method.DELETE, id));
            return response;
        }
        public async static Task<IRestResponse> PutRequest(string url, int id, object data)
        {
            var response = await UserService.Instance.RestClient.ExecuteAsync(CreateRequest($"{url}/{id}", Method.PUT, data));
            return response;
        }
        public async static Task<IRestResponse> PutEmployeeRequest(string url, int id, object data)
        {
            var response = await UserService.Instance.RestClient.ExecuteAsync(CreateRequestEmployee($"{url}/{id}", Method.PUT, data));
            return response;
        }
        private static IRestRequest CreateRequest(string url, Method httpMethod)
        {
            var restReqeust = new RestRequest(url, httpMethod);
            restReqeust.AddHeader("Authorization", "Bearer " + UserService.Instance.Token);
            return restReqeust;
        }

        private static IRestRequest CreateRequest(string url, Method httpMethod, int id)
        {
            var restReqeust = new RestRequest($"{url}/{id}", httpMethod);
            restReqeust.AddHeader("Authorization", "Bearer " + UserService.Instance.Token);
            return restReqeust;
        }
        private static IRestRequest CreateRequestWithParameter(string url, Method httpMethod, string parameterName, object parameter)
        {
            var restReqeust = new RestRequest(url, httpMethod);
            restReqeust.AddHeader("Authorization", "Bearer " + UserService.Instance.Token);
            restReqeust.AddParameter(parameterName, parameter);
            return restReqeust;
        }
        private static IRestRequest CreateRequestWithParameterAndBody(string url, Method httpMethod, string parameterName, object parameter, object body)
        {
            var restReqeust = new RestRequest(url, httpMethod);
            restReqeust.AddHeader("Authorization", "Bearer " + UserService.Instance.Token);
            restReqeust.AddParameter(parameterName, parameter);
            restReqeust.AddJsonBody(body);      
            return restReqeust;
        }
        private static IRestRequest CreateRequest(string url, Method httpMethod, object data)
        {
            var restReqeust = new RestRequest(url, httpMethod);
            restReqeust.AddHeader("Authorization", "Bearer " + UserService.Instance.Token);
            restReqeust.AddJsonBody(data);
            return restReqeust;
        }
        private static IRestRequest CreateRequestEmployee(string url, Method httpMethod, object data)
        {
            var restReqeust = new RestRequest(url, httpMethod);
            restReqeust.AddHeader("Authorization", "Bearer " + UserService.Instance.Token);
            restReqeust.AddJsonBody(JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
            return restReqeust;
        }
    }
}

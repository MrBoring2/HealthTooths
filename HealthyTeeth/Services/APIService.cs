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
        public readonly string apiConnection = "http://localhost:5556/";
        public APIService()
        {

        }
        public async Task<IRestResponse> SendGetRequest(string requestUrl)
        {
            var request = new RestRequest(requestUrl, Method.GET);
            return await UserService.Instance.restClient.ExecuteAsync(request);
        }
        public async Task<IRestResponse> SendGetRequest(string requestUrl, object parameter)
        {
            var request = new RestRequest(requestUrl, Method.GET).AddParameter("doctorId", parameter);
            return await UserService.Instance.restClient.ExecuteAsync(request);
        }
        public async Task<IRestResponse> SendPostRequest(string requestUrl, object content)
        {
            var request = new RestRequest(requestUrl, Method.POST).AddJsonBody(content);
            return await UserService.Instance.restClient.ExecuteAsync(request);
        }
        public async Task<IRestResponse> SendPutRequest(string requestUrl, int id, object content)
        {
            var request = new RestRequest(requestUrl + $"/{id}", Method.PUT).AddJsonBody(content);
            return await UserService.Instance.restClient.ExecuteAsync(request);
        }
        public async Task<IRestResponse> SendDeleteRequest(string requestUrl, int id)
        {
            var request = new RestRequest(requestUrl + $"/{id}", Method.DELETE);
            return await UserService.Instance.restClient.ExecuteAsync(request);
        }
        public async Task<IRestResponse> SendDeleteRequest(string requestUrl, int id, string connectionId)
        {
            var request = new RestRequest(requestUrl + $"/{id}", Method.DELETE).AddParameter("connectionId", connectionId);
            return await UserService.Instance.restClient.ExecuteAsync(request);
        }
    }
}

﻿using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        private const string CLIENTS_RESOURCE = "clients";
        private const string TOGGLE_ACTION = "toggle";

        // https://github.com/harvesthq/api/blob/master/Sections/Clients.md

        /// <summary>
        /// List all clients for the authenticated account. Makes a GET request to the Clients resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the client updated-at property</param>
        public IList<Client> ListClients(DateTime? updatedSince = null)
        {
            var request = GetListClientsRequest(updatedSince);

            return Execute<List<Client>>(request);
        }

        /// <summary>
        /// List all clients for the authenticated account. Makes a GET request to the Clients resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the client updated-at property</param>
        public Task<List<Client>> ListClientsAsync(DateTime? updatedSince = null)
        {
            var request = GetListClientsRequest(updatedSince);

            return ExecuteAsync<List<Client>>(request);
        }

        /// <summary>
        /// Retrieve a client on the authenticated account. Makes a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The Id of the client to retrieve</param>
        public Client Client(long clientId)
        {
            var request = GetClientRequest(clientId, Method.GET);

            return Execute<Client>(request);
        }

        /// <summary>
        /// Retrieve a client on the authenticated account. Makes a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The Id of the client to retrieve</param>
        public Task<Client> ClientAsync(long clientId)
        {
            var request = GetClientRequest(clientId, Method.GET);

            return ExecuteAsync<Client>(request);
        }

        /// <summary>
        /// Creates a new client under the authenticated account. Makes both a POST and a GET request to the Clients resource.
        /// </summary>
        /// <param name="name">The name of the client</param>
        /// <param name="currency">The currency for the client</param>
        /// <param name="active">The status of the client</param>
        /// <param name="details">The details (address, phone, etc.) of the client</param>
        /// <param name="highriseId">The related Highrise ID of the client</param>
        public Client CreateClient(string name, Currency? currency = null, bool active = true, string details = null, long? highriseId = null)
        {
            var newClient = GetClientOptions(name, currency, active, details, highriseId);

            return CreateClient(newClient);
        }

        /// <summary>
        /// Creates a new client under the authenticated account. Makes both a POST and a GET request to the Clients resource.
        /// </summary>
        /// <param name="name">The name of the client</param>
        /// <param name="currency">The currency for the client</param>
        /// <param name="active">The status of the client</param>
        /// <param name="details">The details (address, phone, etc.) of the client</param>
        /// <param name="highriseId">The related Highrise ID of the client</param>
        public Task<Client> CreateClientAsync(string name, Currency? currency = null, bool active = true, string details = null, long? highriseId = null)
        {
            var newClient = GetClientOptions(name, currency, active, details, highriseId);

            return CreateClientAsync(newClient);
        }

        /// <summary>
        /// Creates a new client under the authenticated account. Makes a POST and a GET request to the Clients resource.
        /// </summary>
        /// <param name="options">The options for the new client to be created</param>
        public Client CreateClient(ClientOptions options)
        {
            var request = GetCreateClientRequest(options);

            return Execute<Client>(request);
        }
        
        /// <summary>
        /// Creates a new client under the authenticated account. Makes a POST and a GET request to the Clients resource.
        /// </summary>
        /// <param name="options">The options for the new client to be created</param>
        public Task<Client> CreateClientAsync(ClientOptions options)
        {
            var request = GetCreateClientRequest(options);

            return ExecuteAsync<Client>(request);
        }

        /// <summary>
        /// Delete a client from the authenticated account. Makes a DELETE request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to delete</param>
        public bool DeleteClient(long clientId)
        {
            var request = GetClientRequest(clientId, Method.DELETE);

            var result = Execute(request);

            return result.IsSuccessfulDelete();
        }

        /// <summary>
        /// Delete a client from the authenticated account. Makes a DELETE request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to delete</param>
        public async Task<bool> DeleteClientAsync(long clientId)
        {
            var request = GetClientRequest(clientId, Method.DELETE);

            var result = await ExecuteAsync(request);

            return result.IsSuccessfulDelete();
        }
        
        /// <summary>
        /// Toggle the Active status of a client on the authenticated account. Makes a POST request to the Clients/Toggle resource and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to toggle</param>
        public Client ToggleClient(long clientId)
        {
            var request = GetClientRequest(clientId, Method.POST, TOGGLE_ACTION);

            return Execute<Client>(request);
        }

        /// <summary>
        /// Toggle the Active status of a client on the authenticated account. Makes a POST request to the Clients/Toggle resource and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to toggle</param>
        public Task<Client> ToggleClientAsync(long clientId)
        {
            var request = GetClientRequest(clientId, Method.POST, TOGGLE_ACTION);

            return ExecuteAsync<Client>(request);
        }

        /// <summary>
        /// Update a client on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to update</param>
        /// <param name="name">The updated name</param>
        /// <param name="currency">The updated currency</param>
        /// <param name="details">The updated details</param>
        /// <param name="highriseId">The updated Highrise ID</param>
        /// <param name="active">The updated state</param>
        public Client UpdateClient(long clientId, string name = null, Currency? currency = null, bool? active = null, string details = null, long? highriseId = null)
        {
            var options = GetClientOptions(name, currency, active, details, highriseId);

            return UpdateClient(clientId, options);
        }

        /// <summary>
        /// Update a client on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to update</param>
        /// <param name="name">The updated name</param>
        /// <param name="currency">The updated currency</param>
        /// <param name="details">The updated details</param>
        /// <param name="highriseId">The updated Highrise ID</param>
        /// <param name="active">The updated state</param>
        public Task<Client> UpdateClientAsync(long clientId, string name = null, Currency? currency = null, bool? active = null, string details = null, long? highriseId = null)
        {
            var options = GetClientOptions(name, currency, active, details, highriseId);

            return UpdateClientAsync(clientId, options);
        }

        /// <summary>
        /// Updates a client on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID for the client to update</param>
        /// <param name="options">The options to be updated</param>
        public Client UpdateClient(long clientId, ClientOptions options)
        {
            var request = GetUpdateClientRequest(clientId, options);

            return Execute<Client>(request);
        }

        /// <summary>
        /// Updates a client on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID for the client to update</param>
        /// <param name="options">The options to be updated</param>
        public Task<Client> UpdateClientAsync(long clientId, ClientOptions options)
        {
            var request = GetUpdateClientRequest(clientId, options);

            return ExecuteAsync<Client>(request);
        }

        private IRestRequest GetListClientsRequest(DateTime? updatedSince)
        {
            var request = Request(CLIENTS_RESOURCE);

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return request;
        }

        private IRestRequest GetClientRequest(long clientId, Method method, string action = null)
        {
            string resource = string.Format("{0}/{1}", CLIENTS_RESOURCE, clientId);

            if (!string.IsNullOrEmpty(action))
                resource = string.Format("{0}/{1}", resource, action);

            return Request(resource, method);
        }

        private static ClientOptions GetClientOptions(string name, Currency? currency, bool? active, string details, long? highriseId)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            return new ClientOptions
            {
                Name = name,
                Active = active,
                Currency = currency,
                Details = details,
                HighriseId = highriseId
            };
        }
        
        private IRestRequest GetCreateClientRequest(ClientOptions options)
        {
            return Request(CLIENTS_RESOURCE, Method.POST).AddBody(options);
        }

        private IRestRequest GetUpdateClientRequest(long clientId, ClientOptions options)
        {
            return GetClientRequest(clientId, Method.PUT).AddBody(options);
        }
    }
}

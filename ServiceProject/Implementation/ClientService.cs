using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICountryRepository _countryRepository;

        public ClientService(IClientRepository clientRepository, ICountryRepository countryRepository)
        {
            _clientRepository = clientRepository;
            _countryRepository = countryRepository;
        }

        public bool AddClient(ClientModel model)
        {
           return _clientRepository.Add(ModelToEntity(model)) > 0;
        }

        public ClientModel GetClient(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
           return MapToModel(client);
        }

        public IEnumerable<ClientModel> GetClients()
        {
           return _clientRepository.GetAll().Select(x=> MapToModel(x));
        }

        public IEnumerable<Country> GetCountries()
        {
            return _countryRepository.GetAll().OrderByDescending(x=> x.Order);
        }

        private ClientModel MapToModel(Client client)
        {
            return new ClientModel
            {
               Address1 = client.Address1,
               Address2 = client.Address2,
               City = client.City,
               CountryId = client.CountryId,
               State = client.State,
               Domain = client.Domain,
               Email = client.Email,
               Name = client.Name,
               Phone = client.Phone,
               Pin = client.Pin,
            };
        }

        private Client ModelToEntity(ClientModel client)
        {
            return new Client
            {
                Address1 = client.Address1,
                Address2 = client.Address2,
                City = client.City,
                CountryId = client.CountryId,
                State = client.State,
                Domain = client.Domain,
                Email = client.Email,
                Name = client.Name,
                Phone = client.Phone,
                Pin = client.Pin,
            };
        }
    }
}
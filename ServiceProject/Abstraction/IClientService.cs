using CommonModel;
using ProjectDB.DBModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface IClientService
    {
        bool AddClient(ClientModel model);
        IEnumerable<ClientModel> GetClients();
        ClientModel GetClient(int clientId);
        IEnumerable<Country> GetCountries();
    }
}

using HouseofGunpowder.Models;

namespace HouseofGunpowder.Repositories.Interfaces {
    public interface IClientRepository {
        Task<List<ClientModel>> GetAllClients();
        Task<ClientModel> GetClientById(long cpf);
        Task<ClientModel> AddClient(ClientModel client);
        Task<ClientModel> UpdateClient(ClientModel client, long cpf);
        Task<bool> DeleteClient(long cpf);
    }
}

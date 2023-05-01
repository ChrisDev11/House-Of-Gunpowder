using HouseofGunpowder.Data;
using HouseofGunpowder.Models;
using HouseofGunpowder.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseofGunpowder.Repositories {
    public class ClientRepository : IClientRepository {

        private readonly GunpowderDBContext _dbContext;
        public ClientRepository(GunpowderDBContext gunpowderDBContext) {
            _dbContext = gunpowderDBContext;
        }

        public async Task<ClientModel> GetClientById(long cpf) {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.CPF == cpf);
        }

        public async Task<List<ClientModel>> GetAllClients() {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<ClientModel> AddClient(ClientModel client) {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }

        public async Task<ClientModel> UpdateClient(ClientModel client, long cpf) {
            ClientModel clientById = await GetClientById(cpf);

            if (clientById == null) {
                throw new Exception($"Cliente com CPF: {cpf} não foi encontrado.");
            }

            clientById.Name = client.Name;
            clientById.CPF = client.CPF;
            clientById.Phone = client.Phone;
            clientById.Email = client.Email;

            _dbContext.Clients.Update(clientById);
            await _dbContext.SaveChangesAsync();

            return clientById;
        }

        public async Task<bool> DeleteClient(long cpf) {

            ClientModel clientById = await GetClientById(cpf);

            if (clientById == null) {
                throw new Exception($"Cliente com CPF: {cpf} não foi encontrado.");
            }

            _dbContext.Clients.Remove(clientById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

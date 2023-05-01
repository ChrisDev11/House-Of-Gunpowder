using HouseofGunpowder.Models;
using HouseofGunpowder.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseofGunpowder.Controllers {

    [Route("api/[controller]")]
    [ApiController]

    public class ClientController : Controller {

        private readonly IClientRepository _clientRepository;
        private readonly IEmail _email;

        public ClientController(IClientRepository clientRepository, IEmail email) {
            _clientRepository = clientRepository;
            _email = email;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> GetAllClients() {
            List<ClientModel> clients = await _clientRepository.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<ClientModel>> GetById(long cpf) {
            ClientModel client = await _clientRepository.GetClientById(cpf);
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientModel>> Register([FromBody] ClientModel clientModel) {

            string message = $"Olá {clientModel.Name}.\n" +
                $"Ficamos muito felizes em receber você!\n" +
                $"Um Grande Abraço de toda a Equipe da Casa da Pólvora!";

            ClientModel client = await _clientRepository.AddClient(clientModel);

            _email.Send(client.Email, "Novo Cadastro", message);

            return Ok(client);
        }

        [HttpPut("{cpf}")]
        public async Task<ActionResult<ClientModel>> Update([FromBody] ClientModel clientModel, long cpf) {
            clientModel.CPF = cpf;
            ClientModel client = await _clientRepository.UpdateClient(clientModel, cpf);
            return Ok(client);
        }

        [HttpDelete("{cpf}")]
        public async Task<ActionResult<ClientModel>> Delete(long cpf) {
            bool deleted = await _clientRepository.DeleteClient(cpf);
            return Ok(deleted);
        }
    }
}

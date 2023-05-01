<template>
  <div class="container">
    <div class="p-4 p-md-5 mb-4 rounded text-bg-dark">
      <div class="col-md-6 px-0">
        <h1 class="display-4 fst-italic">{{ msg }}</h1>
        <p class="lead my-3">Cadastro de Clientes</p>
      </div>
    </div>
    <from>
      <div class="form-group">
        <label for="name">Nome</label>
        <input type="hidden" id="id" name="id">
        <input type="text" class="form-control card border-1 " id="name" name="name" placeholder="Digite o nome">
      </div>
      <div class="form-group">
        <label for="cpf">CPF</label>
        <!-- <input type="hidden" id="id" name="id"> -->
        <input type="text" class="form-control card border-1 " id="cpf" name="cpf" placeholder="Digite o CPF">
      </div>
      <div class="form-group">
        <label for="phone">Telefone</label>
        <!--                       -->
        <input type="text" class="form-control card border-1 " id="phone" name="phone" placeholder="Digite o Telefone">
      </div>
      <div class="form-group">
        <label for="email">E-mail</label>
        <input type="text" class="form-control card border-1 " id="email" name="email" placeholder="Digite o E-mail">
      </div>
      <div id="espaco">
        <button v-on:click="salvar()" type="button" class="btn btn-primary">Enviar</button>
      </div>
      <div style="color:red">
        {{ mensagem }}
      </div>
    </from>

    <hr>
    <table class="table">
      <thead>
        <tr>
          <th>
            Nome
          </th>
          <th>
            CPF
          </th>
          <th>
            Telefone
          </th>
          <th>
            E-mail
          </th>
          <th colspan="2">

          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="Clients in Client" v-bind:key="Clients.Id">
          <td>
            {{ Clients.name }}
          </td>
          <td>
            {{ Clients.cpf }}
          </td>
          <td>
            {{ Clients.phone }}
          </td>
          <td>
            {{ Clients.email }}
          </td>
          <td>
            <button class="btn btn-primary" v-on:click="editar(Clients)">Editar</button>
          </td>
          <td>
            <button class="btn btn-danger" v-on:click="excluir(Clients.cpf)">Excluir</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'CadastroCliente',
  props: {
    msg: String

  },
  data: () => {
    return {
      Client: [],
      Clients: undefined,
      mensagem: ""
    }
  },
  methods: {
    //Lista os Clientes na tela
    lista() {
      axios.get('https://localhost:7199/api/Client').then((res) => {
        console.log(res)
        this.Client = res.data
      })
    },
    //Função Salvar/quando elementos vou salvar/e atualizar a pagina
    salvar() {
      if (this.Clients) {
        this.alterar()
        return
      }

      axios.post('https://localhost:7199/api/Client',
        {
          name: document.getElementById("name").value,
          cpf: document.getElementById("cpf").value,
          phone: document.getElementById("phone").value,
          email: document.getElementById("email").value
        }).then(() => {
          this.lista()
        })
    },
    //Auto preencher dados para a edição Clientes
    editar(Clients) {
      document.getElementById("name").value = Clients.name
      document.getElementById("cpf").value = Clients.cpf
      document.getElementById("phone").value = Clients.phone
      document.getElementById("email").value = Clients.email
      this.Clients = Clients
    },
    //Atualizar dados que ja estao gravados
    alterar() {
      this.Clients.name = document.getElementById("name").value
      this.Clients.cpf = document.getElementById("cpf").value
      this.Clients.phone = document.getElementById("phone").value
      this.Clients.email = document.getElementById("email").value
      console.log(this.Clients)
      console.log(this.Clients.id)
      axios.put(`https://localhost:7199/api/Client/${this.Clients.cpf}`, this.Clients).then((res) => {
        console.log(res) //Edit

        this.lista()
        this.Clients = undefined
        document.getElementById("name").value = ""
        document.getElementById("cpf").value = ""
        document.getElementById("phone").value = ""
        document.getElementById("email").value = ""

      })

    },
    //Metodo EXCLUIR 
    excluir(cpf) {
      if (confirm("🚫Deseja realmente excluir o Cliente?🚫")) {
        axios.delete(`https://localhost:7199/api/Client/${cpf}`).then((res) => {
          console.log(res) //Edit

          this.lista()
        })
      }
    }
  },
  created() {
    this.lista()
  }
}
</script>

<style>
#espaco {
  margin-top: 10px;
}
</style>




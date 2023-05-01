<template>
  <div class="container">
    <div class="p-4 p-md-5 mb-4 rounded text-bg-dark">
      <div class="col-md-6 px-0">
        <h1 class="display-4 fst-italic">{{ msg }}</h1>
        <p class="lead my-3">Cadastro de Fornecedores</p>
      </div>
    </div>

    <from>
      <div class="form-group">
        <label for="name">Empresa</label>
        <!-- <input type="hidden" id="id" name="id"> -->
        <input type="text" class="form-control card border-1 " id="name" name="name"
          placeholder="Digite o nome da Empresa">
      </div>
      <div class="form-group">
        <label for="cnpj">CNPJ</label>
        <!-- <input type="hidden" id="id" name="id"> -->
        <input type="text" class="form-control card border-1 " id="cnpj" name="cnpj" placeholder="Digite o CNPJ">
      </div>
      <div class="form-group">
        <label for="agent">Representante</label>
        <input type="text" class="form-control card border-1 " id="agent" name="agent"
          placeholder="Digite o Representante">
      </div>
      <div class="form-group">
        <label for="phone">Telefone</label>
        <!--                       -->
        <input type="text" class="form-control card border-1 " id="phone" name="phone" placeholder="Digite o Telefone">
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
            Fornecedor
          </th>
          <th>
            CNPJ
          </th>
          <th>
            Representante
          </th>
          <th>
            Telefone
          </th>
          <th colspan="2">

          </th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="Suppliers in Supplier" v-bind:key="Suppliers.Id">
          <td>
            {{ Suppliers.name }}
          </td>
          <td>
            {{ Suppliers.cnpj }}
          </td>
          <td>
            {{ Suppliers.agent }}
          </td>
          <td>
            {{ Suppliers.phone }}
          </td>
          <td>
            <button class="btn btn-primary" v-on:click="editar(Suppliers)">Editar</button>
          </td>
          <td>
            <button class="btn btn-danger" v-on:click="excluir(Suppliers.cnpj)">Excluir</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'CadastroEmpresa',
  props: {
    msg: String
  },
  data: () => {
    return {
      Supplier: [],
      Suppliers: undefined,
      mensagem: ""
    }
  },
  methods: {
    //Lista os Fornecedores na tela
    lista() {
      axios.get('https://localhost:7199/api/Supplier').then((res) => {
        console.log(res)
        this.Supplier = res.data
      })
    },
    //Função Salvar/quando elementos vou salvar/e atualizar a pagina
    salvar() {
      if (this.Suppliers) {
        this.alterar()
        return
      }

      axios.post('https://localhost:7199/api/Supplier',
        {
          name: document.getElementById("name").value,
          cnpj: document.getElementById("cnpj").value,
          agent: document.getElementById("agent").value,
          phone: document.getElementById("phone").value
        }).then(() => {
          this.lista()
        })
    },
    //Auto preencher dados para a edição Suppliers
    editar(Suppliers) {
      document.getElementById("name").value = Suppliers.name
      document.getElementById("cnpj").value = Suppliers.cnpj
      document.getElementById("agent").value = Suppliers.agent
      document.getElementById("phone").value = Suppliers.phone
      this.Suppliers = Suppliers
    },
    //Atualizar dados que ja estao gravados
    alterar() {
      this.Suppliers.name = document.getElementById("name").value
      this.Suppliers.cnpj = document.getElementById("cnpj").value
      this.Suppliers.agent = document.getElementById("agent").value
      this.Suppliers.phone = document.getElementById("phone").value

      axios.put(`https://localhost:7199/api/Supplier/${this.Suppliers.cnpj}`, this.Suppliers).then(() => {
        this.lista()
        this.Suppliers = undefined
        document.getElementById("name").value = ""
        document.getElementById("cnpj").value = ""
        document.getElementById("agent").value = ""
        document.getElementById("phone").value = ""

      })

    },
    //Metodo EXCLUIR 
    excluir(cnpj) {
      if (confirm("🚫Deseja realmente excluir o Fornecedor?🚫")) {
        axios.delete(`https://localhost:7199/api/Supplier/${cnpj}`).then(() => {
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
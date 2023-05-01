<template>
  <div class="container">
    <div class="p-4 p-md-5 mb-4 rounded text-bg-dark">
      <div class="col-md-6 px-0">
        <h1 class="display-4 fst-italic">{{ msg }}</h1>
        <p class="lead my-3">Cadastro de Produtos</p>
      </div>
    </div>
    <from>
      <div class="form-group">
        <label for="name">Produto</label>
        <!-- <input type="hidden" id="id" name="id"> -->
        <input type="text" class="form-control card border-1 " id="name" name="name"
          placeholder="Digite o nome do Produto">
      </div>
      <div class="form-group">
        <label for="description">Descrição</label>
        <!-- <input type="hidden" id="id" name="id"> -->
        <input type="text" class="form-control card border-1 " id="description" name="description"
          placeholder="Digite a Descrição">
      </div>
      <div class="form-group">
        <label for="price">Preço</label>
        <input type="text" class="form-control card border-1 " id="price" name="price"
          placeholder="Digite o Preço do Produto">
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
            Produto
          </th>
          <th>
            Descrição
          </th>
          <th>
            Preço
          </th>
          <th colspan="2"></th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="Products in Product" v-bind:key="Products.Id">
          <td>
            {{ Products.name }}
          </td>
          <td>
            {{ Products.description }}
          </td>
          <td>
            {{ Products.price }}
          </td>
          <td>
            <button class="btn btn-primary" v-on:click="editar(Products)">Editar</button>
          </td>
          <td>
            <button class="btn btn-danger" v-on:click="excluir(Products.id)">Excluir</button>
          </td>
        </tr>
      </tbody>

    </table>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'CadastroProduto',
  props: {
    msg: String
  },
  data: () => {
    return {
      Product: [],
      Products: undefined,
      mensagem: ""
    }
  },
  methods: {
    //Lista os Fornecedores na tela
    lista() {
      axios.get('https://localhost:7199/api/Product').then((res) => {
        console.log(res)
        this.Product = res.data
      })
    },
    //Função Salvar/quando elementos vou salvar/e atualizar a pagina
    salvar() {
      if (this.Products) {
        this.alterar()
        return
      }

      axios.post('https://localhost:7199/api/Product',
        {
          name: document.getElementById("name").value,
          description: document.getElementById("description").value,
          price: document.getElementById("price").value
        }).then(() => {
          this.lista()
        })
    },
    //Auto preencher dados para a edição Products
    editar(Products) {
      document.getElementById("name").value = Products.name
      document.getElementById("description").value = Products.description
      document.getElementById("price").value = Products.price
      this.Products = Products
    },
    //Atualizar dados que ja estao gravados
    alterar() {
      this.Products.name = document.getElementById("name").value
      this.Products.description = document.getElementById("description").value
      this.Products.price = document.getElementById("price").value

      axios.put(`https://localhost:7199/api/Product/${this.Products.id}`, this.Products).then(() => {
        this.lista()
        this.Products = undefined
        document.getElementById("name").value = ""
        document.getElementById("description").value = ""
        document.getElementById("price").value = ""
      })
    },
    //Metodo EXCLUIR 
    excluir(id) {
      if (confirm("🚫Deseja realmente excluir o Produto?🚫")) {
        axios.delete(`https://localhost:7199/api/Product/${id}`).then(() => {
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


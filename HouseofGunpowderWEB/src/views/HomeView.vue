<template>
  <div class="container">
    <div class="p-4 p-md-5 mb-4 rounded text-bg-dark">
      <div class="col-md-6 px-0">
        <h1 class="display-4 fst-italic">Modo Administrador Casa da Pólvora</h1>
        <p class="lead my-3">Versão Alpha do projeto</p>
      </div>
    </div>
  </div>


  <!-- Painel Projeto -->
  <section class="section section-lg pt-lg-0 mt--200">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-lg-12">
          <div class="row row-grid">
            <div id="espaco" class="col-lg-4">
              <div class="card border-1 card-lift--hover shadow">
                <div class="card-body py-3">
                  <h6 class="text-primary text-uppercase">Clientes</h6>
                  <p class="description mt-3">Clique em cadastrar para adicionar mais clientes ao banco de dados</p>
                  <router-link to="/CadastroClientes" class="btn mt-4 btn-primary"> Cadastrar</router-link>
                </div>
              </div>
            </div>
            <div id="espaco" class="col-lg-4">
              <div class="card border-1 card-lift--hover shadow">
                <div class="card-body py-3">
                  <h6 class="text-primary text-uppercase">Mercadorias</h6>
                  <p class="description mt-3">Clique em cadastrar para adicionar mercadorias ao estoque</p>
                  <router-link to="/CadastroProduto" class="btn mt-4 btn-primary"> Cadastrar</router-link>
                </div>
              </div>
            </div>
            <div id="espaco" class="col-lg-4">
              <div class="card border-1 card-lift--hover shadow">
                <div class="card-body py-3">
                  <h6 class="text-primary text-uppercase">Fornecedores</h6>
                  <p class="description mt-3">Adicione Fornecedores a sua loja e melhere sua logistica</p>
                  <router-link to="/CadastroEmpresa" class="btn mt-4 btn-primary"> Cadastrar</router-link>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>


export default {

  components: {

  }
}
</script>

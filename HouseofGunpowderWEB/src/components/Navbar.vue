<template>
    <div class="container" id="nav">
        <div class="nav-scroller py-1 mb-2">
            <nav class="nav d-flex justify-content-between">
                <!-- <router-link to="/">
            <img src="" id="logo">
        </router-link> -->
                <router-link to="/">Home</router-link>
                <router-link to="/CadastroClientes">Cadastro Clientes</router-link>
                <router-link to="/CadastroProduto">Cadastro Produtos</router-link>
                <router-link to="/CadastroEmpresa">Cadastro Empresas</router-link>
            </nav>
        </div>
    </div>
</template>

<script>
export default {
    name: "Navbar"
}
</script>

<style></style>
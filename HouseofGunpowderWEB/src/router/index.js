import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: HomeView,
  },
  {
    path: "/CadastroClientes",
    name: "CadastroClientes",

    component: () =>
      import(
        /* webpackChunkName: "CadastroClientes" */ "../views/CadastroClientes.vue"
      ),
  },
  {
    path: "/CadastroProduto",
    name: "CadastroProduto",

    component: () =>
      import(
        /* webpackChunkName: "CadastroProduto" */ "../views/CadastroProduto.vue"
      ),
  },
  {
    path: "/CadastroEmpresa",
    name: "CadastroEmpresa",

    component: () =>
      import(
        /* webpackChunkName: "CadastroEmpresa" */ "../views/CadastroEmpresa.vue"
      ),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;

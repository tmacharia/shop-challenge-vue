import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import $ from 'jquery';
Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/shops/shops.vue.html') },
    { path: '/shops', component: require('./components/shops/shops.vue.html') },
    { path: '/shops/preferred', component: require('./components/preferred-shops/preferred-shops.vue.html') },
    { path: '/signin', component: require('./components/account/signin.vue.html') },
    { path: '/signup', component: require('./components/account/signup.vue.html') },
    { path: '/account', component: require('./components/account/account.vue.html') },
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html')),
    created: function () {
        
    },
    mounted: function () {
    }
});
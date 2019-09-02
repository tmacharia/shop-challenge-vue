import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/shops', component: require('./components/home/home.vue.html') },
    { path: '/shops/preferred', component: require('./components/preferred/preferred.vue.html') },
    { path: '/signin', component: require('./components/account/signin.vue.html') },
    { path: '/signup', component: require('./components/account/signup.vue.html') },
    { path: '/account', component: require('./components/account/account.vue.html') },
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html')),
    mounted: function () {
        
    }
});
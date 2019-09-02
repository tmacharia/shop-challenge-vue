import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import Axios from 'axios';


@Component
export default class NavMenuComponent extends Vue {
    loggedIn: boolean = false;
    user: string = '';

    mounted() {
        // check if current user is authenticated.
        Axios.get('/account/status')
            .then(response => {
                this.loggedIn = response.data.isAuthenticated;
                this.user = response.data.name;
            }).catch(error => {
                console.log(error);
            });
    }
}
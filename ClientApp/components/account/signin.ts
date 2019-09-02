import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import Axios from 'axios';
import $ from 'jquery';

interface User {
    Email: string;
    Password: string;
    RememberMe: boolean;
}

@Component
export default class SignInComponent extends Vue {
    title: string = 'Sign In';
    user: User = { Email: '', Password: '', RememberMe: false };
    error: string = '';

    mounted() {
        document.title = this.title;
    };
    submitForm(e: Event) {
        e.preventDefault();
        this.error = '';
        Axios.post('/account/login', this.user)
            .then(response => {
                window.location.href = '/';
            })
            .catch(error => {
                if (error.response.status === 400) {
                    var errors = error.response.data;
                    if (errors.length) {
                        this.error = errors[0];
                    }
                } else {
                    this.error = 'An error occured';
                }
            })
    }
}
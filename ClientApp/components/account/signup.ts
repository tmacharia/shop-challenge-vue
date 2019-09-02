import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import Axios from 'axios';

interface User {
    Email: string;
    Password: string;
}

@Component
export default class SignUpComponent extends Vue {
    title: string = 'Sign Up';
    user: User = { Email: '', Password: '' };
    error: string = '';

    mounted() {
        document.title = this.title;
    };
    submitForm(e: Event) {
        e.preventDefault();
        this.error = '';
        Axios.post('/account/register', this.user)
            .then(response => {
                alert('Account created successfully. Redirecting you to login page...');
                window.location.href = '/signin';
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
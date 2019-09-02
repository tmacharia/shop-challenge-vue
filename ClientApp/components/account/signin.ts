import Vue from 'vue';
import { Component } from 'vue-property-decorator';

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
    }
}
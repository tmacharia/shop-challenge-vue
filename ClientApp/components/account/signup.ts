import Vue from 'vue';
import { Component } from 'vue-property-decorator';

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
    }
}
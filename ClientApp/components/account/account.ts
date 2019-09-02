import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class AccountComponent extends Vue {
    title: string = 'User Account';
    disliked: number = 0;

    mounted() {
        document.title = this.title;

        this.disliked = document.cookie.split(';').filter((cookie) => {
            if (cookie.includes('dislike')) {
                return cookie;
            }
        }).length;
    };
}
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Shop {
    name: string;
    description: string;
    imageUrl: string;
    distance: number;
    metricUnit: string;
}

@Component
export default class ShopComponent extends Vue {
    title: string= 'Nearby Shops';
    shops: Shop[] = [];

    mounted() {
        document.title = this.title;
        fetch('/api/shops')
            .then(response => response.json() as Promise<Shop[]>)
            .then(data => {
                this.shops = data;
            }).catch(error => {
                console.log(error);
            });
    }
}
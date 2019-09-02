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
    title: string = 'My Preferred Shops';
    shops: Shop[] = [];
    isLoading: boolean = false;

    mounted() {
        document.title = this.title;
    }
}
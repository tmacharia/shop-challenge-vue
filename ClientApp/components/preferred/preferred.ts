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
    shops: Shop[] = [];

    mounted() {
        
    }
}
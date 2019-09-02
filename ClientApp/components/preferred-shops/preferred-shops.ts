import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { cookies } from '../cookiesHelper';

interface Shop {
    id: number;
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

        fetch('/api/shops')
            .then(response => response.json() as Promise<Shop[]>)
            .then(data => {
                var liked = cookies.likedShops();
                this.shops = data.filter((shop) => {
                    var index = liked.indexOf(shop.id);
                    if (index != -1) {
                        return shop;
                    }
                })
            }).catch(error => {
                console.log(error);
            });
    };

    removeLikedShop(shop: Shop) {
        var liked = cookies.likedShops();
        var index = liked.indexOf(shop.id);
        if (index > -1) {
            liked.splice(index, 1);

            var cookie_value = liked.join(',');
            cookies.set(cookies.likedCookieKey, cookie_value);

            // now remove the liked shop from nearby shops
            this.shops = this.shops.filter((s) => { return s.id != shop.id });
        }
    }
}
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import Axios from 'axios';
import $ from 'jquery';

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

        this.setActiveMenuPageLoad();
        this.activeMenuItemEventListener();
    };
    setActiveMenuPageLoad() {
        // get the current route
        var path = window.location.pathname;
        // get the nav-link with the href equal to the current route
        var navs = $('.nav-link').filter((index, link) => {
            var attrib = ($(link)[0].attributes.getNamedItem('href') as Attr);
            if (attrib != null) {
                console.log(attrib.value);
                return attrib.value == path;
            }
            return false;
        });
        if (navs.length > 0) {
            this.setActiveMenuItem(navs[0]);
        }
    };
    activeMenuItemEventListener() {
        var current = this;
        $('.nav-link').on('click', function (event) {
            current.setActiveMenuItem(event.target);
        });
    };

    setActiveMenuItem(navItem: Element) {
        // remove active css class from all nav-links
        $('.nav-link').removeClass('active');

        // then add .active css class to 'new_active_item' to show it as active.
        $(navItem).addClass('active');
    }
}
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import Axios from 'axios';
import $ from 'jquery';

function addMenuItemRouteChangedEventListener() {
    $('.nav-link').on('click', function (event) {
        setActiveMenuItem(event.target);
    });
}
function setActiveMenuItemOnPageLoad() {
    /*********************
     * To give vue.js time to finish mounting all objects,
     * we will have implement a delay, otherwise this will result
     * in the wrong results. 100 milliseconds is enough to achieve
     * the desired results.
     * 
     ***********/
    setTimeout(() => {
        // get the current route
        var path = window.location.pathname;
        // get the nav-link with the href equal to the current route
        var navs = $('.nav-link').filter((index, nav_link) => {
            var href_attribute = ($(nav_link)[0].attributes.getNamedItem('href') as Attr);
            if (href_attribute != null) {
                console.log(href_attribute.value);
                return href_attribute.value == path;
            }
            return false;
        });
        if (navs.length > 0) {
            setActiveMenuItem(navs[0]);
        }
    }, 100);
}
function setActiveMenuItem(navItem: Element) {
    // remove active css class from all nav-links
    $('.nav-link').removeClass('active');

    // then add .active css class to 'new_active_item' to show it as active.
    $(navItem).addClass('active');
}

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

                setActiveMenuItemOnPageLoad();
                addMenuItemRouteChangedEventListener();
            }).catch(error => {
                console.log(error);
            });
    };
}
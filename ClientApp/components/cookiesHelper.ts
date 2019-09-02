/**
 * Checks if a cookie with the specified name exists.
 * @param name Name of cookie
 * @returns {boolean} true or false.
 */
function doesCookieExist(name: string) {
    var cookie = getCookie(name);
    if (cookie != "" && cookie.length > 0) {
        return true;
    } else {
        return false;
    }
}
/**
 * Gets the value of the cookie with the specified name.
 * @param name Name of cookie
 * @returns {string} Cookie value 
 */
function getCookie(name: string) {
    var name = name + "=";
    var results = document.cookie.split(';').filter(c => {
        if (c.includes(name)) {
            return c;
        }
    });
    if (results.length > 0) {
        return results[0].split('=')[1];
    }
    return '';
}
/**
 * Add/updates a cookie with the specified value that will last
 * for the specified number of hours.
 * @param name Name of cookie.
 * @param value Cookie of value.
 * @param expInHours Expiration period of cookie in hours. Default is 1 month or 720 hrs.
 * @returns {void} 
 */
function setCookie(name: string, value: string, expInHours: number=720) {
    var exp_date = new Date();
    exp_date.setTime(exp_date.getTime() + (expInHours * 60 * 60 * 1000));
    var expires = "expires=" + exp_date.toString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/";
}
/**
 * Returns an integer array with the Id's of all the shops liked by the user
 * as retrieved from the browser cookies.
 * @returns {Array<number>}
 */
function getLikedShops() {
    var liked_shops: number[] = [];
    // get previously liked shop ids
    var prev = cookies.get(likedCookieKey);
    if (prev && prev.length > 0) {
        var ids = prev.split(',');
        ids.forEach(id => {
            liked_shops.push(parseInt(id));
        });
    }
    return liked_shops;
}
let likedCookieKey = 'liked-shops';
let cookies = {
    checkIfExists: doesCookieExist,
    get: getCookie,
    set: setCookie,
    likedCookieKey: likedCookieKey,
    likedShops: getLikedShops
}
export { cookies };
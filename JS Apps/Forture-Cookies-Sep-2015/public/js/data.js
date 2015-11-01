var data = (function() {
    //const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username';
    const STORAGE_AUTH_KEY = 'SPECIAL-AUTHENTICATION-KEY';
    const USERNAME_STORAGE_KEY = 'username-key';

    /* Users */
    function register(user) {
        var promise = new Promise(function(resolve, reject) {
            var url = 'api/users';
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            };
            $.ajax(url, {
                method: 'POST',
                data: JSON.stringify(reqUser),
                contentType: 'application/json',
                success: function(res) {
                    localStorage.setItem(USERNAME_STORAGE_KEY, user.username);
                    localStorage.setItem(STORAGE_AUTH_KEY, res.result.authKey);
                    resolve(res);
                }
            });
        });

        return promise;
    }

    function login(user) {
        var promise = new Promise(function(resolve, reject) {
            var url = 'api/auth';
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            };
            $.ajax(url, {
                method: 'PUT',
                data: JSON.stringify(reqUser),
                contentType: 'application/json',
                success: function(res) {
                    //console.log(res.result.authKey);
                    //console.log(user.username);
                    localStorage.setItem(USERNAME_STORAGE_KEY, user.username);
                    localStorage.setItem(STORAGE_AUTH_KEY, res.result.authKey);
                    resolve(res);
                }
            });
        });

        return promise;
    }

    function logout() {
        var promi = new Promise(function(resolve, reject) {
            //localStorage.removeItem(AUTH_KEY_STORAGE_KEY);
            localStorage.removeItem(USERNAME_STORAGE_KEY);
            localStorage.removeItem(STORAGE_AUTH_KEY);
            toastr.success('User logged out!');
            resolve();
        });

        return promi;
    }

    function getCurrentUser() {
        var username = localStorage.getItem(USERNAME_STORAGE_KEY);
        if (!username) {
            return null;
        }

        return {
            username: username
        };
    }

    /* Cookies */
    function cookiesGet() {
        var promise = new Promise(function(resolve, reject){
            var url = 'api/cookies';
            $.ajax(url, {
                method: 'GET',
                contentType: 'application/json',
                success: function(res) {
                    resolve(res);
                },
                error: function(err){
                    reject(err);
                }
            });
        });

        return promise;
    }

    function cookiesAdd(cookie) {
        var promise = new Promise(function(resolve, reject){
            var url = 'api/cookies';
            $.ajax(url, {
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(cookie),
                headers: {
                    'x-auth-key': localStorage.getItem(STORAGE_AUTH_KEY)
                },
                success: function(res) {
                    resolve(res);
                },
                error: function(err){
                    reject(err);
                }
            });
        });

        return promise;
    }



    /* Categories */
    function categoriesGet() {
        var promise = new Promise(function(resolve, reject){
            var url = 'api/categories';
            $.ajax(url, {
                method: 'GET',
                contentType: 'application/json',
                headers: {
                    'x-auth-key': localStorage.getItem(STORAGE_AUTH_KEY)
                },
                success: function(res) {
                    resolve(res);
                },
                error: function(err){
                    reject(err);
                }
            });
        });

        return promise;
    }

    return {
        users: {
            register: register,
            login: login,
            logout: logout,
            current: getCurrentUser
        },
        cookies: {
            get: cookiesGet,
            add: cookiesAdd
        },
        categories: {
            get: categoriesGet
        }
    };
}());
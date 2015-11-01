var data = (function() {
  //const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
    const STORAGE_AUTH_KEY = 'SPECIAL-AUTHENTICATION-KEY';

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
                    //localStorage.setItem(USERNAME_STORAGE_KEY, user.username);
                    //localStorage.setItem(AUTH_KEY_STORAGE_KEY, user.authKey);
                    resolve(res);
                }
            });
        });

        return promise;
    }

    function login(user) {
        var promise = new Promise(function(resolve, reject) {
            var url = 'api/users/auth';
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
                    //localStorage.setItem(USERNAME_STORAGE_KEY, user.username);
                    localStorage.setItem(STORAGE_AUTH_KEY, res.result.authKey);
                    resolve(res);
                }
            });
        });

        return promise;
    }

    /* Todos */
    function todosGet() {
        var promise = new Promise(function(resolve, reject){
            var url = 'api/todos';
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

    function todosAdd(todo) {
        var promise = new Promise(function(resolve, reject){
            var url = 'api/todos';
            $.ajax(url, {
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(todo),
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
          login: login
        },
        todos: {
            get: todosGet,
            add: todosAdd
        },
        categories: {
            get: categoriesGet
        }
    };
}());

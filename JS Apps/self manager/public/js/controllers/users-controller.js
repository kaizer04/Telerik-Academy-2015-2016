var usersController = function() {

    //function all(context) {
    //var users;
    //data.users.get()
    //  .then(function(resUsers) {
    //    users = resUsers;
    //    return templates.get('users');
    //  })
    //  .then(function(template) {
    //    context.$element().html(template(users));
    //    $('.btn-add-friend').on('click', function() {
    //      var id = $(this).parents('.user-box').attr('data-id');
    //      data.friends.sentRequest(id);
    //    });
    //  });
    //}

    function login() {

    }

    function register(context) {
        templates.get('register')
            .then(function(template) {
            context.$element().html(template());
        // attach events
            $('#btn-register').on('click', function() {
                var user = {
                    username: $('#tb-username').val(),
                    password: $('#tb-password').val()
                };

                data.users.register(user)
                    .then(function() {
                        console.log('User registered');
                        //toastr.success('User registered!');
                        //context.redirect('#/');
                        //document.location.reload(true);
                    });
            });

            $('#btn-login').on('click', function() {
                var user = {
                    username: $('#tb-username').val(),
                    password: $('#tb-password').val()
                };

                data.users.login(user)
                    .then(function() {
                        //console.log('User logged in');
                        toastr.success('User logged in!');
                        context.redirect('#/');
                        //document.location.reload(true);
                    });
            });
        });
    }

    return {
        register: register,
        login: login
    };
}();

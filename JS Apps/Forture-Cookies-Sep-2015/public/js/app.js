(function() {

    var sammyApp = Sammy('#content', function() {
        var $content = $('#content');

        this.get('#/', function(){
            this.redirect('#/home');
            document.location.reload(true);
        });

        this.get('#/home', cookiesController.all);

        this.get('#/cookie/add', cookiesController.add);


        //this.get('#/todos', todosController.all);
        //this.get('#/todos/add', todosController.add);
        //
        //this.get('#/events', eventsController.all);
        //    this.get('#/events/add', eventsController.add);
        //

        this.get('#/register', usersController.register);

        //this.get('#/register', usersController.login);
    });

    $(function() {
        sammyApp.run('#/');

        if(data.users.current()) {
            $('#btn-go-to-login')
                .addClass('hidden');
            //$('#btn-share')
            //    .removeClass('hidden');
        }
        else {
            $('#btn-logout')
                .addClass('hidden');
        }

        //if(!(data.users.current())) {
        //    $('#btn-share')
        //        .addClass('hidden');
        //}


        $('#btn-logout').on('click', function() {
            data.users.logout()
                .then(function() {
                    location = '#/';
                    document.location.reload(true);
                });
        });

    });
}());
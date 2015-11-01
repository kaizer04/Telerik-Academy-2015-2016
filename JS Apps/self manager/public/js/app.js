(function() {

    var sammyApp = Sammy('#content', function() {

        this.get('#/', function(){
           this.redirect('#/home');
        });
        this.get('#/home', homeController.all);

        this.get('#/login', usersController.login);
        this.get('#/register', usersController.register);

        this.get('#/todos', todosController.all);
        this.get('#/todos/add', todosController.add);

        //this.get('#/events', eventsController.all);
        //    this.get('#/events/add', eventsController.add);
        //
    });

    $(function() {
        sammyApp.run('#/');

        $.ajax('api/categories', {
            method: 'GET',
            contentType: 'application/json',
            headers: {
                'x-auth-key': localStorage.getItem('SPECIAL-AUTHENTICATION-KEY')
            },
            success: function(categories) {
                toastr.info(JSON.stringify(categories));
            }
        });

    });
}());
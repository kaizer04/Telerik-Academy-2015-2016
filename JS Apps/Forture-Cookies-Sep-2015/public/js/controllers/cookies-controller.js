var cookiesController = function() {

    //function all(context) {
    //    templates.get('home')
    //        .then(function(template) {
    //            context.$element().html(template());
    //        });
    //}

    function all(context) {
        var cookies;
        data.cookies.get()
            .then(function(res) {
                cookies = res.result;
                //console.log(cookies);
                return templates.get('cookies');
            })
            .then(function(template) {
                context.$element().html(template(cookies));
            });
    }

    function add(context) {
        templates.get('cookie-add')
            .then(function(template) {
                context.$element().html(template());
                //    return data.categories.get();
                //  })
                //  .then(function(categories) {

                $('#btn-cookie-add').on('click', function() {
                    var cookie = {
                        text: $('#tb-cookie-text').val(),
                        category: $('#tb-cookie-category').val(),
                        img: $('#tb-cookie-category').val()
                    };
                    data.cookies.add(cookie)
                        .then(function(cookie) {
                            cookie = cookie.result;
                            toastr.success('Cookie added!');
                            context.redirect('#/home');
                        });
                });

                return data.categories.get();
                }).then(function(categories){
                    $('#tb-cookie-category').autocomplete({
                        source: categories.result
                    });
                });
    }

    return {
        all: all,
        add: add
    };
}();

var todosController = (function() {

    function all(context) {
        var todos;
        //var category = context.params.category || null;
        data.todos.get()
            .then(function(resTodos) {
                todos = resTodos.result;
                console.log(todos);
                //todos = _.chain(resTodos)
                //  .groupBy(controllerHelpers.groupByCategory)
                //  .map(controllerHelpers.parseGroups).value();

                //if (category) {
                //  todos = todos.filter(controllerHelpers.filterByCategory(category));
                //}

                return templates.get('todos');
            })
            .then(function(template) {
                context.$element().html(template(todos));
                $('.todo-state').on('change', function() {
                    //var $checkbox = $(this).find('input');
                    //var isChecked = $checkbox.prop('checked');
                    var id = $(this).attr('data-id');
                    //data.todos.update(id, {
                    //    state: isChecked
                    //});
                    //    .then(function(todo) {
                    //    toastr.clear();
                    //    toastr.error(`TODO ${todo.text} updated!`);
                    //});
                });
            //})
            //.catch(function(err) {
            //  console.log(err);
            });
    }

    function add(context) {
        templates.get('todo-add')
            .then(function(template) {
                context.$element().html(template());
            //    return data.categories.get();
            //  })
            //  .then(function(categories) {

                $('#btn-todo-add').on('click', function() {
                    var todo = {
                        text: $('#tb-todo-text').val(),
                        category: $('#tb-todo-category').val()
                    };
                    data.todos.add(todo)
                        .then(function(todo) {
                            todo = todo.result;
                            toastr.success('TODO ' + todo.text + ' added!');
                            context.redirect('#/todos');
                        });
                });

                return data.categories.get();
            }).then(function(categories){
                $('#tb-todo-category').autocomplete({
                    source: categories.result
                });
            });
    }

    return {
      all: all,
      add: add
    };
}());

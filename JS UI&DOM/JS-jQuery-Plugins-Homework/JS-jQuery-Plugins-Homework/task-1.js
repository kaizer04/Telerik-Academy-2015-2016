(function () {
    $.fn.dropdown = function () {
        var $this = $(this).hide();
        var options = $this.children();

        var $container = $('<div />')
                .addClass('dropdown-list').on('click', function () {
                    $this.children('option:selected').first().removeAttr('selected');
                    $($this.children()[$(this).attr('data-value')]).attr('selected', true);
                });

        $this.after($container);

        var $options = $('<div />')
                .addClass('options-container')
                .appendTo($container);

        for (var i = 0; i < options.length; i++) {
            var value = i + 1;
            var valueStr = "value-" + value;
            $('<div />')
                .addClass('dropdown-item')
                .attr('data-value', valueStr)
                .attr('data-index', i)
                .html($($this.children()[i]).html())
                .appendTo($options)
                ;
        }
    }
}());

function solve() {
    return function (selector) {
        $.fn.dropdown = function () {
            var $this = $(this).hide();
            var options = $this.children();

            var $container = $('<div />')
                    .addClass('dropdown-list').on('click', function () {
                        $this.children('option:selected').first().removeAttr('selected');
                        $($this.children()[$(this).attr('data-value')]).attr('selected', true);
                    });

            $this.after($container);

            var $options = $('<div />')
                    .addClass('options-container')
                    .appendTo($container);

            for (var i = 0; i < options.length; i++) {
                var value = i + 1;
                var valueStr = "value-" + value;
                $('<div />')
                    .addClass('dropdown-item')
                    .attr('data-value', valueStr)
                    .attr('data-index', i)
                    .html($($this.children()[i]).html())
                    .appendTo($options)
                ;
            }
        }
    };
}

//module.exports = solve;
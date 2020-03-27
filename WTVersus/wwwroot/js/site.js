$(document).ready(function () {
    $("#myInput1").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".dropdown-menu li").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

$(document).ready(function () {
    $("#myInput2").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".dropdown-menu li").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

$(document).ready(function () {
    $("#myInput3").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".dropdown-menu li").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

$(document).ready(function () {
    $("#myInput4").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".dropdown-menu li").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});


window.onload = function () {
    /* Тута ID таблицы */
    /* В строках где нужно подсвечивать зелёным большее пишешь класс high, где меньшее low */
    var table = document.getElementById('PlaneTable');
    if (table !== null) {
        /* Перебираю все строки */
        var rows = table.querySelectorAll('tr');
        rows.forEach(function (row, i, rows) {
            var direction;

            /*
              В переменную кладу инфу меньшее или большее подсвечивать,
            	либо завершаю итерацию, если не указан класс
            */
            if (row.classList.contains('high')) {
                direction = 1;
            } else if (row.classList.contains('low')) {
                direction = 0;
            } else {
                return;
            }

            /*
              Создаю коллекцию ключ/значение. 
              Где ключ это числовое значение, значение - массив ячеек с этим значением
            */
            var listItemByNumber = new Map();
            var cells = row.querySelectorAll('td');

            /*
            	Перебираю все ячейки в этой строке, если в них есть число заношу в коллекцию
            */
            cells.forEach(function (cell, j, cells) {
                var number = parseFloat(cell.innerText);
                if (isNaN(number)) {
                    cell.innerText = '';
                    return;
                }

                if (!listItemByNumber.has(number)) {
                    array = [];
                } else {
                    array = listItemByNumber.get(number)
                }

                array.push(cell);
                listItemByNumber.set(number, array);
            });

            if (listItemByNumber.size <= 1) {
                return;
            }

            /* 
            	Достаю из коллекции ключи в виде массива
              Получаю минимальное и максимальное (а оно же будет являться ключём в коллекции)
              Достаю по этому ключу и добавляю в переменные greenElements и redElements массив ячеек, которые нужно подсветить
            */
            var keys = Array.from(listItemByNumber.keys());
            var redElements, greenElements;
            if (direction == 1) {
                greenElements = listItemByNumber.get(Math.max.apply(null, keys));
                redElements = listItemByNumber.get(Math.min.apply(null, keys));
            } else {
                greenElements = listItemByNumber.get(Math.min.apply(null, keys));
                redElements = listItemByNumber.get(Math.max.apply(null, keys));
            }

            /* Прохожусь по клеткам и ставлю им соответствующие классы */
            greenElements.forEach(function (item, j, elems) {
                item.classList.add('green');
            });
            redElements.forEach(function (item, j, elems) {
                item.classList.add('red');
            });
        });
    }
}
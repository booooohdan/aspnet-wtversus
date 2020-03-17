$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".dropdown-menu li").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});


$(function () {
    function getNum(s) {
        var n = false;
        if (s.length) {
            n = parseInt(s, 10);
        }
        return n;
    }

    function getRowData(t) {
        var r = [],
            n;
        $("td", t).each(function (i, el) {
            n = getNum($(el).text());
            if (i > 0 && n) {
                r.push(n);
            }
        });
        return r;
    }

    $("#PlaneTable tbody tr").each(function (ind, row) {
        var values = getRowData($(row));
        var min = Math.min.apply(Math, values);
        var max = Math.max.apply(Math, values);
        console.log(values, min, max);
        if ($("td", row).eq(0).text() == "Climb rate" | "Turn time" |"Take-off weight") {
            $(row).addClass("low");
        } else {
            $(row).addClass("high");
        }
        $("td", row).each(function (j, cell) {
            if ($(cell).text().indexOf(min) == 0 && $(".min", row).length < 1) {
                $(this).addClass("min");
            }
            if ($(cell).text().indexOf(max) == 0 && $(".max", row).length < 1) {
                $(cell).addClass("max");
            }
        });
    });
});
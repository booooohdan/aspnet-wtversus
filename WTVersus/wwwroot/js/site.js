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

    $("#PlaneTable tbody tr:gt(6)").each(function (ind, row) {
        const values = getRowData($(row)),
            min = Math.min(...values),
            max = Math.max(...values)

        if ($("td", row).eq(0).text() == "Turn time") {
            $(row).addClass("low");
        } else
        if ($("td", row).eq(0).text() == "Course weapon") {
        } else
        if ($("td", row).eq(0).text() == "Repair cost") {
        $(row).addClass("low");
        } else
        if ($("td", row).eq(0).text() == "Take-off weight") {
            $(row).addClass("low");
        } else
        {
            $(row).addClass("high");
        }
        $("td", row).each(function (j, cell) {
            if (!/\d/.test($(cell).text()) && j > 0) $(cell).text('')
            if ($(cell).text().replace(/\D/g, '') == min) $(this).addClass("min")
            if ($(cell).text().replace(/\D/g, '') == max) $(this).addClass("max")
        });
    });
})
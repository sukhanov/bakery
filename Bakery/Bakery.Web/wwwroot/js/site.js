$(document).ready(function () {

    function loadData() {
        $.get("/api/product/get",
            function(data) {
                var tbody = "";
                if (data.length === 0)
                    tbody = "<tr><td colspan=\"7\">Нет данных.</td></tr>";
                else
                    for (var i = 0; i < data.length; i++) {
                        var date = new Date(data[i].postedAt);
                        var tr = "<tr>" +
                            "<td>" +
                            data[i].name +
                            "</td>" +
                            "<td>" +
                            data[i].bakingTime +
                            "</td>" +
                            "<td>" +
                            data[i].type +
                            "</td>" +
                            "<td>" +
                            data[i].startPrice +
                            "</td>" +
                            "<td>" +
                            data[i].currentPrice +
                            "</td>" +
                            "<td>" +
                            data[i].nextPrice +
                            "</td>" +
                            "<td>" +
                            data[i].nextPriceChangeTime +
                            "</td>" +
                            "</tr>";
                        tbody += tr;
                    }

                $("#productsBody").html(tbody);
            });
    }

    $("#refreshBtn").click(function() {
        loadData();
    });

    loadData();
});
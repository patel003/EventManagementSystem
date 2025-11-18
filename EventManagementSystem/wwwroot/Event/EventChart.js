function loadDonutChart() {
    $.ajax({
        url: "/Dashboard/DonutChart",
        type: "GET",
        success: function (res) {

            let labels = res.data.map(x => x.categorY_NAME);
            let series = res.data.map(x => x.totalEvents);

            var options = {
                chart: { type: 'donut' },
                series: series,
                labels: labels,
                legend: { position: "right" }
            };

            var chart = new ApexCharts(document.querySelector("#Dochart_11"), options);
            chart.render();
        }
    });
}


function loadPieChart() {
    $.ajax({
        url: "/Dashboard/PieChart",
        type: "GET",
        success: function (res) {
            let labels = res.data.map(x => x.categorY_NAME);
            let series = res.data.map(x => x.totalEvents);
            var options = {
                chart: { type: 'pie' },
                series: series,
                labels: labels
            };

            var chart = new ApexCharts(document.querySelector("#piechart_12"), options);
            chart.render();
        }
    });
}

function loadAreaChart() {
    $.ajax({
        url: "/Dashboard/AreaChart",
        type: "GET",
        success: function (res) {

            // Extract dynamic data
            let categories = res.data.map(x => x.monthName);
            let values = res.data.map(x => x.totalEvents);

            var options = {
                chart: { type: 'area' },
                xaxis: { categories: categories },
                series: [
                    {
                        name: "Events",
                        data: values
                    }
                ]
            };

            var chart = new ApexCharts(document.querySelector("#archart_2"), options);
            chart.render();
        }
    });
}


function loadColumnChart() {
    $.ajax({
        url: "/Dashboard/ColumnChart",
        type: "GET",
        success: function (res) {

            // Extract data
            let categories = res.data.map(x => x.event_Name);
            let values = res.data.map(x => x.totalParticipants);

            var options = {
                chart: { type: 'bar' },
                xaxis: { categories: categories },
                series: [
                    {
                        name: "Participants",
                        data: values
                    }
                ]
            };

            var chart = new ApexCharts(document.querySelector("#colchart_3"), options);
            chart.render();
        }
    });
}


$(document).ready(function () {
    loadDonutChart();
    loadPieChart();
    loadAreaChart();
    loadColumnChart();
});
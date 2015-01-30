function overallChartLive(data) {
    $.ajax({
        type: "GET",
        url: "Player/OverallChartLive",
        success: function (result) {
            var data = $.parseJSON(result);
            $('#overallChartLive').highcharts({
                title: {
                    text: 'Overall Live',
                    x: -20 //center
                },
                subtitle: {
                    text: '',
                    x: -20
                },
                xAxis: {
                    categories: data.x
                },
                yAxis: {
                    title: {
                        text: '$'
                    },
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: '#808080'
                    }]
                },
                tooltip: {
                    valueSuffix: '$'
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    borderWidth: 0
                },
                series: data.y
            });
        }
    });
}

function overallChartOnline(data) {
    $.ajax({
        type: "GET",
        url: "Player/OverallChartOnline",
        success: function (result) {
            var data = $.parseJSON(result);
            $('#overallChartOnline').highcharts({
                title: {
                    text: 'Overall Online',
                    x: -20 //center
                },
                subtitle: {
                    text: '',
                    x: -20
                },
                xAxis: {
                    categories: data.x
                },
                yAxis: {
                    title: {
                        text: '$'
                    },
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: '#808080'
                    }]
                },
                tooltip: {
                    valueSuffix: '$'
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    borderWidth: 0
                },
                series: data.y
            });
        }
    });
}

function overallChartWinAndLose() {
    $.ajax({
        type: "GET",
        url: "Player/OverallChartWinAndLose",
        success: function (result) {
            var data = $.parseJSON(result);
            Highcharts.getOptions().colors = Highcharts.map(Highcharts.getOptions().colors, function (color) {
                return {
                    radialGradient: { cx: 0.5, cy: 0.3, r: 0.7 },
                    stops: [
                        [0, color],
                        [1, Highcharts.Color(color).brighten(-0.3).get('rgb')] // darken
                    ]
                };
            });

            $('#overallChartWinAndLose').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: 'Overall Positive vs Negative days'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            },
                            connectorColor: 'silver'
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Positive vs Negative',
                    data: data
                }]
            });
        }
    });
}

function overallChartWinOnlineVsLive() {
    $.ajax({
        type: "GET",
        url: "Player/OverallChartWinOnlineVsLive",
        success: function (result) {
            var data = $.parseJSON(result);
            

            $('#overallChartWinOnlineVsLive').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: 'Overall Wins Onlive vs Live'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            },
                            connectorColor: 'silver'
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Online vs Live',
                    data: data
                }]
            });
        }
    });
}
// ChartS \\
var options = {
  
    stroke: {
      curve: 'smooth',
    },
    
    chart: {
      type: 'area', // Your chart type
      height: 100,
      width: 120,
      toolbar: {
        show: false // Hide the toolbar
      },
      zoom: {
        enabled: false,
      }
    },
  
    series: [{
      name: 'Sales',
      data: [32, 30, 45, 40, 49, 60, 50, 62] // Your data points
    }],
  
    legend: {
      show: false
    },
  
    tooltip: {
      custom: function({series, seriesIndex, dataPointIndex, w}) {
        return '<div class="arrow_box">' +
        '<span>' + series[seriesIndex][dataPointIndex] + '</span>' +
        '</div>'
      }
    },
  
    fill: {
      type: 'gradient'
    },
  
    xaxis: {
      labels: {
        show: false // Hide X-axis labels
      },
      axisBorder: {
        show: false // Hide X-axis border
      },
      axisTicks: {
        show: false // Hide X-axis ticks
      },
      tooltip: {
        enabled: false
      },
    },
  
    yaxis: {
      labels: {
        show: false // Hide Y-axis labels
      },
      axisBorder: {
        show: false // Hide Y-axis border
      },
      axisTicks: {
        show: false // Hide Y-axis ticks
      }
    },
  
    grid: {
      show: false
    },
  
    stroke: {
      width: 3
    },
  
    dataLabels: {
      enabled: false
    }
  }
  
  var optionsBig = {
    
    stroke: {
      curve: 'smooth',
    },
    
    chart: {
      type: 'area', // Your chart type
      height: 160*1.8,
      width: 230*3.7,
      toolbar: {
        show: false // Hide the toolbar
      },
      zoom: {
        enabled: false,
      }
    },
  
    series: [
      { 
        data: [20, 22, 31, 30, 28, 29, 35, 39, 34, 36, 45, 44]
      }
    ],
  
    fill: {
      type: 'gradient'
    },
  
    legend: {
      position: 'top',
    },
  
    title: {
      text: "Student count last year ( 2023 )",
      align: 'left',
      margin: 10,
      offsetX: 0,
      offsetY: 0,
      floating: false,
      style: {
        fontWeight:  'bold',
        fontSize:  '20px',  
      }
    },
  
    dataLabels: {
      enabled: false
    },
  
    xaxis: {
      categories: ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec']
    }
  }
  
  var optionsProg = {
    series: [89,82,18],
    chart: {
      height: 350,
      type: 'radialBar',
    },
  
    plotOptions: {
      radialBar: {
        dataLabels: {
          name: {
            fontSize: '22px',
          },
          value: {
            fontSize: '16px',
          },
          total: {
            show: true,
            label: 'Total hours',
            formatter: function (w) {
              // By default this function returns the average of all series. The below is just an example to show the use of custom formatter function
              return 97
            }
          }
        }
      }
    },
  
    stroke: {
      lineCap: "round",
    },
    labels: ['Assigned', 'Accepted', 'Declined'],
    colors: [ "#3479F9", "#20E647", "#000000"],
  };
  
  new ApexCharts(document.querySelector("#chart-prog"), optionsProg).render();
  
  new ApexCharts(document.querySelector("#chart-1"), options).render();
  
  options.colors = ['#27CEA7']
  new ApexCharts(document.querySelector("#chart-2"), options).render();
  
  options.colors = ['#6142FF']
  new ApexCharts(document.querySelector("#chart-3"), options).render();
  
  options.colors = ['#FF9F43']
  new ApexCharts(document.querySelector("#chart-4"), options).render();
  
  new ApexCharts(document.querySelector("#chart-5"), optionsBig).render();
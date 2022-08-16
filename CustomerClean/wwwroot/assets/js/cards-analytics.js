/**
 * Statistics Cards
 */

'use strict';
(function () {
  let cardColor, headingColor, axisColor, borderColor, shadeColor;

  if (isDarkStyle) {
    cardColor = config.colors_dark.cardColor;
    headingColor = config.colors_dark.headingColor;
    axisColor = config.colors_dark.axisColor;
    borderColor = config.colors_dark.borderColor;
    shadeColor = 'dark';
  } else {
    cardColor = config.colors.white;
    headingColor = config.colors.headingColor;
    axisColor = config.colors.axisColor;
    borderColor = config.colors.borderColor;
    shadeColor = 'light';
  }

  Apex.chart = {
		fontFamily: 'inherit',
		locales: [{
			"name": "fa",
			"options": {
				"months": ["ژانویه", "فوریه", "مارس", "آوریل", "می", "ژوئن", "جولای", "آگوست", "سپتامبر", "اکتبر", "نوامبر", "دسامبر"],
				"shortMonths": ["ژانویه", "فوریه", "مارس", "آوریل", "می", "ژوئن", "جولای", "آگوست", "سپتامبر", "اکتبر", "نوامبر", "دسامبر"],
				"days": ["یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"],
				"shortDays": ["ی", "د", "س", "چ", "پ", "ج", "ش"],
				"toolbar": {
					"exportToSVG": "دریافت SVG",
					"exportToPNG": "دریافت PNG",
					"menu": "فهرست",
					"selection": "انتخاب",
					"selectionZoom": "بزرگنمایی قسمت انتخاب شده",
					"zoomIn": "بزرگ نمایی",
					"zoomOut": "کوچک نمایی",
					"pan": "جا به جایی",
					"reset": "بازنشانی بزرگ نمایی"
				}
			}
		}],
		defaultLocale: "fa"
	}

  // Report Chart
  // --------------------------------------------------------------------

  // Radial bar chart functions
  function radialBarChart(color, value) {
    const radialBarChartOpt = {
      chart: {
        height: 50,
        width: 50,
        type: 'radialBar'
      },
      plotOptions: {
        radialBar: {
          hollow: {
            size: '25%'
          },
          dataLabels: {
            show: false
          },
          track: {
            background: borderColor
          }
        }
      },
      stroke: {
        lineCap: 'round'
      },
      colors: [color],
      grid: {
        padding: {
          top: -8,
          bottom: -10,
          left: -5,
          right: 0
        }
      },
      series: [value],
      labels: ['پیشرفت']
    };
    return radialBarChartOpt;
  }

  const ReportchartList = document.querySelectorAll('.chart-report');
  if (ReportchartList) {
    ReportchartList.forEach(function (ReportchartEl) {
      const color = config.colors[ReportchartEl.dataset.color],
        series = ReportchartEl.dataset.series;
      const optionsBundle = radialBarChart(color, series);
      const reportChart = new ApexCharts(ReportchartEl, optionsBundle);
      reportChart.render();
    });
  }

  // Analytics - Bar Chart
  // --------------------------------------------------------------------
  const analyticsBarChartEl = document.querySelector('#analyticsBarChart'),
    analyticsBarChartConfig = {
      chart: {
        height: 260,
        type: 'bar',
        toolbar: {
          show: false
        }
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '20%',
          borderRadius: 3,
          startingShape: 'rounded'
        }
      },
      dataLabels: {
        enabled: false
      },
      colors: [config.colors.primary, config.colors_label.primary],
      series: [
        {
          name: '1400',
          data: [8, 9, 15, 20, 14, 22, 29, 27, 13]
        },
        {
          name: '1401',
          data: [5, 7, 12, 17, 9, 17, 26, 21, 10]
        }
      ],
      grid: {
        borderColor: borderColor
      },
      xaxis: {
        categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر'],
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: axisColor
          }
        }
      },
      yaxis: {
        min: 0,
        max: 30,
        tickAmount: 3,
        labels: {
          style: {
            colors: axisColor
          }
        }
      },
      legend: {
        show: false
      },
      tooltip: {
        y: {
          formatter: function (val) {
            return val + ' هزار تومان';
          }
        }
      }
    };
  if (typeof analyticsBarChartEl !== undefined && analyticsBarChartEl !== null) {
    const analyticsBarChart = new ApexCharts(analyticsBarChartEl, analyticsBarChartConfig);
    analyticsBarChart.render();
  }

  // Referral - Line Chart
  // --------------------------------------------------------------------
  const referralLineChartEl = document.querySelector('#referralLineChart'),
    referralLineChartConfig = {
      series: [
        {
          name: 'سری 1',
          data: [0, 150, 25, 100, 15, 149]
        }
      ],
      chart: {
        height: 100,
        parentHeightOffset: 0,
        parentWidthOffset: 0,
        type: 'line',
        toolbar: {
          show: false
        }
      },
      markers: {
        size: 6,
        colors: 'transparent',
        strokeColors: 'transparent',
        strokeWidth: 4,
        discrete: [
          {
            fillColor: cardColor,
            seriesIndex: 0,
            dataPointIndex: 5,
            strokeColor: config.colors.success,
            strokeWidth: 4,
            size: 6,
            radius: 2
          }
        ],
        hover: {
          size: 7
        }
      },
      dataLabels: {
        enabled: false
      },
      stroke: {
        width: 4,
        curve: 'smooth'
      },
      grid: {
        show: false,
        padding: {
          top: -25,
          bottom: -20
        }
      },
      colors: [config.colors.success],
      xaxis: {
        show: false,
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          show: false
        }
      },
      yaxis: {
        labels: {
          show: false
        }
      }
    };

  if (typeof referralLineChartEl !== undefined && referralLineChartEl !== null) {
    const referralLineChart = new ApexCharts(referralLineChartEl, referralLineChartConfig);
    referralLineChart.render();
  }

  // Conversion - Bar Chart
  // --------------------------------------------------------------------
  const conversionBarChartEl = document.querySelector('#conversionBarchart'),
    conversionBarChartConfig = {
      chart: {
        height: 100,
        stacked: true,
        type: 'bar',
        toolbar: {
          show: false
        },
        sparkline: {
          enabled: true
        }
      },
      plotOptions: {
        bar: {
          columnWidth: '25%',
          borderRadius: 2,
          startingShape: 'rounded'
        },
        distributed: true
      },
      colors: [config.colors.primary, config.colors.warning],
      series: [
        {
          name: 'مشتریان جدید',
          data: [75, 150, 225, 200, 35, 50, 150, 180, 50, 150, 240, 140, 75, 35, 60, 120]
        },
        {
          name: 'مشتریان قدیمی',
          data: [-100, -55, -40, -120, -70, -40, -60, -50, -70, -30, -60, -40, -50, -70, -40, -50]
        }
      ],
      grid: {
        show: false,
        padding: {
          top: 0,
          bottom: -10
        }
      },
      legend: {
        show: false
      },
      dataLabels: {
        enabled: false
      },
      tooltip: {
        x: {
          show: false
        }
      }
    };

  if (typeof conversionBarChartEl !== undefined && conversionBarChartEl !== null) {
    const conversionBarChart = new ApexCharts(conversionBarChartEl, conversionBarChartConfig);
    conversionBarChart.render();
  }

  // Impression - Donut Chart
  // --------------------------------------------------------------------
  const impressionDonutChartEl = document.querySelector('#impressionDonutChart'),
    impressionDonutChartConfig = {
      chart: {
        height: 225,
        type: 'donut'
      },
      dataLabels: {
        enabled: false
      },
      series: [80, 30, 60],
      labels: ['اجتماعی', 'ایمیل', 'جستجو'],
      stroke: {
        width: 0,
        lineCap: 'round'
      },
      colors: [config.colors.primary, config.colors.info, config.colors.warning],
      plotOptions: {
        pie: {
          donut: {
            size: '90%',
            labels: {
              show: true,
              name: {
                fontSize: '0.938rem',
                offsetY: 22
              },
              value: {
                show: true,
                fontSize: '1.625rem',
                fontWeight: '500',
                color: headingColor,
                offsetY: -22,
                formatter: function (val) {
                  return val;
                }
              },
              total: {
                show: true,
                label: 'بازدید',
                color: config.colors.secondary,
                formatter: function (w) {
                  return w.globals.seriesTotals.reduce(function (a, b) {
                    return a + b;
                  }, 0);
                }
              }
            }
          }
        }
      },
      legend: {
        show: true,
        position: 'bottom',
        offsetY: 8,
        horizontalAlign: 'center',
        labels: {
          colors: axisColor,
          useSeriesColors: false
        },
        markers: {
          width: 10,
          height: 10,
          offsetX: -3
        }
      }
    };

  if (typeof impressionDonutChartEl !== undefined && impressionDonutChartEl !== null) {
    const impressionDonutChart = new ApexCharts(impressionDonutChartEl, impressionDonutChartConfig);
    impressionDonutChart.render();
  }

  // Growth - Radial Bar Chart
  // --------------------------------------------------------------------
  const growthRadialChartEl = document.querySelector('#growthRadialChart'),
    growthRadialChartConfig = {
      chart: {
        height: 185,
        type: 'radialBar',
        sparkline: {
          enabled: true
        }
      },
      grid: {
        show: false,
        padding: {
          top: -25
        }
      },
      plotOptions: {
        radialBar: {
          size: 100,
          startAngle: -135,
          endAngle: 135,
          offsetY: 10,
          hollow: {
            size: '55%'
          },
          track: {
            strokeWidth: '50%',
            background: cardColor
          },
          dataLabels: {
            value: {
              offsetY: -22,
              color: headingColor,
              fontWeight: 500,
              fontSize: '26px'
            },
            name: {
              fontSize: '15px',
              color: config.colors.secondary,
              offsetY: 20
            }
          }
        }
      },
      colors: [config.colors.danger],
      fill: {
        type: 'gradient',
        gradient: {
          shade: 'dark',
          type: 'horizontal',
          shadeIntensity: 0.5,
          gradientToColors: [config.colors.primary],
          inverseColors: true,
          opacityFrom: 1,
          opacityTo: 1,
          stops: [0, 100]
        }
      },
      stroke: {
        dashArray: 3
      },
      series: [78],
      labels: ['رشد']
    };

  if (typeof growthRadialChartEl !== undefined && growthRadialChartEl !== null) {
    const growthRadialChart = new ApexCharts(growthRadialChartEl, growthRadialChartConfig);
    growthRadialChart.render();
  }

  // Visits - Multi Radial Bar Chart
  // --------------------------------------------------------------------
  const visitsRadialChartEl = document.querySelector('#visitsRadialChart'),
    visitsRadialChartConfig = {
      chart: {
        height: 258,
        type: 'radialBar',
        sparkline: {
          enabled: true
        }
      },
      colors: [config.colors.primary, config.colors.danger, config.colors.warning],
      series: [75, 80, 85],
      plotOptions: {
        radialBar: {
          offsetY: -5,
          hollow: {
            size: '45%'
          },
          track: {
            margin: 10,
            background: cardColor
          },
          dataLabels: {
            name: {
              fontSize: '15px',
              colors: [config.colors.secondary],
              offsetY: 25
            },
            value: {
              fontSize: '2rem',
              fontWeight: 500,
              color: headingColor,
              offsetY: -20
            },
            total: {
              show: true,
              label: 'بازدید کل',
              fontSize: '15px',
              fontWeight: 400,
              color: config.colors.secondary
            }
          }
        }
      },
      grid: {
        padding: {
          top: -10,
          bottom: -10
        }
      },
      stroke: {
        lineCap: 'round'
      },
      labels: ['هدف', 'بازار', 'فروشگاه'],
      legend: {
        show: true,
        position: 'bottom',
        offsetY: 8,
        horizontalAlign: 'center',
        labels: {
          colors: axisColor,
          useSeriesColors: false
        },
        itemMargin: {
          horizontal: 15
        },
        markers: {
          width: 10,
          height: 10,
          offsetX: -3
        }
      }
    };

  if (typeof visitsRadialChartEl !== undefined && visitsRadialChartEl !== null) {
    const visitsRadialChart = new ApexCharts(visitsRadialChartEl, visitsRadialChartConfig);
    visitsRadialChart.render();
  }

  // Statistics - Radial Bar
  // --------------------------------------------------------------------
  const statisticsRadialChartEl = document.querySelector('#statisticsRadialChart'),
    statisticsRadialChartConfig = {
      series: [78],
      labels: ['بازدید کل'],
      chart: {
        height: 190,
        type: 'radialBar',
        sparkline: {
          enabled: true
        }
      },
      colors: [config.colors.warning],
      plotOptions: {
        radialBar: {
          offsetY: 0,
          startAngle: -140,
          endAngle: 140,
          hollow: {
            size: '78%',
            image: assetsPath + 'img/icons/unicons/rocket.png',
            imageWidth: 24,
            imageHeight: 24,
            imageOffsetY: -40,
            imageClipped: false
          },
          track: {
            strokeWidth: '100%',
            background: borderColor
          },
          dataLabels: {
            value: {
              offsetY: -5,
              color: headingColor,
              fontSize: '2rem',
              fontWeight: '500'
            },
            name: {
              offsetY: 40,
              color: config.colors.secondary,
              fontSize: '0.938rem',
              fontWeight: '400'
            }
          }
        }
      },
      stroke: {
        lineCap: 'round'
      },
      grid: {
        padding: {
          top: -7,
          bottom: 8
        }
      },
      states: {
        hover: {
          filter: {
            type: 'none'
          }
        },
        active: {
          filter: {
            type: 'none'
          }
        }
      }
    };
  if (typeof statisticsRadialChartEl !== undefined && statisticsRadialChartEl !== null) {
    const statisticsRadialChart = new ApexCharts(statisticsRadialChartEl, statisticsRadialChartConfig);
    statisticsRadialChart.render();
  }

  // Time Spent - Gauge Chart
  // --------------------------------------------------------------------
  const timeSpentGaugeChartEl = document.querySelector('#timeSpentGaugeChart'),
    timeSpentGaugeChartConfig = {
      series: [67],
      labels: ['مدت زمان'],
      chart: {
        height: 220,
        type: 'radialBar',
        sparkline: {
          enabled: true
        }
      },
      colors: [config.colors.success],
      plotOptions: {
        radialBar: {
          offsetY: 10,
          startAngle: -140,
          endAngle: 140,
          hollow: {
            size: '55%'
          },
          track: {
            strokeWidth: '100%',
            background: borderColor
          },
          dataLabels: {
            name: {
              offsetY: -10,
              color: headingColor,
              fontSize: '1.125rem'
            },
            value: {
              offsetY: 7,
              color: config.colors.secondary,
              fontSize: '0.938rem',
              fontWeight: 500,
              formatter: function (val) {
                return val + ' دقیقه';
              }
            }
          }
        }
      },
      stroke: {
        lineCap: 'round'
      },
      grid: {
        padding: {
          top: -35,
          left: -15,
          right: -15,
          bottom: 7
        }
      },
      states: {
        hover: {
          filter: {
            type: 'none'
          }
        },
        active: {
          filter: {
            type: 'none'
          }
        }
      }
    };
  if (typeof timeSpentGaugeChartEl !== undefined && timeSpentGaugeChartEl !== null) {
    const timeSpentGaugeChart = new ApexCharts(timeSpentGaugeChartEl, timeSpentGaugeChartConfig);
    timeSpentGaugeChart.render();
  }

  // Revenue Growth - Bar Chart
  // --------------------------------------------------------------------
  const revenueGrowthChartEl = document.querySelector('#revenueGrowthChart'),
    revenueGrowthChartConfig = {
      chart: {
        height: 100,
        type: 'bar',
        stacked: true,
        toolbar: {
          show: false
        }
      },
      grid: {
        show: false,
        padding: {
          left: 0,
          right: 0,
          top: -15,
          bottom: -20
        }
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '20%',
          borderRadius: 2,
          startingShape: 'rounded',
          endingShape: 'flat'
        }
      },
      legend: {
        show: false
      },
      dataLabels: {
        enabled: false
      },
      colors: [config.colors.info, config.colors_label.secondary],
      series: [
        {
          name: '1400',
          data: [80, 60, 125, 40, 50, 30, 70, 80, 100, 40, 80, 60, 120, 75, 25, 135, 65]
        },
        {
          name: '1401',
          data: [50, 65, 40, 100, 30, 30, 80, 20, 50, 45, 30, 90, 70, 40, 50, 40, 60]
        }
      ],
      xaxis: {
        categories: ['10', '', '', '', '', '', '', '', '15', '', '', '', '', '', '', '', '20'],
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: axisColor
          },
          offsetY: -5
        }
      },
      yaxis: {
        show: false,
        floating: true
      },
      tooltip: {
        x: {
          show: false
        }
      }
    };
  if (typeof revenueGrowthChartEl !== undefined && revenueGrowthChartEl !== null) {
    const revenueGrowthChart = new ApexCharts(revenueGrowthChartEl, revenueGrowthChartConfig);
    revenueGrowthChart.render();
  }

  // Total Earning - Donut Chart
  // --------------------------------------------------------------------
  const totalEarningChartEl = document.querySelector('#totalEarningChart'),
    totalEarningChartConfig = {
      chart: {
        height: 130,
        width: 130,
        type: 'donut'
      },
      dataLabels: {
        enabled: false
      },
      grid: {
        padding: {
          top: -11,
          bottom: -4,
          left: -8,
          right: 0
        }
      },
      series: [60, 45, 60],
      labels: ['اجتماعی', 'ایمیل', 'جستجو'],
      stroke: {
        width: 8,
        lineCap: 'round',
        colors: cardColor
      },
      colors: [config.colors.primary, config.colors.warning, config.colors.success],
      plotOptions: {
        pie: {
          donut: {
            size: '75%',
            labels: {
              show: true,
              name: {
                fontSize: '0.938rem',
                offsetY: -14
              },
              value: {
                show: true,
                fontSize: '1.625rem',
                fontWeight: '500',
                color: headingColor,
                offsetY: 6,
                formatter: function (val) {
                  return val + '%';
                }
              },
              total: {
                show: true,
                label: 'مجموع',
                color: config.colors.secondary,
                formatter: function (w) {
                  return w.globals.seriesTotals.reduce(function (a, b) {
                    return a + b;
                  }, 0);
                }
              }
            }
          }
        }
      },
      legend: {
        show: false
      },
      states: {
        active: {
          filter: {
            type: 'none'
          }
        }
      }
    };

  if (typeof totalEarningChartEl !== undefined && totalEarningChartEl !== null) {
    const totalEarningChart = new ApexCharts(totalEarningChartEl, totalEarningChartConfig);
    totalEarningChart.render();
  }

  // Order Summary - Area Chart
  // --------------------------------------------------------------------
  const orderSummaryEl = document.querySelector('#orderSummaryChart'),
    orderSummaryConfig = {
      chart: {
        height: 255,
        type: 'area',
        toolbar: false,
        dropShadow: {
          enabled: true,
          top: 18,
          left: 2,
          blur: 3,
          color: config.colors.primary,
          opacity: 0.15
        }
      },
      markers: {
        size: 6,
        colors: 'transparent',
        strokeColors: 'transparent',
        strokeWidth: 4,
        discrete: [
          {
            fillColor: cardColor,
            seriesIndex: 0,
            dataPointIndex: 9,
            strokeColor: config.colors.primary,
            strokeWidth: 4,
            size: 6,
            radius: 2
          }
        ],
        hover: {
          size: 7
        }
      },
      series: [
        {
          name: 'سری 1',
          data: [15, 18, 13, 19, 16, 31, 18, 26, 23, 39]
        }
      ],
      dataLabels: {
        enabled: false
      },
      stroke: {
        curve: 'smooth',
        lineCap: 'round'
      },
      colors: [config.colors.primary],
      fill: {
        type: 'gradient',
        gradient: {
          shade: shadeColor,
          shadeIntensity: 0.8,
          opacityFrom: 0.7,
          opacityTo: 0.25,
          stops: [0, 95, 100]
        }
      },
      grid: {
        show: true,
        borderColor: borderColor,
        padding: {
          top: -15,
          bottom: -10,
          left: 15,
          right: 10
        }
      },
      xaxis: {
        categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی'],
        labels: {
          offsetX: 0,
          style: {
            colors: axisColor,
            fontSize: '13px'
          }
        },
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        lines: {
          show: false
        }
      },
      yaxis: {
        labels: {
          offsetX: 7,
          formatter: function (val) {
            return val + ' تومان';
          },
          style: {
            fontSize: '13px',
            colors: axisColor
          }
        },
        min: 0,
        max: 40,
        tickAmount: 4
      }
    };
  if (typeof orderSummaryEl !== undefined && orderSummaryEl !== null) {
    const orderSummary = new ApexCharts(orderSummaryEl, orderSummaryConfig);
    orderSummary.render();
  }
})();

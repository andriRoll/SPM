     // char-js
    var randomScalingFactor = function(){ return Math.round(Math.random()*100)};

    var barChartData = {
        labels : ["January","February","March","April","May","June","July","Agustus","September","Oktober","November","Desember"],
        datasets : [
            {
                fillColor : "rgba(220,220,220,0.5)",
                strokeColor : "rgba(220,220,220,0.8)",
                highlightFill: "rgba(220,220,220,0.75)",
                highlightStroke: "rgba(220,220,220,1)",
                data : [randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor()]
            },
            {
                fillColor : "rgba(151,187,205,0.5)",
                strokeColor : "rgba(151,187,205,0.8)",
                highlightFill : "rgba(151,187,205,0.75)",
                highlightStroke : "rgba(151,187,205,1)",
                data : [randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor()]
            }
        ]

    }

    // number-animate
    window.onload = function(){
        var ctx = document.getElementById("canvas").getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive : true
        });
    }

      $('#num').animateNumber(
    {
      number: 1000,
      
      
      numberStep: function(now, tween) {
        var floored_number = Math.floor(now),
            target = $(tween.elem);
        
        target.text(floored_number);
      }
    },
    5000
  )    

      // number-animate1
       window.onload = function(){
        var ctx = document.getElementById("canvas").getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive : true
        });
    }

      $('#num1').animateNumber(
    {
      number: 1000,
      
      
      numberStep: function(now, tween) {
        var floored_number = Math.floor(now),
            target = $(tween.elem);
        
        target.text(floored_number);
      }
    },
    5000
  )  

     // number-animate2
       window.onload = function(){
        var ctx = document.getElementById("canvas").getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive : true
        });
    }

      $('#num2').animateNumber(
    {
      number: 1000,
      
      
      numberStep: function(now, tween) {
        var floored_number = Math.floor(now),
            target = $(tween.elem);
        
        target.text(floored_number);
      }
    },
    5000
  )

     // number-animate3
       window.onload = function(){
        var ctx = document.getElementById("canvas").getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive : true
        });
    }

      $('#num3').animateNumber(
    {
      number: 1000,
      
      
      numberStep: function(now, tween) {
        var floored_number = Math.floor(now),
            target = $(tween.elem);
        
        target.text(floored_number);
      }
    },
    5000
  )

     // number-animate4
       window.onload = function(){
        var ctx = document.getElementById("canvas").getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive : true
        });
    }

      $('#num4').animateNumber(
    {
      number: 1000,
      
      
      numberStep: function(now, tween) {
        var floored_number = Math.floor(now),
            target = $(tween.elem);
        
        target.text(floored_number);
      }
    },
    5000
  )

     // number-animate5
       window.onload = function(){
        var ctx = document.getElementById("canvas").getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive : true
        });
    }

      $('#num5').animateNumber(
    {
      number: 1000,
      
      
      numberStep: function(now, tween) {
        var floored_number = Math.floor(now),
            target = $(tween.elem);
        
        target.text(floored_number);
      }
    },
    5000
  )

    // pie-js
var txtinputsocer3 = document.getElementById("txtinputscore3");

$(function() {
    $('.chart').easyPieChart({
      easing: 'easeOutElastic',
      delay: 3000,
      barColor: '#69c',
      trackColor: '#ace',
      scaleColor: false,
      lineWidth: 20,
      trackWidth: 16,
      lineCap: 'butt',
      onStep: function(from, to, percent) {
        $(this.el).find('.percent').text(Math.round(percent));
      }
    });
    var chart = window.chart = $('.chart').data('easyPieChart');
    $('.js_update').on('click', function() {
      chart.update(document.getElementById());
    });
  });

// ------



$(function () {    
});

function showLine(dataLine) {
    
    alert("in line");

    initLine();

    cargarGraficoLinea(dataLine);

    marginContainer.append('g')
      .attr('class', 'x axis')
      .attr('transform', 'translate(0,' + height + ')')
      .call(xAxis);

    marginContainer.append('g')
      .attr('class', 'y axis')
      .call(yAxis)
      .append('text')
      .attr('transform', 'rotate(-90)')
      .attr('y', '1.5em')
      .style('text-anchor', 'end')
      .text('Valor');

    marginContainer.append('path')
      .datum(startData)
      .attr('class', 'line')
      .attr('d', line)
      .transition()
      .duration(500)
      .ease('quad')
      .attrTween('d', function () {
          var interpolator = d3.interpolateArray(startData, dataLine);

          return function (t) {
              return line(interpolator(t));
          }
      })
      .each('end', function () {
          drawCircles(dataLine, marginContainer);
      });

    marginContainer.append('path')
      .datum(startData)
      .attr('class', 'area')
      .attr('d', area)
      .transition()
      .duration(500)
      .ease('quad')
      .attrTween('d', function () {
          var interpolator = d3.interpolateArray(startData, dataLine);

          return function (t) {
              return area(interpolator(t));
          }
      });

    d3.select(window).on('resize', function () {
        resize(dataLine);
    });


    updateData(line);
}

var chartContainer;
var svg;
var marginContainer;
var x;
var y;
var xAxis;
var yAxis;
var width;
var height;
var line;
var area;
var startData;

var margin = { top: 20, right: 30, bottom: 30, left: 40 };
var maxWidth = 800 - margin.left - margin.right;

var detailWidth = 150;
var detailHeight = 75;
var detailMargin = 15;

function initLine() {
    chartContainer = d3.select('.chart-container');
    svg = chartContainer.append('svg');
    marginContainer = svg.append('g').attr('class', 'margin-container');
}

function drawCircle(datum, index) {
    circleContainer.datum(datum)
      .append('circle')
      .attr('class', 'circle')
      .attr('r', 0)
      .attr(
        'cx',
        function (d) {
            return x(d.Mes) + x.rangeBand() / 2;
        }
      )
      .attr(
        'cy',
        function (d) {
            return y(d.Valor);
        }
      )
      .on('mouseenter', function (d) {
          d3.select(this)
            .attr(
              'class',
              'circle active'
            )
            .attr('r', 7);

          d.active = true;

          showCircleDetail(d);
      })
      .on('mouseout', function (d) {
          d3.select(this)
            .attr(
              'class',
              'circle'
            )
            .attr('r', 6);

          if (d.active) {
              hideCircleDetails();

              d.active = false;
          }
      })
      .on('click touch', function (d) {
          if (d.active) {
              showCircleDetail(d)
          } else {
              hideCircleDetails();
          }
      })
      .transition()
      .delay(100 * index)
      .duration(750)
      .ease('elastic', 1.5, .75)
      .attr('r', 6)
    ;
}

function drawCircles(datos, container) {
    circleContainer = container.append('g').attr('class', 'circles');
    datos.forEach(function (datum, index) {
        drawCircle(datum, index);
    });
}

function hideCircleDetails() {
    circleContainer.selectAll('.bubble')
      .remove();
}

function showCircleDetail(datos) {
    var details = circleContainer.append('g')
      .attr('class', 'bubble')
      .attr(
        'transform',
        function () {
            var result = 'translate(';

            var xVal = x(datos.Mes) - detailWidth / 2;
            if (xVal + detailWidth > width) {
                xVal = width - detailWidth;
            }
            else if (xVal < 0) {
                xVal = 0;
            }

            result += xVal;
            result += ', ';
            result += y(datos.Valor) - detailHeight - detailMargin;
            result += ')';

            return result;
        }
      );

    details.append('rect')
      .attr('width', detailWidth)
      .attr('height', detailHeight)
      .attr('rx', 5)
      .attr('ry', 5);

    var text = details.append('text')
      .attr('class', 'text');

    text.append('tspan')
      .attr('class', 'price')
      .attr('x', detailWidth / 2)
      .attr('y', detailHeight / 3)
      .attr('text-anchor', 'middle')
      .text('Valor: ' + datos.Valor);

    text.append('tspan')
      .attr('class', 'date')
      .attr('x', detailWidth / 2)
      .attr('y', detailHeight / 4 * 3)
      .attr('text-anchor', 'middle')
      .text('Mes: ' + datos.Mes);
}

function updateData(dataLine) {

    cargarGraficoLinea(dataLine);

    marginContainer.select('.x.axis')
      .transition()
      .attr('transform', 'translate(0,' + height + ')')
      .call(xAxis);


    marginContainer.select('.y.axis')
      .transition()
      .call(yAxis);

    marginContainer.select('.circles').remove();

    marginContainer.select('.line')
      .transition()
      .duration(500)
      .ease('quad')
      .attrTween('d', function () {
          var interpolator = d3.interpolateArray(startData, dataLine);

          return function (t) {
              return line(interpolator(t));
          }
      })
      .each('end', function () {
          drawCircles(dataLine, marginContainer);
      });

    marginContainer.select('.area')
      .transition()
      .duration(500)
      .ease('quad')
      .attrTween('d', function () {
          var interpolator = d3.interpolateArray(startData, dataLine);

          return function (t) {
              return area(interpolator(t));
          }
      });
}

function getDimensions() {
    var containerWidth = parseInt(d3.select('.chart-container').style('width'));
    margin.top = 20;
    margin.right = 30;
    margin.left = 60;
    margin.bottom = 30;

    width = containerWidth - margin.left - margin.right;
    if (width > maxWidth) {
        width = maxWidth;
    }
    height = .75 * width;
}

function resize(dataLine) {
    updateData(dataLine);
}

function cargarGraficoLinea(dataLine) {

    getDimensions();

    svg.attr("width", width + margin.left + margin.right)
      .attr("height", height + margin.top + margin.bottom);

    marginContainer
      .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    x = d3.scale.ordinal().rangeRoundBands([0, width]);
    x.domain(dataLine.map(function (d) { return d.Mes; }));

    xAxis = d3.svg.axis().scale(x).orient("bottom");

    y = d3.scale.linear().range([height, 0]);
    y.domain([0, d3.max(dataLine, function (d) { return d.Valor; }) * 1.25]);

    area = d3.svg.area()
      .x(function (d) { return x(d.Mes) + x.rangeBand() / 2; })
      .y0(height)
      .y1(function (d) { return y(d.Valor); });

    line = d3.svg.area()
      .x(function (d) { return x(d.Mes) + x.rangeBand() / 2; })
      .y(function (d) { return y(d.Valor); });

    startData = dataLine.map(function (datum) {
        return {
            Valor: 0
        };
    });

    yAxis = d3.svg.axis()
      .scale(y)
      .orient('left');
}

var datos = [
    {
        Mes: 'Enero',
        Valor: 0.02
    },
    {
        Mes: 'Marzo',
        Valor: 0.04
    },
    {
        Mes: 'Abril',
        Valor: 0.10
    },
    {
        Mes: 'Mayo',
        Valor: 0.50
    }
];
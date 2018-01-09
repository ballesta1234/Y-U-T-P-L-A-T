$(function () {

    jQuery('.detalleGrafico').hide();

    jQuery.noConflict();

    // top left, ubicacion
    var margin = { top: 40, right: 0, bottom: 0, left: 30 },

        dim_1 = [
            { "mati": "CPI Servicios", "value": 10 },
            { "mati": "CPI Proyectos llave en mano", "value": 10 },
            { "mati": "% Retrabajo por detección externa", "value": 10 },
            { "mati": "Grado de satisfacción de los alumnos en cuanto al curso en general", "value": 10 },
            { "mati": "Personal que renuncia por año (acumulado)", "value": 10 },
            { "mati": "Solicitudes de acción aplicadas sobre solicitud de acción requeridas", "value": 10 }
        ],
        dim_2 = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],

        gridSize = 40,

        width = (gridSize + 30) * dim_2.length + gridSize + 700,
        height = gridSize * dim_1.length + gridSize;

    var svg = d3.select("#chart").append("svg")
        .attr("width", (gridSize + 30) * dim_2.length + gridSize + 100)
        .attr("height", height)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    var data = obtenerValores();

    /*
    var data = [
        { "dim1": 1, "dim2": 1, "value": Math.random() },
        { "dim1": 1, "dim2": 2, "value": Math.random() },
        { "dim1": 1, "dim2": 3, "value": Math.random() },
        { "dim1": 1, "dim2": 4, "value": Math.random() },
        { "dim1": 1, "dim2": 5, "value": Math.random() },
        { "dim1": 1, "dim2": 6, "value": Math.random() },
        { "dim1": 1, "dim2": 7, "value": Math.random() },
        { "dim1": 1, "dim2": 8, "value": Math.random() },
        { "dim1": 1, "dim2": 9, "value": Math.random() },
        { "dim1": 1, "dim2": 10, "value": Math.random() },
        { "dim1": 1, "dim2": 11, "value": Math.random() },
        { "dim1": 1, "dim2": 12, "value": Math.random() },
        { "dim1": 2, "dim2": 1, "value": Math.random() },
        { "dim1": 2, "dim2": 2, "value": Math.random() },
        { "dim1": 2, "dim2": 3, "value": Math.random() },
        { "dim1": 2, "dim2": 4, "value": Math.random() },
        { "dim1": 2, "dim2": 5, "value": Math.random() },
        { "dim1": 2, "dim2": 6, "value": Math.random() },
        { "dim1": 2, "dim2": 7, "value": Math.random() },
        { "dim1": 2, "dim2": 8, "value": Math.random() },
        { "dim1": 5, "dim2": 1, "value": Math.random() }
    ];
    */

    //var colors = ['red','#ffffbf','#91cf60', 'green', 'blue']
    var colors = ['#DF0101', '#F79F81', '#F7FE2E', '#81F781', '#0B610B']

    var colorScale = d3.scale.quantile()
        .domain([0, 1])
        .range(colors);

    var tip = d3.tip()
                .attr('class', 'd3-tip')
                .style("visibility", "visible")
                .offset([0, 0])
                .html(function (d) {
                    return "Valor:  <span style='color:blue'>" + d.value;
                });

    tip(svg.append("g"));

    var indicadorElegido;

    // Etiquetas tipo meses
    var dim1Labels = svg.selectAll(".dim1Label")
      .data(dim_1)
      .enter()
        .append("a").attr("xlink:href", function (d) { return "#" }).attr("xlink:title", function (d) { return d.mati; })
        .append("text")
        .text(function (d) {
            if (d.mati.length >= 14)
                return d.mati.substring(0, 11) + '...';

            return d.mati;
        })
        .attr("x", +70)
        .attr("y", function (d, i) { return i * gridSize; })
        .style("text-anchor", "end")
        .attr("transform", "translate(-6," + gridSize / 1.5 + ")")
        .attr("class", "mono1")
        .on('click',
            function (d) {
                      
                if (d3.select(this).classed("mono1")) {
                    jQuery('.detalleGrafico').show();

//                    scrollToAnchor('gaugeAncla');

                }
                else {
                    jQuery('.detalleGrafico').toggle();
                }
                
                if (jQuery('.detalleGrafico').is(":visible")) {
                    onDocumentReadyGauge(Math.random());
                }
               
                if (indicadorElegido !== undefined) {
                    indicadorElegido.classed("mono1", true);
                    indicadorElegido.classed("text-mono1-hover", false);
                }

                indicadorElegido = d3.select(this);
                
                d3.select(this).attr("class", "mono1 text-mono1-hover")
                d3.select(this).classed("mono1", false);
                d3.select(this).classed("text-mono1-hover", true);
               
            });

    // Etiquetas tipo nombre indicadores
    var dim2Labels = svg.selectAll(".dim2Label")
        .data(dim_2)
        .enter().append("text")
            .text(function (d) { return d; })
            .attr("x", function (d, i) { return (i + 1) * +71; })
            .attr("y", 0)
            .style("text-anchor", "middle")
            .attr("transform", "translate(" + gridSize / 2 + ", -6)")
            .attr("class", "mono");

    var heatMap = svg.selectAll(".dim2")
        .data(data)
        .enter().append("rect")
            .attr("x", function (d) { return ((d.dim2 - 1) * (gridSize + 30)) + 70; })
            .attr("y", function (d) { return (d.dim1 - 1) * gridSize; })
            .attr("rx", 3) // redondeado de la celda
            .attr("ry", 3) // redondeado de la celda
            .attr("width", (gridSize + 30) - 2)
            .attr("height", gridSize - 2)
            .style("fill", "gray")
            .attr("class", "square")
            .on('mouseover', tip.show)
            .on('mouseout', tip.hide)
            .on('click', function (d) {
                jQuery(".modal-body #hola").text('Valor: ' + d.value);
                jQuery('#exampleModal').modal('show');
            });

    heatMap.transition().style("fill", function (d) { return colorScale(d.value); });

    heatMap.append("title").text(function (d) { return d.value; });
});

function abrirGrafico(indicador) {
    jQuery('.detalleGrafico').show();
}
$(function () {

    jQuery('.detalleGrafico').hide();

    jQuery.noConflict();

    // top left, ubicacion
    var margin = { top: 40, right: 0, bottom: 0, left: 30 };

    var heatMap = obtenerHeatMapViewModel();

    var gridSize = 40;
    var width = (gridSize + 30) * heatMap.Meses.length + gridSize + 700;
    var height = gridSize * heatMap.FilasHeatMapViewModel.length + gridSize;

    var svg = d3.select("#chart").append("svg")
        .attr("width", (gridSize + 30) * heatMap.Meses.length + gridSize + 100)
        .attr("height", height)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    var tip = d3.tip()        
        .attr('class', 'd3-tip')   
        .style("visibility", "visible")
        .offset([0, 0])
        .html(function (d) {
            return "Valor:  <span style='color:blue'>" + d.Medicion;
        });

    tip(svg.append("g"));

    var indicadorElegido;

    // Etiquetas tipo meses
    var dim1Labels = svg.selectAll(".dim1Label")
      .data(heatMap.FilasHeatMapViewModel)
      .enter()
        .append("a").attr("xlink:href", function (d) { return "#" }).attr("xlink:title", function (d) { return d.NombreIndicador; })
        .append("text")
        .text(function (d) {
            if (d.NombreIndicador.length >= 14)
                return d.NombreIndicador.substring(0, 11) + '...';
            return d.NombreIndicador;
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
                    //scrollToAnchor('gaugeAncla');
                }
                else {
                    jQuery('.detalleGrafico').toggle();
                }

                if (jQuery('.detalleGrafico').is(":visible")) {
                    var gauge = obtenerGaugeViewModel(d.Grupo);
                    onDocumentReadyGauge(gauge);

                    var line = obtenerLineViewModel(d.Grupo);
                    showLine(line, gauge.NombreIndicador);                    
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
        .data(heatMap.Meses)
        .enter().append("text")
            .text(function (d) { return d; })
            .attr("x", function (d, i) { return (i + 1) * +71; })
            .attr("y", 0)
            .style("text-anchor", "middle")
            .attr("transform", "translate(" + gridSize / 2 + ", -6)")
            .attr("class", "mono");

    var heatMapGrafico = svg.selectAll(".dim2")
        .data(heatMap.Celdas)
        .enter().append("rect")
            .attr("x", function (d) { return ((d.Mes - 1) * (gridSize + 30)) + 70; })
            .attr("y", function (d) { return (d.IndiceIndicador - 1) * gridSize; })
            .attr("rx", 3) // redondeado de la celda
            .attr("ry", 3) // redondeado de la celda
            .attr("width", (gridSize + 30) - 2)
            .attr("height", gridSize - 2)
            .style("fill", "gray")
            .attr("class", "square")
            .on('mouseover', function (d, i) {
                if (d.MedicionCargada)
                    tip.show(d, i);
            })
            .on('mouseout', tip.hide)
            .on('click', function (d) {                
                abrirModalCargaMedicion(d.IdIndicador, d.Mes);
            });

    heatMapGrafico.transition().style("fill", function (d) { return d.ColorMeta; });

    heatMapGrafico.append("title").text(function (d) { return d.Medicion; });
});

function abrirGrafico(indicador) {
    jQuery('.detalleGrafico').show();
}

var dictionaryIndicadoresPorArea = {};

$(function () {

    jQuery('.detalleGrafico').css("visibility", "hidden");

    jQuery.noConflict();

    var margin = { top: 40, right: 0, bottom: 0, left: 30 };

    var heatMap = obtenerHeatMapViewModel();

    var cantIndicadoresPorArea = contarIndicadoresPorArea(heatMap)

    var contentWidth = parseInt(d3.select('#chart').style('width'));

    var gridSize = 40;
    var height = (gridSize - 8) * heatMap.FilasHeatMapViewModel.length + gridSize + 1;

    var svg = d3.select("#chart").append("svg")
        .attr("width", 940)
        .attr("height", height)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");
    
    svg.append('text')
      .attr("x", -10)
      .attr("y", 0)
      .style("text-anchor", "middle")
      .attr("transform", "translate(" + gridSize / 2 + ", -6)")
      .attr("class", "mono")
      .text('Área');

    svg.append('text')
      .attr("x", 152)
      .attr("y", 0)
      .style("text-anchor", "middle")
      .attr("transform", "translate(" + gridSize / 2 + ", -6)")
      .attr("class", "mono")
      .text('Indicador');

    // Nombreas áreas
    var offsetTextoArea = 0;
    var offsetTextoAreaAnterior = 0;

    var etiquetasAreas = svg.selectAll(".areas")
       .data(cantIndicadoresPorArea)
       .enter()
       .append("text")
       .attr("transform", function (d, i) {
           if (d[1] <= 2)
               return "translate(-6," + gridSize / 1.5 + ")";
           else
               return "rotate(-90)";
       })
       .text(function (d) {
           var nombreArea = d[0];
           return nombreArea;
       })
       .attr("y", function (d, i) {
           if (i > 0) {
               offsetTextoArea += offsetTextoAreaAnterior;
           }
           offsetTextoAreaAnterior = d[1];

           if (d[1] <= 2) {
               return (offsetTextoArea * (gridSize - 8)) - 12;
           }
       })
       .style("text-anchor", "end")
       .attr("class", "mono")
       .call(wrap, true, true);

    svg.append("line")
       .attr("x1", -30)
       .attr("y1", 0)
       .attr("x2", 300)
       .attr("y2", 0)
       .attr("stroke-width", 0.4)
       .attr("stroke", "gray");

    var offsetLineaY1 = 0;
    var offsetLineaY2 = 0;

    svg.selectAll(".lineas")
       .data(cantIndicadoresPorArea)
       .enter()
       .append("line")
       .attr("x1", -30)
       .attr("y1", function (d, i) { offsetLineaY1 += d[1]; return (offsetLineaY1) * (gridSize - 8); })
       .attr("x2", 300)
       .attr("y2", function (d, i) { offsetLineaY2 += d[1]; return (offsetLineaY2) * (gridSize - 8); })
       .attr("stroke-width", 0.4)
       .attr("stroke", "gray");

    var indicadorElegido;

    // Etiquetas tipo nombre indicadores    
    var dim1Labels = svg.selectAll(".dim1Label")
      .data(heatMap.FilasHeatMapViewModel)
      .enter()
        .append("a").attr("xlink:href", function (d) { return "#" }).attr("xlink:title", function (d) { return d.NombreIndicador; })
        .append("text")
        .text(function (d) {
            return d.NombreIndicador;
        })
        .attr("x", 150)
        .attr("y", function (d, i) {
            var offsetYEtiqueta = 8;
            if (d.NombreIndicador.length >= 45) {
                offsetYEtiqueta = 12;
            }
            return (i * (gridSize - 8)) - offsetYEtiqueta;
        })
        .attr("transform", "translate(-6," + gridSize / 1.5 + ")")
        .attr("class", "mono1")
        .style("cursor", "pointer")
        .on('click',
            function (d) {

                if (d3.select(this).classed("mono1")) {
                    jQuery('.detalleGrafico').show();
                    jQuery('.detalleGrafico').css("visibility", "visible");
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
            })
            .call(wrapHorizontal, 234, 62);

    // Etiquetas tipo meses
    var dim2Labels = svg.selectAll(".dim2Label")
        .data(heatMap.Meses)
        .enter().append("text")
            .text(function (d) { return d.substring(0, 3) + '.' })
            .attr("x", function (d, i) { return (i + 1) * 50 + 252; })
            .attr("y", 0)
            .style("text-anchor", "middle")
            .attr("transform", "translate(" + gridSize / 2 + ", -6)")
            .attr("class", "mono");

    var heatMapGrafico = svg.selectAll(".dim2")
        .data(heatMap.Celdas)
        .enter().append("rect")
            .attr("x", function (d) { return ((d.Mes - 1) * (gridSize + 10)) + 300; })
            .attr("y", function (d) { return (d.IndiceIndicador - 1) * (gridSize - 8); })
            .attr("rx", 3) // redondeado de la celda
            .attr("ry", 3) // redondeado de la celda
            .attr("width", gridSize + 8) // ancho de la celda
            .attr("height", gridSize - 10) // alto de la celda
            .style("fill", "gray")
            .attr("class", "square")          
            .on('click', function (d) {
                abrirModalCargaMedicion(d.IdIndicador, d.Mes, d.IdMedicion, d.NombreMes, d.GrupoIndicador, d.TieneAccesoLecturaEscritura, d.EsAutomatico, d.NombreIndicador);
            });

    svg.selectAll(".dim2")
        .data(heatMap.Celdas)
        .enter().append("text")        
        .attr("x", function (d) {

            var i = d.Medicion.toString().length;

            if (d.NoAplica) {
                i = 3;
            }

            return ((d.Mes - 1) * (gridSize + 10)) + 300 + (((gridSize + 8) - (7 * i)) / 2);
        })
        .attr("y", function (d) { return (d.IndiceIndicador - 1) * (gridSize - 8) + 20; })
        .style("fill", "rgb(32,32,32)")
        .style("cursor", "pointer")
        .text(function (d) {
            if (d.MedicionCargada)
                return d.Medicion;
            else if (d.NoAplica)
                return "N/A";
            else
                return "";
        })        
        .on('click', function (d) {
            abrirModalCargaMedicion(d.IdIndicador, d.Mes, d.IdMedicion, d.NombreMes, d.GrupoIndicador, d.TieneAccesoLecturaEscritura, d.EsAutomatico, d.NombreIndicador);
        });
    
    heatMapGrafico.transition().style("fill", function (d) { return d.ColorMeta; });    
});

function contarIndicadoresPorArea(heatMap) {

    var filas = heatMap.FilasHeatMapViewModel;

    jQuery.each(filas, function (key, value) {
        if (dictionaryIndicadoresPorArea[value.NombreArea] != undefined) {
            dictionaryIndicadoresPorArea[value.NombreArea] += 1;
        }
        else {
            dictionaryIndicadoresPorArea[value.NombreArea] = 1;
        }
    });

    var arr = [];
    jQuery.each(dictionaryIndicadoresPorArea, function (key, value) {
        var arr1 = [];
        arr1.push(key);
        arr1.push(value);
        arr.push(arr1);
    });

    return arr;
}

function wrap(text, centrarHorizontal, centrarVertical) {

    var cantFilasInicio = 0;

    text.each(function () {

        cantFilasInicio += dictionaryIndicadoresPorArea[d3.select(this).text()];

        if (dictionaryIndicadoresPorArea[d3.select(this).text()] <= 2) {
            wrapHorizontalPalabra(d3.select(this), 90, -24, centrarHorizontal, centrarVertical, dictionaryIndicadoresPorArea[d3.select(this).text()]);
        }
        else {
            wrapVerticalPalabra(d3.select(this), 32 * dictionaryIndicadoresPorArea[d3.select(this).text()], -32 * cantFilasInicio);
        }
    });
}

function wrapVertical(text, width, posicionX) {
    text.each(function () {
        wrapVerticalPalabra(d3.select(this), width, posicionX);
    });
}

function wrapVerticalPalabra(text, width, posicionX) {

    var words = text.text().split(/\s+/).reverse(),
        word,
        line = [],
        tspans = [],
        tspan = text.text(null)
                    .append("tspan")
                    .style("text-anchor", "start")
                    .attr("y", 0)
                    .attr("x", 0)
                    .attr("dx", posicionX + "px")

    while (word = words.pop()) {
        line.push(word);
        tspan.text(line.join(" "));

        if (tspan.node().getComputedTextLength() > width) {
            line.pop();
            tspan.text(line.join(" "));
            line = [word];

            tspan.attr("dx", posicionX + ((width - tspan.node().getComputedTextLength()) / 2) + "px");
            tspans.push(tspan);

            tspan = text.append("tspan")
                        .attr("y", 0)
                        .attr("x", 0)
                        .style("text-anchor", "start")
                        .attr("dx", posicionX + "px")
                        .text(word);
        }
    }

    tspan.attr("dx", posicionX + ((width - tspan.node().getComputedTextLength()) / 2) + "px");
    tspans.push(tspan);

    centrarVertical(tspans);
}

function centrarVertical(tspans) {

    var dy = 1.3,
        i = 0;

    var dif = 0;
    if (tspans.length % 2 == 0)
        dif = dy / 2;

    var medio = Math.trunc(tspans.length / 2);

    while (i < tspans.length) {
        var tspan = tspans[i];
        tspan.attr("dy", dy + dif + (-dy * (medio - i)) + "em");
        i++;
    }
}

function wrapHorizontal(text, width, posicionX, centrarHorizontal, centrarVertical) {
    text.each(function () {
        wrapHorizontalPalabra(d3.select(this), width, posicionX, centrarHorizontal, centrarVertical);
    });
}

function wrapHorizontalPalabra(text, width, posicionX, centrarHorizontal, centrarVertical, cantFilas) {

    var words = text.text().split(/\s+/).reverse(),
        word,
        line = [],
        tspans = [],
        lineNumber = 0,
        lineHeight = 1.1,
        x = text.attr("x"),
        y = text.attr("y"),
        dy = 0;

    var tspan = text.text(null)
                    .append("tspan")
                    .attr("x", posicionX)
                    .style("text-anchor", "start")
                    .attr("y", y)
                    .attr("dy", dy + "em");

    while (word = words.pop()) {
        line.push(word);
        tspan.text(line.join(" "));

        if (tspan.node().getComputedTextLength() > width) {

            if (lineNumber == 1) {
                agregarTresPuntos(tspan, width, line);
                break;
            }
            else {
                line.pop();
                tspan.text(line.join(" "));
                line = [word];
            }

            if (centrarHorizontal)
                tspan.attr("dx", -5 + ((width - tspan.node().getComputedTextLength()) / 2) + "px");

            tspans.push(tspan);

            tspan = text.append("tspan")
                        .attr("x", posicionX)
                        .attr("y", y)
                        .style("text-anchor", "start")
                        .attr("dy", ++lineNumber * lineHeight + dy + "em")
                        .text(word);
        }
    }

    tspans.push(tspan);

    if (centrarHorizontal)
        tspan.attr("dx", -5 + ((width - tspan.node().getComputedTextLength()) / 2) + "px");

    if (centrarVertical)
        centrarVerticalTextoNoRotado(tspans, cantFilas);
}

function centrarVerticalTextoNoRotado(tspans, cantFilas) {

    if (cantFilas == 1 && tspans.length == 2)
        return;

    if (cantFilas == 1 && tspans.length == 1) {
        tspans[0].attr("dy", 0.55 + "em");
        return;
    }

    if (cantFilas == 2 && tspans.length == 1) {
        tspans[0].attr("dy", 1.75 + "em");
        return;
    }

    var i = 0,
        dy = 1.3;

    if (cantFilas == 2 && tspans.length == 2) {
        while (i < tspans.length) {
            var tspan = tspans[i];
            tspan.attr("dy", 1.1 * i + dy + "em");
            i++;
        }
    }
}

function agregarTresPuntos(tspan, width, line) {

    var palabra = line.pop();
    tspan.text(line.join(" ") + "...");

    var cantLetras = palabra.length;

    while ((tspan.node().getComputedTextLength() < width) && cantLetras > 0) {
        tspan.text(line.join(" ") + " " + palabra.substring(0, palabra.length - cantLetras + 1) + "...");
        cantLetras--;
    }
}

function abrirGrafico(indicador) {
    jQuery('.detalleGrafico').show();
}
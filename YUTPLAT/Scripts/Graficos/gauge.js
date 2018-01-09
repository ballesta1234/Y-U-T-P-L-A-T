var gauge = function (container, configuration) {
    var that = {};
    var config = {
        size: 200,
        clipWidth: 200,
        clipHeight: 110,
        ringInset: 20,
        ringWidth: 20,
        pointerWidth: 10,
        pointerTailLength: 5,
        pointerHeadLengthPercent: 0.9,
        minValue: 0,
        maxValue: 10,
        transitionMs: 750,
        majorTicks: 5,
        labelFormat: d3.format(',g'),
        labelInset: 10,
        ticks: [0, 0.2, 0.4, 0.5, 0.7, 1],
        colors: ['#DF0101', '#F79F81', '#F7FE2E', '#81F781', '#0B610B']
    };

    var r = undefined;
    var pointerHeadLength = undefined;
    var svg = undefined;
    var arc = undefined;
    var scale = undefined;
    var pointer = undefined;

    var donut = d3.layout.pie();

    function deg2rad(deg) {
        return deg * Math.PI / 180;
    }

    function configure(configuration) {
        var prop = undefined;
        for (prop in configuration) {
            config[prop] = configuration[prop];
        }

        r = config.size / 2;
        pointerHeadLength = Math.round(r * config.pointerHeadLengthPercent);

        scale = d3.scale.linear()
            .range([0, 1])
            .domain([config.minValue, config.maxValue]);

        arc = d3.svg.arc()
            .innerRadius(r - config.ringWidth - config.ringInset)
            .outerRadius(r - config.ringInset)
            .startAngle(function (d, i) {
                return deg2rad(-90 + (180 * config.ticks[i]));
            })
            .endAngle(function (d, i) {
                return deg2rad(-90 + (180 * config.ticks[i + 1]));
            });
    }
    that.configure = configure;

    function centerTranslation() {
        return 'translate(' + r + ',' + r + ')';
    }

    function isRendered() {
        return (svg !== undefined);
    }

    that.isRendered = isRendered;

    function render(newValue) {

        d3.select(".gauge").remove();

        svg = d3.select(container)
            .append('svg:svg')
                .attr('class', 'gauge')
                .attr('width', config.clipWidth)
                .attr('height', config.clipHeight);

        var centerTx = centerTranslation();

        var arcs = svg.append('g')
                .attr('class', 'arc')
                .attr('transform', centerTx);

        arcs.selectAll('path')
                .data(config.ticks)
            .enter().append('path')
                .attr('fill', function (d, i) {
                    return config.colors[i];
                })
                .attr('d', arc);

        var lg = svg.append('g')
                .attr('class', 'label')
                .attr('transform', centerTx);
        lg.selectAll('text')
                .data(config.ticks)
            .enter().append('text')
                .attr('transform', function (d) {
                    var ratio = scale(d);
                    var newAngle = -90 + (ratio * 180);
                    return 'rotate(' + newAngle + ') translate(0,' + (config.labelInset - r) + ')';
                })
                .text(config.labelFormat);

        var lineData = [[config.pointerWidth / 2, 0],
                        [0, -pointerHeadLength],
                        [-(config.pointerWidth / 2), 0],
                        [0, config.pointerTailLength],
                        [config.pointerWidth / 2, 0]];

        var pointerLine = d3.svg.line().interpolate('monotone');

        var pg = svg.append('g').data([lineData])
                .attr('class', 'pointer')
                .attr('transform', centerTx);

        pointer = pg.append('path')
            .attr('d', pointerLine)
            .attr('transform', 'rotate(' + -90 + ')');

        update(newValue === undefined ? 0 : newValue);
    }
    that.render = render;

    function update(newValue, newConfiguration) {
        if (newConfiguration !== undefined) {
            configure(newConfiguration);
        }
        var ratio = scale(newValue);
        var newAngle = -90 + (ratio * 180);
        pointer.transition()
            .duration(config.transitionMs)
            .ease('elastic')
            .attr('transform', 'rotate(' + newAngle + ')');
    }
    that.update = update;
    configure(configuration);
    return that;
};

function onDocumentReadyGauge(valor) {
    var powerGauge = gauge('#power-gauge', {
        size: 300,
        clipWidth: 300,
        clipHeight: 200,
        ringWidth: 60,
        maxValue: 1,
        transitionMs: 4000,
        ticks: [0, 0.1, 0.3, 0.6, 0.75, 1],
        colors: ['#DF0101', '#F79F81', '#F7FE2E', '#81F781', '#0B610B']
    });
    powerGauge.render();
    powerGauge.update(valor);
}
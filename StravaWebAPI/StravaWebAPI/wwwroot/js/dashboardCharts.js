window.stravaCharts = window.stravaCharts || {};

window.stravaCharts._runChart = null;
window.stravaCharts._rideChart = null;

const peakLabelPlugin = {
    id: "peakLabelPlugin",
    afterDatasetsDraw(chart) {
        const { ctx } = chart;
        ctx.save();
        ctx.font = "12px Inter, Arial, sans-serif";
        ctx.textAlign = "center";
        ctx.textBaseline = "bottom";

        chart.data.datasets.forEach((dataset, datasetIndex) => {
            if (!Array.isArray(dataset.data) || dataset.data.length === 0) {
                return;
            }

            let maxValue = Number.NEGATIVE_INFINITY;
            let maxIndex = -1;

            dataset.data.forEach((value, index) => {
                const numericValue = Number(value);
                if (!Number.isNaN(numericValue) && numericValue > maxValue) {
                    maxValue = numericValue;
                    maxIndex = index;
                }
            });

            if (maxIndex < 0) {
                return;
            }

            const point = chart.getDatasetMeta(datasetIndex)?.data?.[maxIndex];
            if (!point) {
                return;
            }

            const position = point.tooltipPosition();
            ctx.fillStyle = dataset.borderColor || "#111827";
            ctx.fillText(`${maxValue.toFixed(2)} mi`, position.x, position.y - 10);
        });

        ctx.restore();
    }
};

function createLineGradient(context, topColor, bottomColor) {
    const chart = context.chart;
    const { ctx, chartArea } = chart;
    if (!chartArea) {
        return bottomColor;
    }

    const gradient = ctx.createLinearGradient(0, chartArea.top, 0, chartArea.bottom);
    gradient.addColorStop(0, topColor);
    gradient.addColorStop(1, bottomColor);
    return gradient;
}

function createLineOptions() {
    return {
        responsive: true,
        interaction: {
            mode: "nearest",
            intersect: false
        },
        animation: {
            duration: 900,
            easing: "easeOutQuart"
        },
        plugins: {
            legend: { position: "top" },
            tooltip: {
                callbacks: {
                    label(context) {
                        const value = Number(context.raw ?? 0).toFixed(2);
                        return `${context.dataset.label}: ${value} mi`;
                    }
                }
            }
        },
        elements: {
            line: {
                borderWidth: 3,
                tension: 0.35
            },
            point: {
                radius: 3,
                hoverRadius: 7,
                hoverBorderWidth: 2
            }
        },
        scales: {
            y: {
                beginAtZero: true,
                title: { display: true, text: "Miles" }
            }
        }
    };
}

window.stravaCharts.renderMonthlyMileageCharts = function (data) {
    if (!window.Chart) {
        return;
    }

    const labels = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    const runCanvas = document.getElementById("runMileageChart");
    const rideCanvas = document.getElementById("rideMileageChart");
    if (!runCanvas || !rideCanvas) {
        return;
    }

    if (window.stravaCharts._runChart) {
        window.stravaCharts._runChart.destroy();
    }

    if (window.stravaCharts._rideChart) {
        window.stravaCharts._rideChart.destroy();
    }

    window.stravaCharts._runChart = new Chart(runCanvas, {
        type: "line",
        plugins: [peakLabelPlugin],
        data: {
            labels,
            datasets: [
                {
                    label: `${data.lastYear} Run`,
                    data: data.runLastYearMiles,
                    borderColor: "#9ca3af",
                    backgroundColor: (context) => createLineGradient(context, "rgba(156, 163, 175, 0.35)", "rgba(156, 163, 175, 0.02)"),
                    fill: true
                },
                {
                    label: `${data.currentYear} Run`,
                    data: data.runCurrentYearMiles,
                    borderColor: "#2563eb",
                    backgroundColor: (context) => createLineGradient(context, "rgba(37, 99, 235, 0.45)", "rgba(37, 99, 235, 0.04)"),
                    fill: true
                }
            ]
        },
        options: createLineOptions()
    });

    window.stravaCharts._rideChart = new Chart(rideCanvas, {
        type: "line",
        plugins: [peakLabelPlugin],
        data: {
            labels,
            datasets: [
                {
                    label: `${data.lastYear} Cycling`,
                    data: data.rideLastYearMiles,
                    borderColor: "#9ca3af",
                    backgroundColor: (context) => createLineGradient(context, "rgba(156, 163, 175, 0.35)", "rgba(156, 163, 175, 0.02)"),
                    fill: true
                },
                {
                    label: `${data.currentYear} Cycling`,
                    data: data.rideCurrentYearMiles,
                    borderColor: "#16a34a",
                    backgroundColor: (context) => createLineGradient(context, "rgba(22, 163, 74, 0.45)", "rgba(22, 163, 74, 0.04)"),
                    fill: true
                }
            ]
        },
        options: createLineOptions()
    });
};

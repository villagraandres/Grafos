// site.js - construye grafo si existe #graph-container en la página
(function () {
    const container = document.getElementById('graph-container');
    if (!container) return; // no ejecutar en páginas que no tengan el contenedor

    // Asegurar que vis esté disponible
    function loadGraph(data) {
        if (typeof vis === 'undefined') {
            console.error('vis-network no está cargado. Asegúrate de incluirlo antes de site.js en la página de grafo.');
            container.innerHTML = '<p class="text-danger">La librería de grafo no está disponible.</p>';
            return;
        }

        const nodes = new vis.DataSet(data.nodes);
        const edges = new vis.DataSet(data.edges);
        const network = new vis.Network(container, { nodes, edges }, {
            nodes: { shape: 'dot', size: 16 },
            edges: { smooth: true, font: { align: 'top' } },
            physics: { stabilization: { iterations: 200 } }
        });

        network.on('click', params => {
            if (params.nodes && params.nodes.length) {
                console.log('Nodo clicado:', params.nodes[0]);
            }
        });
    }

    // Fetch al handler que devuelve nodos y edges
    fetch('/Carreteras?handler=Graph')
        .then(res => {
            if (!res.ok) throw new Error('Network response was not ok');
            return res.json();
        })
        .then(data => loadGraph(data))
        .catch(err => {
            console.error('Error cargando datos del grafo:', err);
            container.innerHTML = '<p class="text-danger">No se pudieron cargar los datos del grafo.</p>';
        });
})();
const uri = 'api/clientes';


const tabla = document.querySelector('#lista-clientes tbody');

function getClientes() {
    
    fetch(uri)
        .then(respuesta => respuesta.json())
        .then(clientes => console.log(clientes))
}


function getClientes1()
{
    let nombreCliente = document.getElementById('cliente');
    console.log(nombreCliente);
    fetch(uri)
        .then(respuesta => respuesta.json())
        .then(clientes => {
            clientes.forEach(clientes => {
                if (${clientes.nombre} == nombreCliente) {
                    const row = document.createElement('tr');
                    row.innerHTML += `
                    <td>${clientes.dni}<td>
                    `;
                    tabla.appendChild(row);
                }
            })

        });

}



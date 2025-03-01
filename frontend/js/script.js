let list = document.querySelectorAll("nav li");

const activeLink = (event) => {
    list.forEach(item => {
        item.classList.remove("hovered");
    });
    event.currentTarget.classList.add("hovered");
};

list.forEach((item) => item.addEventListener("mouseover", activeLink));


let toggle = document.getElementById("toggle");
let nav = document.querySelector("nav");
let main = document.querySelector("main");

const funcToggle = () => {
    nav.classList.toggle("active");
    main.classList.toggle("active");
};

toggle.addEventListener("click", funcToggle);

let colaboradores = []; 
let currentIndex = 0; 

async function carregarDados() {
    try {
        const colaboradoresResponse = await fetch("https://localhost:7144/api/Colaboradores");
        const empresasResponse = await fetch("https://localhost:7144/api/Empresas");

        if (!colaboradoresResponse.ok || !empresasResponse.ok) {
            throw new Error("Erro ao buscar dados");
        }

        const colaboradores = await colaboradoresResponse.json();
        const empresas = await empresasResponse.json();

        document.getElementById("colaboradoresAtivos").innerText = colaboradores.length; 
        document.getElementById("empresasCadastradas").innerText = empresas.length; 
    } catch (error) {
        console.error("Erro ao carregar dados:", error);
    }
}

carregarDados();

async function carregarColaboradores() {
    try {
        const response = await fetch("https://localhost:7144/api/Colaboradores");
        if (!response.ok) {
            throw new Error("Erro ao buscar colaboradores");
        }

        colaboradores = await response.json(); 
        exibirColaboradores(currentIndex); 
    } catch (error) {
        console.error("Erro ao carregar colaboradores:", error);
    }
}

function exibirColaboradores(startIndex) {
    const tbody = document.querySelector("tbody");
    tbody.innerHTML = ""; 

    const endIndex = Math.min(startIndex + 10, colaboradores.length);
    for (let i = startIndex; i < endIndex; i++) {
        const colaborador = colaboradores[i];
        const tr = document.createElement("tr");

        tr.innerHTML = `
            <td>${colaborador.colaboradorId}</td>
            <td>${colaborador.nome}</td>
            <td>${colaborador.cpf}</td>
            <td>${colaborador.matricula}</td>
            <td>${colaborador.empresaNome}</td>
        `;

        tbody.appendChild(tr);
    }

    if (endIndex < colaboradores.length) {
        mostrarBotaoViewAll();
    } else {
        esconderBotaoViewAll();
    }

    if (startIndex > 0) {
        mostrarBotaoVoltar();
    } else {
        esconderBotaoVoltar();
    }
}


function mostrarBotaoViewAll() {
    const botaoViewAll = document.getElementById("viewAll");
    botaoViewAll.style.display = "block"; 
    botaoViewAll.addEventListener("click", carregarMaisColaboradores);
}


function esconderBotaoViewAll() {
    const botaoViewAll = document.getElementById("viewAll");
    botaoViewAll.style.display = "none"; 
}

function mostrarBotaoVoltar() {
    const botaoVoltar = document.getElementById("voltar");
    botaoVoltar.style.display = "block"; 
    botaoVoltar.addEventListener("click", voltarColaboradores);
}


function esconderBotaoVoltar() {
    const botaoVoltar = document.getElementById("voltar");
    botaoVoltar.style.display = "none"; 
}

function carregarMaisColaboradores(event) {
    event.preventDefault();
    currentIndex += 10; 
    exibirColaboradores(currentIndex);
}

function voltarColaboradores(event) {
    event.preventDefault();
    currentIndex -= 10; 
    if (currentIndex < 0) currentIndex = 0; 
    exibirColaboradores(currentIndex); 
}

carregarColaboradores();

let empresas = [];
let startIndex = 0; 
const pageSize = 5; 

async function carregarEmpresas() {
    try {
        const response = await fetch("https://localhost:7144/api/Empresas");
        if (!response.ok) {
            throw new Error("Erro ao buscar empresas");
        }

        empresas = await response.json();
        exibirEmpresas();
    } catch (error) {
        console.error("Erro ao carregar empresas:", error);
    }
}

function exibirEmpresas() {
    const container = document.getElementById("empresas-container");
    container.innerHTML = "";

    const empresasParaExibir = empresas.slice(startIndex, startIndex + pageSize);

    empresasParaExibir.forEach(empresa => {
        const table = document.createElement("table");
        table.innerHTML = `
            <tr>
                <td width="60px">
                    <div class="imgBx">
                        <img src="frontend/imgs/logoempresa.jpg" alt="Imagem Genérica">
                    </div>
                </td>
                <td>
                    <h4>${empresa.nome}</h4>
                </td>
            </tr>
        `;
        container.appendChild(table);
    });


    const btnVoltar = document.getElementById("previous");
    const btnViewAll = document.getElementById("next");

    if (startIndex > 0) {
        btnVoltar.style.display = "inline";
    } else {
        btnVoltar.style.display = "none"; 
    }

    if (startIndex + pageSize < empresas.length) {
        btnViewAll.style.display = "inline";
    } else {
        btnViewAll.style.display = "none"; 
    }
}

function mostrarProximo(event) {
    event.preventDefault();  
    if (startIndex + pageSize < empresas.length) {
        startIndex += pageSize;
        exibirEmpresas();
    }
}

function voltar(event) {
    event.preventDefault();  
    if (startIndex > 0) {
        startIndex -= pageSize;
        exibirEmpresas();
    }
}

document.getElementById("next").addEventListener("click", mostrarProximo);
document.getElementById("previous").addEventListener("click", voltar);


document.getElementById("next").addEventListener("click", mostrarProximo);
document.getElementById("previous").addEventListener("click", voltar);

carregarEmpresas();

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

// URL base da API
const API_BASE_URL = 'https://localhost:7144';

// Adiciona eventos aos formulários
document.addEventListener('DOMContentLoaded', function () {
    const formEmpresa = document.getElementById('form-empresa');
    const formColaborador = document.getElementById('form-colaborador');

    if (formEmpresa) {
        formEmpresa.addEventListener('submit', function (event) {
            event.preventDefault(); 
            cadastrarEmpresa();
        });
    }

    if (formColaborador) {
        formColaborador.addEventListener('submit', function (event) {
            event.preventDefault(); 
            cadastrarColaborador();
        });
    }
});

// Função para exibir o modal de sucesso
function showSuccessModal(message) {
    const modalSuccess = document.getElementById('modal-success');
    const modalSuccessMessage = document.getElementById('modal-success-message');

    modalSuccessMessage.textContent = message; // Define a mensagem
    modalSuccess.style.display = 'flex'; // Exibe o modal

    // Fecha o modal ao clicar no botão de fechar
    modalSuccess.querySelector('.close-modal').onclick = () => {
        modalSuccess.style.display = 'none';
    };

    // Fecha o modal ao clicar fora dele
    window.onclick = (event) => {
        if (event.target === modalSuccess) {
            modalSuccess.style.display = 'none';
        }
    };
}

// Função para exibir o modal de erro
function showErrorModal(message) {
    const modalError = document.getElementById('modal-error');
    const modalErrorMessage = document.getElementById('modal-error-message');

    modalErrorMessage.textContent = message; // Define a mensagem
    modalError.style.display = 'flex'; // Exibe o modal

    // Fecha o modal ao clicar no botão de fechar
    modalError.querySelector('.close-modal').onclick = () => {
        modalError.style.display = 'none';
    };

    // Fecha o modal ao clicar fora dele
    window.onclick = (event) => {
        if (event.target === modalError) {
            modalError.style.display = 'none';
        }
    };
}

// Função para cadastrar uma empresa
async function cadastrarEmpresa() {
    const nomeEmpresa = document.getElementById('nome-empresa').value;

    if (!nomeEmpresa) {
        showErrorModal('Por favor, preencha o nome da empresa.');
        return;
    }

    const dados = { nome: nomeEmpresa };

    try {
        const response = await fetch(`${API_BASE_URL}/api/Empresas/inserir`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dados)
        });

        let resultado = await response.json().catch(() => ({})); // Garante que não haverá erro se a resposta não for JSON

        if (!response.ok) {
            showErrorModal(`Erro ao cadastrar empresa: ${resultado.message || 'Erro desconhecido'}`);
            return;
        }

        showSuccessModal('Empresa cadastrada com sucesso!');
        document.getElementById('form-empresa').reset();
    } catch (error) {
        console.error('Erro:', error);
        showErrorModal('Erro ao conectar com a API.');
    }
}

// Função para cadastrar um colaborador
async function cadastrarColaborador() {
    const nomeColaborador = document.getElementById('nome-colaborador').value;
    const cpfColaborador = document.getElementById('cpf-colaborador').value;
    const matriculaColaborador = document.getElementById('matricula-colaborador').value;
    const empresaId = document.getElementById('empresa-id').value;

    if (!nomeColaborador || !cpfColaborador || !matriculaColaborador || !empresaId) {
        showErrorModal('Por favor, preencha todos os campos.');
        return;
    }

    if (cpfColaborador.length !== 11) {
        showErrorModal('CPF deve conter exatamente 11 dígitos.');
        return;
    }

    const dados = {
        nome: nomeColaborador,
        cpf: cpfColaborador,
        matricula: parseInt(matriculaColaborador),
        empresaId: parseInt(empresaId)
    };

    try {
        const response = await fetch(`${API_BASE_URL}/api/Colaboradores/inserir-colaborador`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dados)
        });

        let resultado = await response.json().catch(() => ({}));

        if (!response.ok) {
            showErrorModal(`Erro ao cadastrar colaborador: ${resultado.message || 'Erro desconhecido'}`);
            return;
        }

        showSuccessModal('Colaborador cadastrado com sucesso!');
        document.getElementById('form-colaborador').reset();
    } catch (error) {
        console.error('Erro:', error);
        showErrorModal('Erro ao conectar com a API.');
    }
}

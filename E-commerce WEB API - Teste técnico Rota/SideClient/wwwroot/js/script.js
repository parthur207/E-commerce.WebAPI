// Função para mostrar/ocultar a senha
const visualizarSenhaBtn = document.getElementById("visualizar-senha");
const senhaInput = document.getElementById("senha");

visualizarSenhaBtn.addEventListener("click", function () {
    if (senhaInput.type === "password") {
        senhaInput.type = "text"; // Torna a senha visível
    } else {
        senhaInput.type = "password"; // Torna a senha invisível novamente
    }
});

// Função para simular o login
const loginForm = document.getElementById("login-form");

loginForm.addEventListener("submit", function (event) {
    event.preventDefault(); // Evita o envio do formulário para simular o login

    const email = document.getElementById("email").value;
    const senha = document.getElementById("senha").value;

    if (email && senha) {
        alert(`Login efetuado com sucesso!\nEmail: ${email}\nSenha: ${senha}`);
    } else {
        alert("Por favor, preencha todos os campos.");
    }
});

// Link para cadastro (simulação)
const cadastroLink = document.getElementById("cadastro-link");

cadastroLink.addEventListener("click", function (event) {
    event.preventDefault();
    alert("Redirecionando para página de cadastro...");
});

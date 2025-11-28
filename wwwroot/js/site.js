function responderBot(msg) {
    msg = msg.toLowerCase();

    if (msg.includes("preço") || msg.includes("valor"))
        return "Para comparar preços basta usar a barra de pesquisa centralizada no meio da tela!";

    if (msg.includes("como usar"))
        return "Basta digitar o nome do produto e eu encontro os melhores preços para você.";

    if (msg.includes("oi") || msg.includes("olá"))
        return "Olá! Como posso ajudar hoje?";

    if (msg.includes("preço") || msg.includes("valor") || msg.includes("caro") || msg.includes("barato"))
        return "Para comparar preços, use a barra de pesquisa no centro de pagina e eu encontro os melhores valores automaticamente!";

    if (msg.includes("como usar") || msg.includes("ajuda") || msg.includes("tutorial") || msg.includes("funciona"))
        return "É simples! Digite o nome do produto na barra de pesquisa centralizada e eu retorno as melhores ofertas disponíveis em lojas online.";

    if (msg.includes("bug") || msg.includes("erro") || msg.includes("problema") || msg.includes("travando"))
        return "Sinto muito por isso! Clique em F5 e tente recarregar a página. Se continuar acontecendo, posso te orientar melhor.";

    if (msg.includes("peça") || msg.includes("produto") || msg.includes("buscar") || msg.includes("procuro") || msg.includes("estou atrás"))
        return "Digite o nome da peça na barra de pesquisa que eu encontro os melhores preços disponíveis!";

    if (msg.includes("quem é você") || msg.includes("quem é voce") || msg.includes("o que você faz") || msg.includes("qual sua função"))
        return "Eu sou o Botty, seu assistente do PriceAI! Estou aqui para ajudar você a encontrar os melhores preços e navegar no site, me pergunte qualquer coisa e eu responderei.";

    if (msg.includes("comparar") || msg.includes("comparação"))
        return "Para comparar preços, basta pesquisar o nome da peça. O sistema já organiza os valores automaticamente.";

    if (msg.includes("pagar") || msg.includes("pagamento") || msg.includes("parcelar"))
        return "As formas de pagamento dependem da loja onde você encontra o produto. Eu sou apenas o seu comparador de preços favoritos";

    if (msg.includes("login") || msg.includes("conta") || msg.includes("cadastro"))
        return "No momento, o PriceAI ainda não exige cadastro para comparar preços. Tudo é livre para uso!";

    if (msg.includes("obrigado") || msg.includes("valeu") || msg.includes("agradeço"))
        return "De nada! :) Sempre que precisar é só me chamar, estou por aqui.";

    return "Desculpe, não entendi. Poderia tentar reformular a pergunta?";
}

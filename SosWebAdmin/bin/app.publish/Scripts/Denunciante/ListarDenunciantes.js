/*
 * Carregamento Inicial Dinâmico
 * Lista de Denunciantes
 */

var listDenunciantes = denunciantes;
var gridDenunciantes = document.getElementById("CarregarDenunciantes");

for (let i = 0; i < listDenunciantes.Denunciante.length; i++) {

    var row = document.createElement("tr");
    var id = document.createElement("td");
    var email = document.createElement("td");
    var nome = document.createElement("td");
    var areaSelecione = document.createElement("td");
    var btnSelecione = document.createElement("button");

    btnSelecione.className = "btn btn-outline-success btn-sm";
    btnSelecione.setAttribute("name", "lnkCodigoDenunciante");
    btnSelecione.setAttribute("id", "lnkCodigoDenunciante-" + listDenunciantes.Denunciante[i].IdDenunciante);
    btnSelecione.setAttribute("onclick", "SelecionarDenuncianteLinkModal(" + listDenunciantes.Denunciante[i].IdDenunciante + ")");
    btnSelecione.setAttribute("value", listDenunciantes.Denunciante[i].IdDenunciante);
    btnSelecione.innerText = "Selecione";

    var conteudoId = document.createTextNode(listDenunciantes.Denunciante[i].IdDenunciante);
    var conteudoEmail = document.createTextNode(listDenunciantes.Denunciante[i].Email);
    var conteudoNome = document.createTextNode(listDenunciantes.Denunciante[i].Nome);

    id.appendChild(conteudoId);
    email.appendChild(conteudoEmail);
    nome.appendChild(conteudoNome);

    row.appendChild(id);
    row.appendChild(email);
    row.appendChild(nome);
    row.appendChild(areaSelecione);
    areaSelecione.appendChild(btnSelecione);
    gridDenunciantes.appendChild(row);
}
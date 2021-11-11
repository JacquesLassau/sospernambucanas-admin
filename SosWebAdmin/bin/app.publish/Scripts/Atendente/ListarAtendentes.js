/*
 * Carregamento Inicial Dinâmico
 * Lista de Atendentes
 */

var listAtendentes = atendentes;
var gridAtendentes = document.getElementById("CarregarAtendentes");

for (let i = 0; i < listAtendentes.Atendente.length; i++) {

    var row = document.createElement("tr");
    var id = document.createElement("td");
    var matricula = document.createElement("td");
    var nome = document.createElement("td");
    var areaSelecione = document.createElement("td");
    var btnSelecione = document.createElement("button");

    btnSelecione.className = "btn btn-outline-success btn-sm";
    btnSelecione.setAttribute("name", "lnkCodigoAtendente");
    btnSelecione.setAttribute("id", "lnkCodigoAtendente-" + listAtendentes.Atendente[i].IdAtendente);
    btnSelecione.setAttribute("onclick", "SelecionarAtendenteLinkModal(" + listAtendentes.Atendente[i].IdAtendente + ")");
    btnSelecione.setAttribute("value", listAtendentes.Atendente[i].IdAtendente);
    btnSelecione.innerText = "Selecione";

    var conteudoId = document.createTextNode(listAtendentes.Atendente[i].IdAtendente);
    var conteudoMatricula = document.createTextNode(listAtendentes.Atendente[i].Matricula);
    var conteudoNome = document.createTextNode(listAtendentes.Atendente[i].Nome);

    id.appendChild(conteudoId);
    matricula.appendChild(conteudoMatricula);
    nome.appendChild(conteudoNome);

    row.appendChild(id);
    row.appendChild(matricula);
    row.appendChild(nome);
    row.appendChild(areaSelecione);
    areaSelecione.appendChild(btnSelecione);
    gridAtendentes.appendChild(row);
}
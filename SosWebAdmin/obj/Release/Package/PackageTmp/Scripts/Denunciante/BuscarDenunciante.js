function CriaEscutaPostMessageParaIFrameDenunciante() {

    var eventMethod = window.addEventListener ? "addEventListener" : "attachEvent";
    var eventer = window[eventMethod];
    var messageEvent = eventMethod == "attachEvent" ? "onmessage" : "message";

    eventer(messageEvent, function (e) {
        $("#Denunciantes").modal("hide");
        $("#IdDenunciante").val(e.data.IdDenunciante);
        FnTxtPesquisarDenunciante();
    }, false);

}

function FnTxtPesquisarDenunciante() {

    event.preventDefault();
    var item = $("#IdDenunciante").val();

    if (item == "")
        item = 0;

    $.get("/Denunciante/SelecionarDenunciante?codigoDenunciante=" + item, function (data) {
        if (data.IdDenunciante != null) {
            $(function () {
                $("#Denunciantes").modal("hide");
                $("#Nome").val(data.Nome);                
            });
        }
    });

}

function FnBtnPesquisarDenunciante() {  
    
    $("#Nome").val("");
    $("#IdDenunciante").val("");

}

function SelecionarDenuncianteLinkModal(idDenunciante) {

    event.preventDefault();    

    $.get("/Denunciante/SelecionarDenunciante?codigoDenunciante=" + idDenunciante, function (response) {
        parent.postMessage(response);
    });

}
function CriaEscutaPostMessageParaIFrameAtendente() {

    var eventMethod = window.addEventListener ? "addEventListener" : "attachEvent";
    var eventer = window[eventMethod];
    var messageEvent = eventMethod == "attachEvent" ? "onmessage" : "message";

    eventer(messageEvent, function (e) {
        $("#Atendentes").modal("hide");
        $("#IdAtendente").val(e.data.IdAtendente);
        FnTxtPesquisarAtendente();
    }, false);

}

function FnTxtPesquisarAtendente() {

    event.preventDefault();
    var item = $("#IdAtendente").val();

    if (item == "")
        item = 0;

    $.get("/Atendente/SelecionarAtendente?codigoAtendente=" + item, function (data) {
        if (data.IdAtendente != null) {
            $(function () {
                $("#Atendentes").modal("hide");
                $("#Nome").val(data.Nome);                
            });
        }
    });

}

function FnBtnPesquisarAtendente() {  
    
    $("#Nome").val("");
    $("#IdAtendente").val("");

}

function SelecionarAtendenteLinkModal(idAtendente) {

    event.preventDefault();    

    $.get("/Atendente/SelecionarAtendente?codigoAtendente=" + idAtendente, function (response) {
        parent.postMessage(response);
    });

}
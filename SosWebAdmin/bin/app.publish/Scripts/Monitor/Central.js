function LigarDenunciante() {

    event.preventDefault();

    var id = $("#id-ocorrencia").val();
    var tel = $("#telefone-denunciante").val();
    var telefone = tel.replace("(", "").replace(")", "").replace("-", "");

    $.post("/Monitor/LigarDenunciante?idOcorrencia=" + id, function (result) {

        if (!result)
            alert("Houve um erro inesperado do sistema! Por favor, tire uma foto da tela e contate imediatamente o suporte especializado.");
        else
            window.location.href = "tel:+55081" + telefone;

        location.reload();
    });

}

function OcorrenciaDenunciante() {

    event.preventDefault();

    var id = $("#id-descricao-ocorrencia").val();
    var descricao = $("#descricao-ocorrencia-denunciante").val();

    $.post("/Monitor/OcorrenciaDenunciante?idOcorrencia=" + id + "&descricaoOcorrencia=" + descricao, function (result) {

        if (!result)
            alert("Houve um erro inesperado do sistema. Por favor, tire uma foto da tela e contate imediatamente o suporte especializado.");
        else
            location.reload();
    });

}

function BuscarOcorrencia(id) {

    $.get("/Monitor/BuscarOcorrencia?idOcorrencia=" + id, function (data) {

        if (data == null) {
            alert("Houve um erro inesperado do sistema. Por favor, tire uma foto da tela e contate imediatamente o suporte especializado.");
            $("#modalConsultarOcorrencia").modal("hidden");
        } else {
            $("#modConsult-IdOcorrencia").text(data.IdOcorrencia);
            $("#modConsult-NomeDenunciante").text(data.NomeDenunciante);
            $("#modConsult-TelefoneDenunciante").text(data.TelefoneDenunciante);
            $("#modConsult-LigacaoDenunciante").text(data.NumeroRegistroLigacao);
            $("#modConsult-DescricaoLigacao").text(data.DescricaoRegistroLigacao);
            $("#modConsult-DescricaoOcorrenciaDenunciante").text(data.DescricaoOcorrencia);            
        }
    });

}
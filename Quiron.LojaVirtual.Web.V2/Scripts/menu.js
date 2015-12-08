var app = {};

$(function() {
    app.inicializar();
});


app.inicializar = function() {

    $('#main-menu').smartmenus();
    app.ObterEsportes();
    app.ObterMarcas();
    app.ObterClubesNacionais();
    app.ObterClubesInternacionais();
    app.ObterSelecoes();
}

app.ObterEsportes = function() {

    $.getJSON('/menu/obteresportes', function(data) {
        $(data).each(function () {
            $("#Esportes").append("<li><a href='#'>" + this.CategoriaDescricao + "</a></li>");
        });
    });

};

app.ObterMarcas = function () {

    $.getJSON('/menu/obtermarcas', function (data) {
        $(data).each(function () {
            $(".marcas").append("<li><a href='#'>" + this.MarcaDescricao + "</a></li>");
        });
    });

};

app.ObterClubesNacionais = function () {

    $.getJSON('/menu/obterclubesnacionais', function (data) {
        $(data).each(function () {
            $('#clubesnacionais').append("<li><a href='nav/times/" + this.ClubeCodigo + "/" + this.ClubeSeo + "'>" + this.Clube + "</a></li>");
        });
    });

};

app.ObterClubesInternacionais = function () {

    $.getJSON('/menu/obterclubesinternacionais', function (data) {
        $(data).each(function () {
            $('#clubesinternacionais').append("<li><a href='nav/times/" + this.ClubeCodigo + "/" + this.ClubeSeo + "'>" + this.Clube + "</a></li>");
        });
    });

};

app.ObterSelecoes = function () {

    $.getJSON('/menu/obterselecoes', function (data) {
        $(data).each(function () {
            $('#selecoes').append("<li><a href='nav/times/" + this.ClubeCodigo + "/" + this.ClubeSeo + "'>" + this.Clube + "</a></li>");
        });
    });

};
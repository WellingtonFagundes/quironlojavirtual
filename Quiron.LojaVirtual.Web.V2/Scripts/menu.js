var app = {};

$(function() {
    app.inicializar();
});


app.inicializar = function() {

    $('#main-menu').smartmenus();
    app.ObterEsportes();
    app.ObterMarcas();
}

app.ObterEsportes = function() {

    $.getJSON('/menu/obteresportes', function(data) {
        $(data).each(function () {
            //#Esportes - corresponde ao ID Esportes da página Menu.cshtml
            $("#Esportes").append("<li><a href='#'>" + this.CategoriaDescricao + "</a></li>");
        });
    });

};

app.ObterMarcas = function () {

    $.getJSON('/menu/obtermarcas', function (data) {
        $(data).each(function () {
            //.marcas - refere a classe no html na página menu.cshtml
            $(".marcas").append("<li><a href='#'>" + this.MarcaDescricao + "</a></li>");
        });
    });

};
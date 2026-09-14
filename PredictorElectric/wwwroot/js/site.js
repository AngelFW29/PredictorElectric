document.addEventListener("DOMContentLoaded", function () {

    const resultado = document.getElementById("resultado");

    if (resultado) {
        resultado.scrollIntoView({
            behavior: "smooth",
            block: "start"
        });
    }

});
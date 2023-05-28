

document.querySelector("#form").addEventListener("submit", Verificar);
function Verificar(event) {
    event.preventDefault();
    let res = "";
    let pnombre = document.querySelector("#pnombre").value;
    let snombre = document.querySelector("#snombre").value;
    let papellido = document.querySelector("#papellido").value;
    let mail = document.querySelector("#mail").value;
    let sapellido = document.querySelector("#sapellido").value;

    if ((pnombre.length > 2) && (papellido.length > 2) && (sapellido.length > 2) && (snombre.length > 2)) {
        if (validarEmail(mail)) {
            this.submit();
        } else {
            res = "Email inválido"
        }
    } else {
        res = "El nombre y el apellido debe ser mayor a 2 caracteres";
    }
    document.querySelector("#res").innerHTML = res;
}


function validarEmail(valor) {
    emailRegex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
    if (emailRegex.test(valor)) {
        return true;
    } else {
        return false;
    }
}
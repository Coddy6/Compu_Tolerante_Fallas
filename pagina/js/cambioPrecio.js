function cambiarPrecio(quant, amount){
    let par = document.getElementById("pText");
    let total = quant * amount;
    par.innerHTML = "$" + total;
}
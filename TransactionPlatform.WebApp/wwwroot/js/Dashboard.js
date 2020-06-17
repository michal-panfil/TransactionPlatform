let currentInstrumentId;
let Currentitem;
function OpenBuyInstrumentForm() {
    let popup = $('.popup-box');
    popup.toggle();
}
function CancelBuyInstrumentForm() {
    let popup = $('.popup-box');
    popup.toggle();
    GetInstrumentPrices();

}
function SentTransactionRequest() {
    let popup = $('.popup-box');
    popup.toggle();
    $('.container').append('<div class="popup-box request-succes"><h3>Request has been sent</h3></div>');
    setTimeout(function () { $('.request-succes').remove(); }, 2000); 
    
}

function GetInstrumentPrices() {
    $.ajax({
        url: "TransactionService/GetAllInstrumentPrices",
        dataType: "json",
        success: function (response) {
            console.log("response : ")
            console.dir(response)
            response.forEach(AssingPriceToInstrument);
        },
        error: function () { console.log("error") }
    })
}
function AssingPriceToInstrument(item) {
    currentInstrumentId = '#instrument' + item.id;
    let inst = $(currentInstrumentId);
    let currInstPrice = inst.find('.instrument-price-item');
    let currInstVolumen = inst.find('.instrument-volumen-item');

    currInstPrice.text(item.price);
    currInstVolumen.text(item.volumen);


}

function findInstrument(element, index, array){
    
    if (array[index].id === currentInstrumentId) {
        console.log("---------TRUE------------")
        instruments[i]
            return true;
        }
        else {
            return false;
        }
}
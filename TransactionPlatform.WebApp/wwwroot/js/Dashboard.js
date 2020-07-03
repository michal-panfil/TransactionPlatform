let currentInstrumentId;
let Currentitem;
let UpdatedInstruments = [];

setInterval(GetInstrumentPrices, 10000);
$(document).ready(GetInstrumentPrices, 1000);

function OpenBuyInstrumentForm(name, identificator) {
    let popup = $('.popup-box');
    popup.toggle();
    let ticker = $('#buyTicker');
    let price = $('#buyPrice');
    let x = '#' + identificator;
    let instrumentprice = $(x).find('.instrument-price-item').text();
    ticker.val(name);
    price.val(instrumentprice);

}
function CancelBuyInstrumentForm() {
    let popup = $('.popup-box');
    popup.toggle();
}
function SentTransactionRequest () {
    let popup = $('.popup-box');
  
    let tic = $('#buyTicker').val();
    let prc = $('#buyPrice').val();
    let vol = $('#buyVolumen').val();
        
    
    popup.toggle();
    $.ajax({
        type: "POST",
        url: "TransactionService/BuyInstrument",
        data: { ticker: tic, price: prc, volumen: vol },
        dataType: "text",
        success: function (response) {
            console.log("response : ")
            console.dir(response)
            response.forEach(AssingPriceToInstrument);
        },
        error: function () { console.log("error") }
    })
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
    let highliteStyle;
    if (currInstPrice.text() > item.price) {
        highliteStyle = "highlightDown";
    }
    else if (currInstPrice.text() <= item.price) {
        highliteStyle = "highlightUp";
    }

    currInstPrice.text(item.price);
    currInstVolumen.text(item.volumen);

    setTimeout(function () { currInstPrice.addClass(highliteStyle); }, 1000);
    setTimeout(function () { currInstPrice.removeClass(highliteStyle); }, 2000);
    UpdatedInstruments.push(currInstPrice);
    UpdatedInstruments.push(currInstVolumen);
}

function HighlightUpdatedValues() {

    UpdatedInstruments.forEach(HighlightElement);

}

function HighlightElement(element, index, array) {
    var obj = {}
    obj = element[0];
    obj.addClas("highlight1s");
    obj.removeClas("highlight1s");
}
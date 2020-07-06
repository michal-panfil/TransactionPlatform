let currentInstrumentId, Currentitem;
let UpdatedInstruments = [];

$(document).ready(GetInstrumentPrices, 1000);
setInterval(GetInstrumentPrices, 10000);

//Buy Logic

function OpenBuyInstrumentForm(name, identificator) {
    let popup = $('.popup-box.popup-buy');
    popup.toggle();

    let ticker = $('#buyTicker');
    let price = $('#buyPrice');
    let id = '#' + identificator;
    let instrumentprice = $(id).find('.instrument-price-item').text();
    ticker.val(name);
    price.val(instrumentprice);
}

function SendBuyTransactionRequest() {
    let popup = $('.popup-box.popup-buy');

    let tic = $('#buyTicker').val();
    let prc = $('#buyPrice').val();
    let vol = $('#buyVolumen').val();
    if(tic)
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


// Sell logic

function OpenSellInstrumentForm(name, price, volumen) {
    let popup = $('.popup-box.popup-sell');
    popup.toggle();
    $('#sellTicker').val(name);
    $('#sellTicker').text(name);
    $('#sellPrice').val(price);
    $('#sellPrice').text(price);
    $('#sellVolumen').val(volumen);
    $('#sellVolumen').text(volumen);
}


function SendSellTransactionRequest() {
    let popup = $('.popup-box.popup-sell');

    let tic = $('#sellTicker').val();
    let prc = $('#sellPrice').val();
    let vol = $('#sellVolumen').val();

    popup.toggle();
    $.ajax({
        type: "POST",
        url: "TransactionService/SellInstrument",
        data: { ticker: tic, price: prc, volumen: vol },
        dataType: "text",
        success: function (response) {
            console.log("response : ")
            console.dir(response)
            let instrumentId = 'asset' + tic;
            $(instrumentId).remove();
        },
        error: function () { console.log("error") }
    })
    $('.container').append('<div class="popup-box request-succes"><h3>Request has been sent</h3></div>');
    setTimeout(function () { $('.request-succes').remove(); }, 2000);

}

//Instrument price update 

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

//Common logic

function CancelInstrumentForm() {
    let popup = $('.popup-box');
    popup.hide();
}
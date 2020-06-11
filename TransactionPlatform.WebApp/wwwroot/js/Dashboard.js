
function OpenBuyInstrumentForm() {
    let popup = $('.popup-box');
    popup.toggle();
}
function CancelBuyInstrumentForm() {
    let popup = $('.popup-box');
    popup.toggle();
}
function SentTransactionRequest() {
    let popup = $('.popup-box');
    popup.toggle();
    $('.container').append('<div class="popup-box request-succes"><h3>Request has been sent</h3></div>');

    setTimeout(function () { $('.request-succes').remove(); }, 2000);
}


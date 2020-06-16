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
    Currentitem = item
    let instruments = $('#instrumentsList').children();
    let instrumentsArr = instruments.toArray();

    console.log("item dir :")
        console.dir(item);
        console.log("instrument id :")
        console.log(item.id);

         currentInstrumentId = '#instrument' + item.id;
        console.log(currentInstrumentId);
    let inst = instrumentsArr.find(findInstrument);
    let inst2 = $(currentInstrumentId);
    
    console.log("inst : ");
   console.dir(inst);
    let currInst = inst2.find('.instrument-price-item');
    console.log("currInst : ");
    console.dir(currInst);
    
    currInst.text(item.price);
    console.log("price");

    console.log(item.price);
        console.log(currInst);
    console.log("------------");
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
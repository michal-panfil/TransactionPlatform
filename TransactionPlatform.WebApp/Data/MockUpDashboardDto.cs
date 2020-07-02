using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Models.WalletModels;
using TransactionPlatform.WebApp.Models;

namespace TransactionPlatform.WebApp.Data
{
    public class MockUpDashboardDto
    {
        
        public DashBoardDto GetMockUpDashboard()
        {
            

            var dashboard = new DashBoardDto();
            
           /* var assets = new List<AssetDtp> {
                new Asset{Id =1, InstrumentId = 1, UserId=1, BuyDT = DateTime.Now, Price = 200M, Volumen = 550},
                new Asset{Id =2, InstrumentId = 2, UserId=1, BuyDT = DateTime.Now, Price = 52M, Volumen = 700},
                new Asset{Id =3, InstrumentId = 3, UserId=1, BuyDT = DateTime.Now, Price = 11M, Volumen = 1420}

            };*/

        /*    dashboard.UserWallet = new StandardWallet()
            {
                Id = 1,
                OwnerId = 1,
                Cash = 13400,
                SumInvestedMoney= 50000,
               // Assets = assets,
            };*/
            /*
            dashboard.Instruments.Add(new Instrument() {Id = 1, Name = "Oil Barnd 3", Ticker= "OB3", Description ="The clearest and moste value cartify oil"}); 
            dashboard.Instruments.Add(new Instrument() {Id = 2, Name = "Corn US", Ticker= "CUS", Description ="Corn from midlle of USA wigh quality"}); 
            dashboard.Instruments.Add(new Instrument() {Id = 3, Name = "Platinum", Ticker= "PLM", Description ="Platinum for electronic puroses"}); 
            dashboard.Instruments.Add(new Instrument() {Id = 4, Name = "Caffe Arabica", Ticker= "CA", Description ="Coffe rady to be burn, Arabbica type "}); 
            dashboard.Instruments.Add(new Instrument() {Id = 5, Name = "Steal", Ticker= "STL", Description ="Certificated construction steal"}); 
            dashboard.Instruments.Add(new Instrument() {Id = 6, Name = "Wood", Ticker= "WOD", Description ="Brasilian wood - long size"}); 
            dashboard.Instruments.Add(new Instrument() {Id = 7, Name = "Natural GAS", Ticker= "NGS", Description ="Rusian low quality natural gas"}); 
            dashboard.Instruments.Add(new Instrument() {Id = 8, Name = "Wather", Ticker= "WTR", Description ="Contract 6 mont for water"}); 
            */
            return dashboard;
        }
    }
}

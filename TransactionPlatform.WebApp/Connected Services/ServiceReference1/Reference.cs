﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ITransactionService")]
    public interface ITransactionService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransactionService/GetPriceOfInstrument", ReplyAction="http://tempuri.org/ITransactionService/GetPriceOfInstrumentResponse")]
        System.Threading.Tasks.Task<float> GetPriceOfInstrumentAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransactionService/GetPriceOfAllInstruments", ReplyAction="http://tempuri.org/ITransactionService/GetPriceOfAllInstrumentsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<TransactionPlatform.DomainLibrary.Dtos.InstrumentPriceDto>> GetPriceOfAllInstrumentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransactionService/GetPriceOfAllInstrumentsAsync", ReplyAction="http://tempuri.org/ITransactionService/GetPriceOfAllInstrumentsAsyncResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<TransactionPlatform.DomainLibrary.Dtos.InstrumentPriceDto>> GetPriceOfAllInstrumentsAsyncAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransactionService/AcceptTransaction", ReplyAction="http://tempuri.org/ITransactionService/AcceptTransactionResponse")]
        System.Threading.Tasks.Task<bool> AcceptTransactionAsync(TransactionPlatform.DomainLibrary.Dtos.OrderForm transactionDto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ITransactionServiceChannel : ServiceReference1.ITransactionService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class TransactionServiceClient : System.ServiceModel.ClientBase<ServiceReference1.ITransactionService>, ServiceReference1.ITransactionService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TransactionServiceClient() : 
                base(TransactionServiceClient.GetDefaultBinding(), TransactionServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ITransactionService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransactionServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TransactionServiceClient.GetBindingForEndpoint(endpointConfiguration), TransactionServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransactionServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TransactionServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransactionServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TransactionServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransactionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<float> GetPriceOfInstrumentAsync(int id)
        {
            return base.Channel.GetPriceOfInstrumentAsync(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<TransactionPlatform.DomainLibrary.Dtos.InstrumentPriceDto>> GetPriceOfAllInstrumentsAsync()
        {
            return base.Channel.GetPriceOfAllInstrumentsAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<TransactionPlatform.DomainLibrary.Dtos.InstrumentPriceDto>> GetPriceOfAllInstrumentsAsyncAsync()
        {
            return base.Channel.GetPriceOfAllInstrumentsAsyncAsync();
        }
        
        public System.Threading.Tasks.Task<bool> AcceptTransactionAsync(TransactionPlatform.DomainLibrary.Dtos.OrderForm transactionDto)
        {
            return base.Channel.AcceptTransactionAsync(transactionDto);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITransactionService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITransactionService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:55365/TransactionService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TransactionServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ITransactionService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TransactionServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ITransactionService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ITransactionService,
        }
    }
}

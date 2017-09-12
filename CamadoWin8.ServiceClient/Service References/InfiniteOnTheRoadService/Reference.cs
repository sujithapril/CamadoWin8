﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 14.0.23107.0
// 
namespace CamadoWin8.ServiceClient.InfiniteOnTheRoadService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Travel", Namespace="")]
    public partial class Travel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int ContinentIdField;
        
        private string DescriptionField;
        
        private int DurationField;
        
        private string ImageUrlField;
        
        private string OutlineField;
        
        private string ShortTitleField;
        
        private int TravelIdField;
        
        private string TravelNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ContinentId {
            get {
                return this.ContinentIdField;
            }
            set {
                if ((this.ContinentIdField.Equals(value) != true)) {
                    this.ContinentIdField = value;
                    this.RaisePropertyChanged("ContinentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Duration {
            get {
                return this.DurationField;
            }
            set {
                if ((this.DurationField.Equals(value) != true)) {
                    this.DurationField = value;
                    this.RaisePropertyChanged("Duration");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageUrl {
            get {
                return this.ImageUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageUrlField, value) != true)) {
                    this.ImageUrlField = value;
                    this.RaisePropertyChanged("ImageUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Outline {
            get {
                return this.OutlineField;
            }
            set {
                if ((object.ReferenceEquals(this.OutlineField, value) != true)) {
                    this.OutlineField = value;
                    this.RaisePropertyChanged("Outline");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShortTitle {
            get {
                return this.ShortTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.ShortTitleField, value) != true)) {
                    this.ShortTitleField = value;
                    this.RaisePropertyChanged("ShortTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TravelId {
            get {
                return this.TravelIdField;
            }
            set {
                if ((this.TravelIdField.Equals(value) != true)) {
                    this.TravelIdField = value;
                    this.RaisePropertyChanged("TravelId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TravelName {
            get {
                return this.TravelNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TravelNameField, value) != true)) {
                    this.TravelNameField = value;
                    this.RaisePropertyChanged("TravelName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="InfiniteOnTheRoadService.InfiniteCamadoWin8Service")]
    public interface InfiniteCamadoWin8Service {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:InfiniteCamadoWin8Service/GetTravels", ReplyAction="urn:InfiniteCamadoWin8Service/GetTravelsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CamadoWin8.ServiceClient.InfiniteOnTheRoadService.Travel>> GetTravelsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface InfiniteCamadoWin8ServiceChannel : CamadoWin8.ServiceClient.InfiniteOnTheRoadService.InfiniteCamadoWin8Service, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InfiniteCamadoWin8ServiceClient : System.ServiceModel.ClientBase<CamadoWin8.ServiceClient.InfiniteOnTheRoadService.InfiniteCamadoWin8Service>, CamadoWin8.ServiceClient.InfiniteOnTheRoadService.InfiniteCamadoWin8Service {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public InfiniteCamadoWin8ServiceClient() : 
                base(InfiniteCamadoWin8ServiceClient.GetDefaultBinding(), InfiniteCamadoWin8ServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.CustomBinding_InfiniteCamadoWin8Service.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InfiniteCamadoWin8ServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(InfiniteCamadoWin8ServiceClient.GetBindingForEndpoint(endpointConfiguration), InfiniteCamadoWin8ServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InfiniteCamadoWin8ServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(InfiniteCamadoWin8ServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InfiniteCamadoWin8ServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(InfiniteCamadoWin8ServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InfiniteCamadoWin8ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CamadoWin8.ServiceClient.InfiniteOnTheRoadService.Travel>> GetTravelsAsync() {
            return base.Channel.GetTravelsAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.CustomBinding_InfiniteCamadoWin8Service)) {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                result.Elements.Add(new System.ServiceModel.Channels.BinaryMessageEncodingBindingElement());
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.CustomBinding_InfiniteCamadoWin8Service)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:35756/InfiniteCamadoWin8Service.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return InfiniteCamadoWin8ServiceClient.GetBindingForEndpoint(EndpointConfiguration.CustomBinding_InfiniteCamadoWin8Service);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return InfiniteCamadoWin8ServiceClient.GetEndpointAddress(EndpointConfiguration.CustomBinding_InfiniteCamadoWin8Service);
        }
        
        public enum EndpointConfiguration {
            
            CustomBinding_InfiniteCamadoWin8Service,
        }
    }
}

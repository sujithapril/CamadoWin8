﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication.CamadoSer {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Device", Namespace="")]
    [System.SerializableAttribute()]
    public partial class Device : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DeviceIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeviceMacIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NickNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
        public int DeviceId {
            get {
                return this.DeviceIdField;
            }
            set {
                if ((this.DeviceIdField.Equals(value) != true)) {
                    this.DeviceIdField = value;
                    this.RaisePropertyChanged("DeviceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeviceMacId {
            get {
                return this.DeviceMacIdField;
            }
            set {
                if ((object.ReferenceEquals(this.DeviceMacIdField, value) != true)) {
                    this.DeviceMacIdField = value;
                    this.RaisePropertyChanged("DeviceMacId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NickName {
            get {
                return this.NickNameField;
            }
            set {
                if ((object.ReferenceEquals(this.NickNameField, value) != true)) {
                    this.NickNameField = value;
                    this.RaisePropertyChanged("NickName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CamadoSer.ICamadoService")]
    public interface ICamadoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamadoService/GetDevices", ReplyAction="http://tempuri.org/ICamadoService/GetDevicesResponse")]
        ConsoleApplication.CamadoSer.Device[] GetDevices();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamadoService/GetDevices", ReplyAction="http://tempuri.org/ICamadoService/GetDevicesResponse")]
        System.Threading.Tasks.Task<ConsoleApplication.CamadoSer.Device[]> GetDevicesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICamadoServiceChannel : ConsoleApplication.CamadoSer.ICamadoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CamadoServiceClient : System.ServiceModel.ClientBase<ConsoleApplication.CamadoSer.ICamadoService>, ConsoleApplication.CamadoSer.ICamadoService {
        
        public CamadoServiceClient() {
        }
        
        public CamadoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CamadoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CamadoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CamadoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsoleApplication.CamadoSer.Device[] GetDevices() {
            return base.Channel.GetDevices();
        }
        
        public System.Threading.Tasks.Task<ConsoleApplication.CamadoSer.Device[]> GetDevicesAsync() {
            return base.Channel.GetDevicesAsync();
        }
    }
}

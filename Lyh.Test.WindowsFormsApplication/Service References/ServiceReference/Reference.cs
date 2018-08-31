﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1008
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lyh.Test.WindowsFormsApplication.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Lyh.MyBatis.Model")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CtfIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string CtfId {
            get {
                return this.CtfIdField;
            }
            set {
                if ((object.ReferenceEquals(this.CtfIdField, value) != true)) {
                    this.CtfIdField = value;
                    this.RaisePropertyChanged("CtfId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IUserContract")]
    public interface IUserContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserContract/Login", ReplyAction="http://tempuri.org/IUserContract/LoginResponse")]
        bool Login(string name, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserContract/GetUser", ReplyAction="http://tempuri.org/IUserContract/GetUserResponse")]
        Lyh.Test.WindowsFormsApplication.ServiceReference.User GetUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserContract/GetPageUsers", ReplyAction="http://tempuri.org/IUserContract/GetPageUsersResponse")]
        Lyh.Test.WindowsFormsApplication.ServiceReference.User[] GetPageUsers(int pageIndex, int pageSize);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserContract/GetTotalCount", ReplyAction="http://tempuri.org/IUserContract/GetTotalCountResponse")]
        int GetTotalCount();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserContractChannel : Lyh.Test.WindowsFormsApplication.ServiceReference.IUserContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserContractClient : System.ServiceModel.ClientBase<Lyh.Test.WindowsFormsApplication.ServiceReference.IUserContract>, Lyh.Test.WindowsFormsApplication.ServiceReference.IUserContract {
        
        public UserContractClient() {
        }
        
        public UserContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Login(string name, string password) {
            return base.Channel.Login(name, password);
        }
        
        public Lyh.Test.WindowsFormsApplication.ServiceReference.User GetUser(int id) {
            return base.Channel.GetUser(id);
        }
        
        public Lyh.Test.WindowsFormsApplication.ServiceReference.User[] GetPageUsers(int pageIndex, int pageSize) {
            return base.Channel.GetPageUsers(pageIndex, pageSize);
        }
        
        public int GetTotalCount() {
            return base.Channel.GetTotalCount();
        }
    }
}

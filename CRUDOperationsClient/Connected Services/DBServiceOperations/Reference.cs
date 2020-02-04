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
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 16.0.29512.175
// 

using System;
using System.ServiceModel;

namespace CRUDOperationsClient.DBServiceOperations
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "EmployeeDto", Namespace = "http://schemas.datacontract.org/2004/07/CRUDOperationsCommon.Dtos")]
    public partial class EmployeeDto : object, System.ComponentModel.INotifyPropertyChanged
    {

        private int AgeField;

        private string EmailField;

        private int IdField;

        private string NameField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age
        {
            get
            {
                return this.AgeField;
            }
            set
            {
                if ((this.AgeField.Equals(value) != true))
                {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                if ((object.ReferenceEquals(this.EmailField, value) != true))
                {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((this.IdField.Equals(value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NameField, value) != true))
                {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "DBServiceOperations.IDBService")]
    public interface IDBService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDBService/InsertEmployee", ReplyAction = "http://tempuri.org/IDBService/InsertEmployeeResponse")]
        System.Threading.Tasks.Task<bool> InsertEmployeeAsync(CRUDOperationsClient.DBServiceOperations.EmployeeDto employee);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDBService/UpdateEmployee", ReplyAction = "http://tempuri.org/IDBService/UpdateEmployeeResponse")]
        System.Threading.Tasks.Task<bool> UpdateEmployeeAsync(CRUDOperationsClient.DBServiceOperations.EmployeeDto employee);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDBService/DeleteEmployee", ReplyAction = "http://tempuri.org/IDBService/DeleteEmployeeResponse")]
        System.Threading.Tasks.Task<bool> DeleteEmployeeAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDBService/SelectOneEmployee", ReplyAction = "http://tempuri.org/IDBService/SelectOneEmployeeResponse")]
        System.Threading.Tasks.Task<CRUDOperationsClient.DBServiceOperations.EmployeeDto> SelectOneEmployeeAsync(int id);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDBServiceChannel : CRUDOperationsClient.DBServiceOperations.IDBService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DBServiceClient : System.ServiceModel.ClientBase<CRUDOperationsClient.DBServiceOperations.IDBService>, CRUDOperationsClient.DBServiceOperations.IDBService, IDisposable
    {

        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public DBServiceClient() :
                base(DBServiceClient.GetDefaultBinding(), DBServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IDBService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public DBServiceClient(EndpointConfiguration endpointConfiguration) :
                base(DBServiceClient.GetBindingForEndpoint(endpointConfiguration), DBServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public DBServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(DBServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public DBServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(DBServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public DBServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public System.Threading.Tasks.Task<bool> InsertEmployeeAsync(CRUDOperationsClient.DBServiceOperations.EmployeeDto employee)
        {
            return base.Channel.InsertEmployeeAsync(employee);
        }

        public System.Threading.Tasks.Task<bool> UpdateEmployeeAsync(CRUDOperationsClient.DBServiceOperations.EmployeeDto employee)
        {
            return base.Channel.UpdateEmployeeAsync(employee);
        }

        public System.Threading.Tasks.Task<bool> DeleteEmployeeAsync(int id)
        {
            return base.Channel.DeleteEmployeeAsync(id);
        }

        public System.Threading.Tasks.Task<CRUDOperationsClient.DBServiceOperations.EmployeeDto> SelectOneEmployeeAsync(int id)
        {
            return base.Channel.SelectOneEmployeeAsync(id);
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDBService))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDBService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:14389/DBService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return DBServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IDBService);
        }

        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return DBServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IDBService);
        }

        public enum EndpointConfiguration
        {

            BasicHttpBinding_IDBService,
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (State != CommunicationState.Faulted)
                    {
                        CloseAsync();
                    }
                }
                finally
                {
                    if (State != CommunicationState.Closed)
                    {
                        Abort();
                    }
                }
            }
        }

        ~DBServiceClient()
        {
            Dispose(false);
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIARClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayerAlreadyExistsInDataBase", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
    [System.SerializableAttribute()]
    public partial class PlayerAlreadyExistsInDataBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
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
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpponentDisconnectedFault", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
    [System.SerializableAttribute()]
    public partial class OpponentDisconnectedFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailField;
        
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
        public string Detail {
            get {
                return this.DetailField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailField, value) != true)) {
                    this.DetailField = value;
                    this.RaisePropertyChanged("Detail");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayerDoesntExistInDataBase", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
    [System.SerializableAttribute()]
    public partial class PlayerDoesntExistInDataBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
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
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayerAlreadyConnectedFault", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
    [System.SerializableAttribute()]
    public partial class PlayerAlreadyConnectedFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
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
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MoveResult", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
    public enum MoveResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        YouWon = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Draw = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NotYourTurn = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GameOn = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayerInfo", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
    [System.SerializableAttribute()]
    public partial class PlayerInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LosesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> PlayedAgainstField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ScoreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WinsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
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
        public int Loses {
            get {
                return this.LosesField;
            }
            set {
                if ((this.LosesField.Equals(value) != true)) {
                    this.LosesField = value;
                    this.RaisePropertyChanged("Loses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> PlayedAgainst {
            get {
                return this.PlayedAgainstField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayedAgainstField, value) != true)) {
                    this.PlayedAgainstField = value;
                    this.RaisePropertyChanged("PlayedAgainst");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Score {
            get {
                return this.ScoreField;
            }
            set {
                if ((this.ScoreField.Equals(value) != true)) {
                    this.ScoreField = value;
                    this.RaisePropertyChanged("Score");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Wins {
            get {
                return this.WinsField;
            }
            set {
                if ((this.WinsField.Equals(value) != true)) {
                    this.WinsField = value;
                    this.RaisePropertyChanged("Wins");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IFIARService", CallbackContract=typeof(FIARClient.ServiceReference1.IFIARServiceCallback))]
    public interface IFIARService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/RegisterPlayer", ReplyAction="http://tempuri.org/IFIARService/RegisterPlayerResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(FIARClient.ServiceReference1.PlayerAlreadyExistsInDataBase), Action="http://tempuri.org/IFIARService/RegisterPlayerPlayerAlreadyExistsInDataBaseFault", Name="PlayerAlreadyExistsInDataBase", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
        void RegisterPlayer(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/RegisterPlayer", ReplyAction="http://tempuri.org/IFIARService/RegisterPlayerResponse")]
        System.Threading.Tasks.Task RegisterPlayerAsync(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/InvatationSend", ReplyAction="http://tempuri.org/IFIARService/InvatationSendResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(FIARClient.ServiceReference1.OpponentDisconnectedFault), Action="http://tempuri.org/IFIARService/InvatationSendOpponentDisconnectedFaultFault", Name="OpponentDisconnectedFault", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
        bool InvatationSend(string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/InvatationSend", ReplyAction="http://tempuri.org/IFIARService/InvatationSendResponse")]
        System.Threading.Tasks.Task<bool> InvatationSendAsync(string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/PlayerLogin", ReplyAction="http://tempuri.org/IFIARService/PlayerLoginResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(FIARClient.ServiceReference1.PlayerDoesntExistInDataBase), Action="http://tempuri.org/IFIARService/PlayerLoginPlayerDoesntExistInDataBaseFault", Name="PlayerDoesntExistInDataBase", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
        [System.ServiceModel.FaultContractAttribute(typeof(FIARClient.ServiceReference1.PlayerAlreadyConnectedFault), Action="http://tempuri.org/IFIARService/PlayerLoginPlayerAlreadyConnectedFaultFault", Name="PlayerAlreadyConnectedFault", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
        void PlayerLogin(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/PlayerLogin", ReplyAction="http://tempuri.org/IFIARService/PlayerLoginResponse")]
        System.Threading.Tasks.Task PlayerLoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/PlayerLogout", ReplyAction="http://tempuri.org/IFIARService/PlayerLogoutResponse")]
        void PlayerLogout(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/PlayerLogout", ReplyAction="http://tempuri.org/IFIARService/PlayerLogoutResponse")]
        System.Threading.Tasks.Task PlayerLogoutAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/Disconnected", ReplyAction="http://tempuri.org/IFIARService/DisconnectedResponse")]
        void Disconnected(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/Disconnected", ReplyAction="http://tempuri.org/IFIARService/DisconnectedResponse")]
        System.Threading.Tasks.Task DisconnectedAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/ReportMove", ReplyAction="http://tempuri.org/IFIARService/ReportMoveResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(FIARClient.ServiceReference1.OpponentDisconnectedFault), Action="http://tempuri.org/IFIARService/ReportMoveOpponentDisconnectedFaultFault", Name="OpponentDisconnectedFault", Namespace="http://schemas.datacontract.org/2004/07/WcfFIARService")]
        FIARClient.ServiceReference1.MoveResult ReportMove(string username, int col);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/ReportMove", ReplyAction="http://tempuri.org/IFIARService/ReportMoveResponse")]
        System.Threading.Tasks.Task<FIARClient.ServiceReference1.MoveResult> ReportMoveAsync(string username, int col);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/GetAvalibalePlayers", ReplyAction="http://tempuri.org/IFIARService/GetAvalibalePlayersResponse")]
        System.Collections.Generic.List<FIARClient.ServiceReference1.PlayerInfo> GetAvalibalePlayers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/GetAvalibalePlayers", ReplyAction="http://tempuri.org/IFIARService/GetAvalibalePlayersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<FIARClient.ServiceReference1.PlayerInfo>> GetAvalibalePlayersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFIARServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFIARService/SendInvite", ReplyAction="http://tempuri.org/IFIARService/SendInviteResponse")]
        bool SendInvite(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFIARService/OtherPlayerMoved")]
        void OtherPlayerMoved(FIARClient.ServiceReference1.MoveResult result, int col);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFIARService/UpdateClients")]
        void UpdateClients(System.Collections.Generic.List<FIARClient.ServiceReference1.PlayerInfo> players);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFIARService/StartGame")]
        void StartGame();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFIARServiceChannel : FIARClient.ServiceReference1.IFIARService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FIARServiceClient : System.ServiceModel.DuplexClientBase<FIARClient.ServiceReference1.IFIARService>, FIARClient.ServiceReference1.IFIARService {
        
        public FIARServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public FIARServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public FIARServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public FIARServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public FIARServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void RegisterPlayer(string username, string pass) {
            base.Channel.RegisterPlayer(username, pass);
        }
        
        public System.Threading.Tasks.Task RegisterPlayerAsync(string username, string pass) {
            return base.Channel.RegisterPlayerAsync(username, pass);
        }
        
        public bool InvatationSend(string from, string to) {
            return base.Channel.InvatationSend(from, to);
        }
        
        public System.Threading.Tasks.Task<bool> InvatationSendAsync(string from, string to) {
            return base.Channel.InvatationSendAsync(from, to);
        }
        
        public void PlayerLogin(string username, string password) {
            base.Channel.PlayerLogin(username, password);
        }
        
        public System.Threading.Tasks.Task PlayerLoginAsync(string username, string password) {
            return base.Channel.PlayerLoginAsync(username, password);
        }
        
        public void PlayerLogout(string username) {
            base.Channel.PlayerLogout(username);
        }
        
        public System.Threading.Tasks.Task PlayerLogoutAsync(string username) {
            return base.Channel.PlayerLogoutAsync(username);
        }
        
        public void Disconnected(string username) {
            base.Channel.Disconnected(username);
        }
        
        public System.Threading.Tasks.Task DisconnectedAsync(string username) {
            return base.Channel.DisconnectedAsync(username);
        }
        
        public FIARClient.ServiceReference1.MoveResult ReportMove(string username, int col) {
            return base.Channel.ReportMove(username, col);
        }
        
        public System.Threading.Tasks.Task<FIARClient.ServiceReference1.MoveResult> ReportMoveAsync(string username, int col) {
            return base.Channel.ReportMoveAsync(username, col);
        }
        
        public System.Collections.Generic.List<FIARClient.ServiceReference1.PlayerInfo> GetAvalibalePlayers() {
            return base.Channel.GetAvalibalePlayers();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<FIARClient.ServiceReference1.PlayerInfo>> GetAvalibalePlayersAsync() {
            return base.Channel.GetAvalibalePlayersAsync();
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSMS.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("JafferjeeBrothers")]
        public string MySQLUsername {
            get {
                return ((string)(this["MySQLUsername"]));
            }
            set {
                this["MySQLUsername"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MSSM@JBDB")]
        public string MySQLPassword {
            get {
                return ((string)(this["MySQLPassword"]));
            }
            set {
                this["MySQLPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string MySQLHost {
            get {
                return ((string)(this["MySQLHost"]));
            }
            set {
                this["MySQLHost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mssmsdb")]
        public string MySQLDatabase {
            get {
                return ((string)(this["MySQLDatabase"]));
            }
            set {
                this["MySQLDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3306")]
        public string MySQLPort {
            get {
                return ((string)(this["MySQLPort"]));
            }
            set {
                this["MySQLPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("jafferjeebrothersteadivision@gmail.com")]
        public string EMAILUsername {
            get {
                return ((string)(this["EMAILUsername"]));
            }
            set {
                this["EMAILUsername"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MSSM@JBDB")]
        public string EMAILPassword {
            get {
                return ((string)(this["EMAILPassword"]));
            }
            set {
                this["EMAILPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("E2000001")]
        public string DefaultAdmin {
            get {
                return ((string)(this["DefaultAdmin"]));
            }
            set {
                this["DefaultAdmin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DefaultPhoneRegEx {
            get {
                return ((string)(this["DefaultPhoneRegEx"]));
            }
            set {
                this["DefaultPhoneRegEx"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DefaultEmailRegEx {
            get {
                return ((string)(this["DefaultEmailRegEx"]));
            }
            set {
                this["DefaultEmailRegEx"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("24")]
        public string DefaultTimeFormat {
            get {
                return ((string)(this["DefaultTimeFormat"]));
            }
            set {
                this["DefaultTimeFormat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("WW")]
        public string DefaultPhoneRegion {
            get {
                return ((string)(this["DefaultPhoneRegion"]));
            }
            set {
                this["DefaultPhoneRegion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smtp.gmail.com")]
        public string SMTPHost {
            get {
                return ((string)(this["SMTPHost"]));
            }
            set {
                this["SMTPHost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public int SMTPPort {
            get {
                return ((int)(this["SMTPPort"]));
            }
            set {
                this["SMTPPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SMTPSSL {
            get {
                return ((bool)(this["SMTPSSL"]));
            }
            set {
                this["SMTPSSL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SMTPDefaultCredentials {
            get {
                return ((bool)(this["SMTPDefaultCredentials"]));
            }
            set {
                this["SMTPDefaultCredentials"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int SMTPDeliveryMethod {
            get {
                return ((int)(this["SMTPDeliveryMethod"]));
            }
            set {
                this["SMTPDeliveryMethod"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public double DefaultTokenExpTime {
            get {
                return ((double)(this["DefaultTokenExpTime"]));
            }
            set {
                this["DefaultTokenExpTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("JafferjeeBrothers")]
        public string DefaultMySQLUsername {
            get {
                return ((string)(this["DefaultMySQLUsername"]));
            }
            set {
                this["DefaultMySQLUsername"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MSSM@JBDB")]
        public string DefaultMySQLPassword {
            get {
                return ((string)(this["DefaultMySQLPassword"]));
            }
            set {
                this["DefaultMySQLPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string DefaultMySQLHost {
            get {
                return ((string)(this["DefaultMySQLHost"]));
            }
            set {
                this["DefaultMySQLHost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3306")]
        public string DefaultMySQLPort {
            get {
                return ((string)(this["DefaultMySQLPort"]));
            }
            set {
                this["DefaultMySQLPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MSSM@JBDB")]
        public string MSSMMasterPassword {
            get {
                return ((string)(this["MSSMMasterPassword"]));
            }
            set {
                this["MSSMMasterPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MSSM@JBDB")]
        public string DefaultMSSMMasterPassword {
            get {
                return ((string)(this["DefaultMSSMMasterPassword"]));
            }
            set {
                this["DefaultMSSMMasterPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smtp.gmail.com")]
        public string DefaultSMTPHost {
            get {
                return ((string)(this["DefaultSMTPHost"]));
            }
            set {
                this["DefaultSMTPHost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public int DefaultSMTPPort {
            get {
                return ((int)(this["DefaultSMTPPort"]));
            }
            set {
                this["DefaultSMTPPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool DefaultSMTPSSL {
            get {
                return ((bool)(this["DefaultSMTPSSL"]));
            }
            set {
                this["DefaultSMTPSSL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public string TokenExpTime {
            get {
                return ((string)(this["TokenExpTime"]));
            }
            set {
                this["TokenExpTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("24")]
        public string CurrentTimeFormat {
            get {
                return ((string)(this["CurrentTimeFormat"]));
            }
            set {
                this["CurrentTimeFormat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dark")]
        public string DefaultTheme {
            get {
                return ((string)(this["DefaultTheme"]));
            }
            set {
                this["DefaultTheme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Light")]
        public string CurrentTheme {
            get {
                return ((string)(this["CurrentTheme"]));
            }
            set {
                this["CurrentTheme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LK")]
        public string CurrentPhoneRegion {
            get {
                return ((string)(this["CurrentPhoneRegion"]));
            }
            set {
                this["CurrentPhoneRegion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CurrentEmailRegEx {
            get {
                return ((string)(this["CurrentEmailRegEx"]));
            }
            set {
                this["CurrentEmailRegEx"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CurrentPhoneRegEx {
            get {
                return ((string)(this["CurrentPhoneRegEx"]));
            }
            set {
                this["CurrentPhoneRegEx"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MSSM@JBDB")]
        public string DefaultEMAILPassword {
            get {
                return ((string)(this["DefaultEMAILPassword"]));
            }
            set {
                this["DefaultEMAILPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("jafferjeebrothersteadivision@gmail.com")]
        public string DefaultEMAILUsername {
            get {
                return ((string)(this["DefaultEMAILUsername"]));
            }
            set {
                this["DefaultEMAILUsername"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mssmsdb")]
        public string DefaultMySQLDatabase {
            get {
                return ((string)(this["DefaultMySQLDatabase"]));
            }
            set {
                this["DefaultMySQLDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MySQLPasswordSalt {
            get {
                return ((string)(this["MySQLPasswordSalt"]));
            }
            set {
                this["MySQLPasswordSalt"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string EMAILPasswordSalt {
            get {
                return ((string)(this["EMAILPasswordSalt"]));
            }
            set {
                this["EMAILPasswordSalt"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("16")]
        public int EmpMINAge {
            get {
                return ((int)(this["EmpMINAge"]));
            }
            set {
                this["EmpMINAge"] = value;
            }
        }
    }
}

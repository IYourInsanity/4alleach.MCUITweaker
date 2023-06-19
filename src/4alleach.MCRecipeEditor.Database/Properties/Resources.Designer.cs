﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _4alleach.MCRecipeEditor.Database.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("_4alleach.MCRecipeEditor.Database.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Item (
        ///	Id			        uniqueidentifier NOT NULL,
        ///    [Name]              nvarchar(100),
        ///    [Description]       nvarchar(500),
        ///    ItemTypeId   	    uniqueidentifier,
        ///    ModTypeId           uniqueidentifier,
        ///    ItemPrefixId        uniqueidentifier,
        ///    ItemPostfixId       uniqueidentifier,
        ///
        ///	CONSTRAINT Pk_Item PRIMARY KEY ( Id ),
        ///    FOREIGN KEY ( ItemTypeId ) REFERENCES ItemType( Id ),
        ///    FOREIGN KEY ( ModTypeId ) REFERENCES ModType( Id ),
        ///    FOREIGN KEY ( ItemPrefixId ) REFEREN [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Asset_Create {
            get {
                return ResourceManager.GetString("Asset_Create", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO ItemPrefix (
        ///	Id,
        ///    [Value]
        ///) 
        ///VALUES (
        ///	&apos;B5A0EB64-CB9F-47F8-B237-439C30ED170B&apos;,
        ///	&apos;Minecraft&apos;
        ///);
        ///
        ///INSERT INTO ItemPostfix (
        ///	Id,
        ///    [Value]
        ///) 
        ///VALUES (
        ///	&apos;EECDD304-2FB3-46B5-AE04-5A429640BD5D&apos;,
        ///	&apos;12&apos;
        ///);
        ///
        ///INSERT INTO ModType (
        ///	Id,
        ///    FullName,
        ///    ShortName
        ///) 
        ///VALUES (
        ///	&apos;17C59CA7-F168-4929-929E-F06745ABE58D&apos;,
        ///	&apos;Minecraft&apos;,
        ///    &apos;minecraft&apos;
        ///);
        ///
        ///INSERT INTO ItemType (
        ///	Id,
        ///    [Value]
        ///) 
        ///VALUES (
        ///	&apos;8D9F9455-4C58-4C54-AFD2-5C64BA1EA6AA&apos;,
        ///	&apos;Fluid&apos;
        ///);
        ///
        ///INSERT I [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Asset_Test_Item {
            get {
                return ResourceManager.GetString("Asset_Test_Item", resourceCulture);
            }
        }
    }
}

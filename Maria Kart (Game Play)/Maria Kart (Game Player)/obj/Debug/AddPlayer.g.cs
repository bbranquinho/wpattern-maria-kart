﻿#pragma checksum "..\..\AddPlayer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "724D701AE4CF62EDE49CB8F375848B0E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Maria_Kart__Game_Player_ {
    
    
    /// <summary>
    /// AddPlayer
    /// </summary>
    public partial class AddPlayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSave;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancel;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonReset;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxId;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxName;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxEmail;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImagePlayer;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxLeftHandUp;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxLeftHandDown;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxRightHandUp;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxRightHandDown;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxAge;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MariaKartGamePlayer;component/addplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddPlayer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\AddPlayer.xaml"
            ((Maria_Kart__Game_Player_.AddPlayer)(target)).Closed += new System.EventHandler(this.Window_Closed_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonSave = ((System.Windows.Controls.Button)(target));
            
            #line 6 "..\..\AddPlayer.xaml"
            this.ButtonSave.Click += new System.Windows.RoutedEventHandler(this.ButtonSave_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\AddPlayer.xaml"
            this.ButtonCancel.Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonReset = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\AddPlayer.xaml"
            this.ButtonReset.Click += new System.Windows.RoutedEventHandler(this.ButtonReset_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TextBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TextBoxEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ImagePlayer = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.TextBoxLeftHandUp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.TextBoxLeftHandDown = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.TextBoxRightHandUp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.TextBoxRightHandDown = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.TextBoxAge = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

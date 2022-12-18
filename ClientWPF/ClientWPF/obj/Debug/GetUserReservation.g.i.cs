﻿#pragma checksum "..\..\GetUserReservation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3A23507632A5FCEA34D154EAD421D32EB010135FC21E56E30184A5DFB1897AC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClientWPF;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace ClientWPF {
    
    
    /// <summary>
    /// GetUserReservation
    /// </summary>
    public partial class GetUserReservation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BackButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LogoutButton;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CloseButton;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Logo;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView OrderList;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Buttons;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelReservBtn;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BuyTicketBtn;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\GetUserReservation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Result;
        
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
            System.Uri resourceLocater = new System.Uri("/ClientWPF;component/getuserreservation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GetUserReservation.xaml"
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
            
            #line 13 "..\..\GetUserReservation.xaml"
            ((ClientWPF.GetUserReservation)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\GetUserReservation.xaml"
            ((ClientWPF.GetUserReservation)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ToolBar = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.BackButton = ((System.Windows.Controls.Image)(target));
            
            #line 46 "..\..\GetUserReservation.xaml"
            this.BackButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BackButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LogoutButton = ((System.Windows.Controls.Image)(target));
            
            #line 58 "..\..\GetUserReservation.xaml"
            this.LogoutButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LogoutButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CloseButton = ((System.Windows.Controls.Image)(target));
            
            #line 70 "..\..\GetUserReservation.xaml"
            this.CloseButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Logo = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.OrderList = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.Buttons = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.CancelReservBtn = ((System.Windows.Controls.Button)(target));
            
            #line 175 "..\..\GetUserReservation.xaml"
            this.CancelReservBtn.Click += new System.Windows.RoutedEventHandler(this.CancelReservBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BuyTicketBtn = ((System.Windows.Controls.Button)(target));
            
            #line 189 "..\..\GetUserReservation.xaml"
            this.BuyTicketBtn.Click += new System.Windows.RoutedEventHandler(this.BuyTicketBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Result = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

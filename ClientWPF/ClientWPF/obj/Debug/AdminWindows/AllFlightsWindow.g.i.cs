﻿#pragma checksum "..\..\..\AdminWindows\AllFlightsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5B9CD9CD5D00C8A021FABA9DCE2C8DF9C17BAAFBEF63A93BE309324816AE23B9"
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
    /// AllFlightsWindow
    /// </summary>
    public partial class AllFlightsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BackButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LogoutButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CloseButton;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Logo;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView FlightsList;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Buttons;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Result;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditFlightBtn;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteFlightBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/ClientWPF;component/adminwindows/allflightswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
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
            
            #line 13 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
            ((ClientWPF.AllFlightsWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
            ((ClientWPF.AllFlightsWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ToolBar = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.BackButton = ((System.Windows.Controls.Image)(target));
            
            #line 47 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
            this.BackButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BackButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LogoutButton = ((System.Windows.Controls.Image)(target));
            
            #line 59 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
            this.LogoutButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LogoutButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CloseButton = ((System.Windows.Controls.Image)(target));
            
            #line 71 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
            this.CloseButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Logo = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.FlightsList = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.Buttons = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.Result = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.EditFlightBtn = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
            this.EditFlightBtn.Click += new System.Windows.RoutedEventHandler(this.EditFlightBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DeleteFlightBtn = ((System.Windows.Controls.Button)(target));
            
            #line 191 "..\..\..\AdminWindows\AllFlightsWindow.xaml"
            this.DeleteFlightBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteFlightBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


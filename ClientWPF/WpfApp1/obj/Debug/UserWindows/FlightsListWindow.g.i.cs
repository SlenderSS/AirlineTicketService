﻿#pragma checksum "..\..\..\UserWindows\FlightsListWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "83D140043FC1385BED253B5686170A635946472FE84D837D9C78AC8558D8E0BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClientWPF.Src.Models;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections;
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
    /// FlightsListWindow
    /// </summary>
    public partial class FlightsListWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BackButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LogoutButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CloseButton;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Logo;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView FlightsList;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Buttons;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Result;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\UserWindows\FlightsListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReservBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/ClientWPF;component/userwindows/flightslistwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserWindows\FlightsListWindow.xaml"
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
            
            #line 14 "..\..\..\UserWindows\FlightsListWindow.xaml"
            ((ClientWPF.FlightsListWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\UserWindows\FlightsListWindow.xaml"
            ((ClientWPF.FlightsListWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ToolBar = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.BackButton = ((System.Windows.Controls.Image)(target));
            
            #line 47 "..\..\..\UserWindows\FlightsListWindow.xaml"
            this.BackButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BackButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LogoutButton = ((System.Windows.Controls.Image)(target));
            
            #line 59 "..\..\..\UserWindows\FlightsListWindow.xaml"
            this.LogoutButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LogoutButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CloseButton = ((System.Windows.Controls.Image)(target));
            
            #line 71 "..\..\..\UserWindows\FlightsListWindow.xaml"
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
            this.ReservBtn = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\..\UserWindows\FlightsListWindow.xaml"
            this.ReservBtn.Click += new System.Windows.RoutedEventHandler(this.ReservBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

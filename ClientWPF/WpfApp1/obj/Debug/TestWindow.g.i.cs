// Updated by XamlIntelliSenseFileGenerator 22.10.2022 15:47:53
#pragma checksum "..\..\TestWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EA1090AA5E28982010A7DCEC29D4FA074248305088656F9A3F1889915C85751B"
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


namespace ClientWPF
{


    /// <summary>
    /// TestWindow
    /// </summary>
    public partial class TestWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 80 "..\..\TestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Buttons;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClientWPF;component/testwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\TestWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 14 "..\..\TestWindow.xaml"
                    ((ClientWPF.TestWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);

#line default
#line hidden
                    return;
                case 2:
                    this.ToolBar = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.CloseButton = ((System.Windows.Controls.Image)(target));

#line 46 "..\..\TestWindow.xaml"
                    this.CloseButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseButton_MouseDown);

#line default
#line hidden
                    return;
                case 4:
                    this.Logo = ((System.Windows.Controls.Grid)(target));
                    return;
                case 5:
                    this.FormsBar = ((System.Windows.Controls.Grid)(target));
                    return;
                case 6:
                    this.txtUsername = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 8:
                    this.Buttons = ((System.Windows.Controls.Grid)(target));
                    return;
                case 9:
                    this.AutorizationBtn = ((System.Windows.Controls.Button)(target));

#line 92 "..\..\TestWindow.xaml"
                    this.AutorizationBtn.Click += new System.Windows.RoutedEventHandler(this.AutorizationBtn_Click);

#line default
#line hidden
                    return;
                case 10:
                    this.RegistrationBtn = ((System.Windows.Controls.Button)(target));

#line 102 "..\..\TestWindow.xaml"
                    this.RegistrationBtn.Click += new System.Windows.RoutedEventHandler(this.RegistrationBtn_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.LoginResult = ((System.Windows.Controls.TextBlock)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button SearchFlights_Button;
        internal System.Windows.Controls.Button GetInform_Button;
        internal System.Windows.Controls.Button GetMyReserves_Button;
        internal System.Windows.Controls.Grid Logo;
        internal System.Windows.Controls.Grid ToolBar;
        internal System.Windows.Controls.Image LogoutButton;
        internal System.Windows.Controls.Image CloseButton;
    }
}


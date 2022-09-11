﻿#pragma checksum "..\..\..\..\Views\Pages\Settings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99F1D1F23D8015946DFD4E96956B38621B50783B1F79787FD6D0C088AD27DB79"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using FlowerPot;
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


namespace FlowerPot {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\Views\Pages\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LanguageSelection;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Views\Pages\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonST;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\Pages\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGT;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Views\Pages\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDT;
        
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
            System.Uri resourceLocater = new System.Uri("/FlowerPot;component/views/pages/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\Settings.xaml"
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
            this.LanguageSelection = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\..\Views\Pages\Settings.xaml"
            this.LanguageSelection.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Language_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonST = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Views\Pages\Settings.xaml"
            this.ButtonST.Click += new System.Windows.RoutedEventHandler(this.ThemeStandart);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonGT = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\Views\Pages\Settings.xaml"
            this.ButtonGT.Click += new System.Windows.RoutedEventHandler(this.ThemeGrey);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonDT = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\Views\Pages\Settings.xaml"
            this.ButtonDT.Click += new System.Windows.RoutedEventHandler(this.ThemeDark);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

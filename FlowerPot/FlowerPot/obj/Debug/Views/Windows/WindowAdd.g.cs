﻿#pragma checksum "..\..\..\..\Views\Windows\WindowAdd.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C3BC4827578F5CA147EECFFD6796306CBE626D295AE06D21BE4CB47E04DBCAAB"
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
using FlowerPot.Views.Windows;
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


namespace FlowerPot.Views.Windows {
    
    
    /// <summary>
    /// WindowAdd
    /// </summary>
    public partial class WindowAdd : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ShortNameTB;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FullNameTB;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CostTB;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ColorCB;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AmountTB;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryCB;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionTB;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPictureBTTN;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddModelBTTN;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkBTTNADD;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Views\Windows\WindowAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBTTNADD;
        
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
            System.Uri resourceLocater = new System.Uri("/FlowerPot;component/views/windows/windowadd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Windows\WindowAdd.xaml"
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
            
            #line 21 "..\..\..\..\Views\Windows\WindowAdd.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ShortNameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.FullNameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CostTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ColorCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.AmountTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CategoryCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.DescriptionTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.AddPictureBTTN = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\Views\Windows\WindowAdd.xaml"
            this.AddPictureBTTN.Click += new System.Windows.RoutedEventHandler(this.AddPictureBTTN_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.AddModelBTTN = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\..\Views\Windows\WindowAdd.xaml"
            this.AddModelBTTN.Click += new System.Windows.RoutedEventHandler(this.AddModelBTTN_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.OkBTTNADD = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\..\Views\Windows\WindowAdd.xaml"
            this.OkBTTNADD.Click += new System.Windows.RoutedEventHandler(this.OkBTTNADD_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.CancelBTTNADD = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\..\Views\Windows\WindowAdd.xaml"
            this.CancelBTTNADD.Click += new System.Windows.RoutedEventHandler(this.CancelBTTNADD_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

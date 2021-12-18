﻿#pragma checksum "..\..\..\Views\DoctorWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D35E41733B1643AA80F78587C1DB95FD0B1EB7BFF0F4D3A74E729558381FFB60"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HealthyTeeth.Views;
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


namespace HealthyTeeth.Views {
    
    
    /// <summary>
    /// DoctorWindow
    /// </summary>
    public partial class DoctorWindow : HealthyTeeth.Views.BaseWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button removeRecord;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView recordsList;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn fio;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn dateRecord;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PaginatorPanel;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToFirst;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PagesList;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToLast;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Ascending;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Views\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Descending;
        
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
            System.Uri resourceLocater = new System.Uri("/HealthyTeeth;component/views/doctorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\DoctorWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.removeRecord = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Views\DoctorWindow.xaml"
            this.removeRecord.Click += new System.Windows.RoutedEventHandler(this.removeRecord_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exit = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Views\DoctorWindow.xaml"
            this.exit.Click += new System.Windows.RoutedEventHandler(this.exit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.recordsList = ((System.Windows.Controls.ListView)(target));
            
            #line 28 "..\..\..\Views\DoctorWindow.xaml"
            this.recordsList.Loaded += new System.Windows.RoutedEventHandler(this.recordsList_Loaded);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\Views\DoctorWindow.xaml"
            this.recordsList.SizeChanged += new System.Windows.SizeChangedEventHandler(this.recordsList_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.fio = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 5:
            this.dateRecord = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 6:
            this.PaginatorPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.ToFirst = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Views\DoctorWindow.xaml"
            this.ToFirst.Click += new System.Windows.RoutedEventHandler(this.ToFirst_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PagesList = ((System.Windows.Controls.ListView)(target));
            
            #line 54 "..\..\..\Views\DoctorWindow.xaml"
            this.PagesList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PagesList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ToLast = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Views\DoctorWindow.xaml"
            this.ToLast.Click += new System.Windows.RoutedEventHandler(this.ToLast_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Ascending = ((System.Windows.Controls.RadioButton)(target));
            
            #line 85 "..\..\..\Views\DoctorWindow.xaml"
            this.Ascending.Checked += new System.Windows.RoutedEventHandler(this.Ascending_Checked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Descending = ((System.Windows.Controls.RadioButton)(target));
            
            #line 86 "..\..\..\Views\DoctorWindow.xaml"
            this.Descending.Checked += new System.Windows.RoutedEventHandler(this.Descending_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


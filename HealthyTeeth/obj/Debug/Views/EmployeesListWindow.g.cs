#pragma checksum "..\..\..\Views\EmployeesListWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C6C9A371BE69017EBE1718C9358D4C87D43334F06A8AF382246CC76AA4D77ADF"
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
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Converters;
using MaterialDesignExtensions.Model;
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
    /// EmployeesListWindow
    /// </summary>
    public partial class EmployeesListWindow : HealthyTeeth.Views.BaseWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView EmployeesList;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn fio;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn gender;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn role;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn passport;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn phoneNumber;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PaginatorPanel;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToFirst;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PagesList;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToLast;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Ascending;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Descending;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Select;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewEmployee;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditEmployee;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveEmployee;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Views\EmployeesListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
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
            System.Uri resourceLocater = new System.Uri("/HealthyTeeth;component/views/employeeslistwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\EmployeesListWindow.xaml"
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
            this.EmployeesList = ((System.Windows.Controls.ListView)(target));
            
            #line 24 "..\..\..\Views\EmployeesListWindow.xaml"
            this.EmployeesList.SizeChanged += new System.Windows.SizeChangedEventHandler(this.EmployeesList_SizeChanged);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\Views\EmployeesListWindow.xaml"
            this.EmployeesList.Loaded += new System.Windows.RoutedEventHandler(this.EmployeesList_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.fio = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 3:
            this.gender = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 4:
            this.role = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 5:
            this.passport = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 6:
            this.phoneNumber = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 7:
            this.PaginatorPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.ToFirst = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Views\EmployeesListWindow.xaml"
            this.ToFirst.Click += new System.Windows.RoutedEventHandler(this.ToFirst_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.PagesList = ((System.Windows.Controls.ListView)(target));
            
            #line 73 "..\..\..\Views\EmployeesListWindow.xaml"
            this.PagesList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PagesList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ToLast = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Views\EmployeesListWindow.xaml"
            this.ToLast.Click += new System.Windows.RoutedEventHandler(this.ToLast_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Ascending = ((System.Windows.Controls.RadioButton)(target));
            
            #line 101 "..\..\..\Views\EmployeesListWindow.xaml"
            this.Ascending.Checked += new System.Windows.RoutedEventHandler(this.Ascending_Checked);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Descending = ((System.Windows.Controls.RadioButton)(target));
            
            #line 102 "..\..\..\Views\EmployeesListWindow.xaml"
            this.Descending.Checked += new System.Windows.RoutedEventHandler(this.Descending_Checked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Select = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\Views\EmployeesListWindow.xaml"
            this.Select.Click += new System.Windows.RoutedEventHandler(this.Select_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.AddNewEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\Views\EmployeesListWindow.xaml"
            this.AddNewEmployee.Click += new System.Windows.RoutedEventHandler(this.AddNewEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.EditEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\Views\EmployeesListWindow.xaml"
            this.EditEmployee.Click += new System.Windows.RoutedEventHandler(this.EditEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.RemoveEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\Views\EmployeesListWindow.xaml"
            this.RemoveEmployee.Click += new System.Windows.RoutedEventHandler(this.RemoveEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\Views\EmployeesListWindow.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\MainWindowB02.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EED744C432D49D9B3BB29975799338BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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


namespace JTool_Frame {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\MainWindowB02.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Skin;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindowB02.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu JTMenu;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\MainWindowB02.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid poo;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\MainWindowB02.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPoo;
        
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
            System.Uri resourceLocater = new System.Uri("/JTool-Frame;component/mainwindowb02.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindowB02.xaml"
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
            
            #line 5 "..\..\MainWindowB02.xaml"
            ((JTool_Frame.MainWindow)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.BackGround_MouseMove);
            
            #line default
            #line hidden
            
            #line 5 "..\..\MainWindowB02.xaml"
            ((JTool_Frame.MainWindow)(target)).StateChanged += new System.EventHandler(this.Window_StateChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 9 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Grid_MouseMove);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Skin = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.JTMenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 5:
            
            #line 22 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.JTSetting_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 23 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.JTInter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 24 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.JTScreen2_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 25 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.JTScreen1_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 26 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.JTColorPicker_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 27 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.JTMini_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 28 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.JTAbout_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 29 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.JTExit_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 34 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_JT1_Click);
            
            #line default
            #line hidden
            
            #line 35 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.Button)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Button_JT1_MouseMove);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 48 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_JT2_Click);
            
            #line default
            #line hidden
            
            #line 48 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.Button)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Button_JT2_MouseMove);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 58 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ColorPicker_Click);
            
            #line default
            #line hidden
            
            #line 60 "..\..\MainWindowB02.xaml"
            ((System.Windows.Controls.Button)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Button_ColorPicker_MouseMove);
            
            #line default
            #line hidden
            return;
            case 16:
            this.poo = ((System.Windows.Controls.Grid)(target));
            return;
            case 17:
            this.txtPoo = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImitateSmartisanNote
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.ui_imageTitle.MouseLeftButtonDown += Ui_imageTitle_MouseLeftButtonDown;
            var noteManager = new NoteManager();

            NotesDataProvider dataProvider = new NotesDataProvider();
            foreach(var item in dataProvider.LoadData())
            {
                noteManager.Notes.Add(item);
            }

            this.DataContext = noteManager;
        }

        private void Ui_imageTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

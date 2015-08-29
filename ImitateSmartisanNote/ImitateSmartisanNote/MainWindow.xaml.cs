using System;
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

            var noteManager = new NoteManager();

            noteManager.Notes.Add(new NoteItemModel("2015-1-2", "今天天气很好"));
            noteManager.Notes.Add(new NoteItemModel("2015-1-2", "今天天气很好"));
            noteManager.Notes.Add(new NoteItemModel("2015-1-2", "今天天气很好"));
            noteManager.Notes.Add(new NoteItemModel("2015-1-2", "今天天气很好"));
            noteManager.Notes.Add(new NoteItemModel("2015-1-2", "今天天气很好"));
            noteManager.Notes.Add(new NoteItemModel("2015-1-2", "今天天气很好"));
            noteManager.Notes.Add(new NoteItemModel("2015-1-2", "今天天气很好"));

            this.DataContext = noteManager;
        }
    }
}

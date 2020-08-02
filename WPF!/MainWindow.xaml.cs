using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window 
    {
        public ObservableCollection<Task> Tasks { get; set; }
        private int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<Task>();
            this.GoalList.ItemsSource = Tasks;
        }

        private string GetTaskText(string baseContent)
        {
            EditorWindow editor = new EditorWindow(baseContent);
            editor.Owner = this;
            if (editor.ShowDialog() == true)
            {
                return editor.editonText.Text;
            }
            return baseContent;
        }
        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var content = GetTaskText("");
            Tasks.Add(new Task { Content = $"{content}" });
        }

        public void ButtonEraser_Click(object sender, RoutedEventArgs e)
        {
            var Button_sender = (Button)sender;
            var Grid_sender = (Grid)Button_sender.Parent;
            var ContentPresenter_sender = (ContentPresenter)Grid_sender.TemplatedParent;
            var Border_sender = (Border)ContentPresenter_sender.Parent;
            var ListViewItem_sender = (ListViewItem)(Border_sender.TemplatedParent);
            var WPF_Task_sender = (WPF_.Task)ListViewItem_sender.DataContext;
            Tasks.Remove(WPF_Task_sender);
        }

        public void ButtonEditor_Click(object sender, RoutedEventArgs e)
        {
            var Button_sender = (Button)sender;
            var Grid_sender = (Grid)Button_sender.Parent;
            var ContentPresenter_sender = (ContentPresenter)Grid_sender.TemplatedParent;
            var Border_sender = (Border)ContentPresenter_sender.Parent;
            var ListViewItem_sender = (ListViewItem)(Border_sender.TemplatedParent);
            var WPF_Task_sender = (WPF_.Task)ListViewItem_sender.DataContext;
            //EditorControl editorControl = new EditorControl(WPF_Task_sender.Content);
            //MainGrid.Children.Add(editorControl);

            int index = Tasks.IndexOf(WPF_Task_sender);
            Tasks[index] = new Task { Content = $"{GetTaskText(WPF_Task_sender.Content)}" };
        }
    }
}

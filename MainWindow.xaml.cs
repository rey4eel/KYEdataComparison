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
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using System.IO;


namespace KohYoungDataAnalizerDiff
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
		}


		private  void PerformInlineDiff()
		{
			
			string OldText = File.ReadAllText(@"C:\Users\vardan.saakian\Desktop\test\10142020211405AOI\AOIGUISetup - Copy.ini");
			string NewText = File.ReadAllText(@"C:\Users\vardan.saakian\Desktop\test\10142020211405AOI\AOIGUISetup.ini");

			var builder = InlineDiffBuilder.Diff(OldText, NewText);


			ListViewItem litF;

			if (builder.HasDifferences)
			{
				foreach (var line in builder.Lines)
				{
					switch (line.Type)
					{
						case ChangeType.Unchanged:
							litF = new ListViewItem();
							litF.Content = line.Text;
							this.list1.Items.Add(litF);
							break;
						case ChangeType.Deleted:
							litF = new ListViewItem();
							litF.Content = line.Text;
							litF.Background = Brushes.Red;
							this.list1.Items.Add(litF);
							//richTextBoxInline.AppendText(line.Text, Color.Red);
							break;
						case ChangeType.Inserted:
							litF = new ListViewItem();
							litF.Content = line.Text;
							litF.Background = Brushes.Blue;
							this.list1.Items.Add(litF);
							break;
						case ChangeType.Imaginary:
							litF = new ListViewItem();
							litF.Content = "";
							this.list1.Items.Add(litF);
							break;
						case ChangeType.Modified:
							litF = new ListViewItem();
							litF.Content = line.Text;
							litF.Background = Brushes.Green;
							this.list1.Items.Add(litF);
							break;
						default:
							litF = new ListViewItem();
							litF.Content = line.Text;
							litF.Background = Brushes.Purple;
							this.list1.Items.Add(litF);
							break;
					}
				}
				
			}

		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			PerformInlineDiff();

		}
    }
}

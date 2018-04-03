using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SerializationTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Methods m = new Methods();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSerializeElement_Click(object sender, RoutedEventArgs e)
        {
            m.SerializeElement(@"\\data.cv.local\Students\mort959c\Documents\Tilbage på aspit\SerializationTest\Save Files\SerializeElement.txt");
        }

        private void btnSerializeDataSet_Click(object sender, RoutedEventArgs e)
        {
            m.SerializeDataSet(@"\\data.cv.local\Students\mort959c\Documents\Tilbage på aspit\SerializationTest\Save Files\DataSet.txt");
        }
    }

    public class Methods
    {
        public void SerializeDataSet(string path)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(DataSet));

            // Creates a DataSet; adds a table, column, and ten rows.
            DataSet set = new DataSet("myDataSet");
            DataTable table = new DataTable("table1");
            DataColumn column = new DataColumn("thing");
            table.Columns.Add(column);
            set.Tables.Add(table);
            DataRow row;

            for (int i = 0; i < 10; i++)
            {
                row = table.NewRow();
                row[0] = "Thing " + i;
                table.Rows.Add(row);
            }

            TextWriter writer = new StreamWriter(path);
            xmlSer.Serialize(writer, set);
            writer.Close();
        }

        public void SerializeElement(string path)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(XElement));
            XElement element = new XElement("MyElement","ns");
            element.Value = "Hello World";
            TextWriter writer = new StreamWriter(path);
            xmlSer.Serialize(writer, element);
            writer.Close();
        }

        public void SerializeNode(string path)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(XNode));
            XNode node = new XElement("TEST", "Tekst");
            

        }
    }
}

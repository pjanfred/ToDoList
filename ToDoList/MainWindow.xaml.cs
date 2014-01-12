using System;
using System.Collections.Generic;
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
using System.Xml.Serialization;

namespace ToDoList
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Aufgabe> aufgaben = new List<Aufgabe>();
        public MainWindow()
        {
            InitializeComponent();

            // Daten laden
            List<Aufgabe> loadAufgaben = DeserializeObject();
            if (loadAufgaben != null)
            {
                aufgaben = loadAufgaben;
            }

            posGrid.ItemsSource = aufgaben;
        }

        // Objekt serialisieren
        public static void SerializeObject(object obj)
        {
            FileStream stream = new FileStream(@"D:\PersonData.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Aufgabe>));
            serializer.Serialize(stream, obj);
            stream.Close();
        }
        // Objekt deserialisieren
        public static List<Aufgabe> DeserializeObject()
        {
            try
            {
                FileStream stream = new FileStream(@"D:\PersonData.xml", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Aufgabe>));
                List<Aufgabe> newAufgaben = (List<Aufgabe>)serializer.Deserialize(stream);
                stream.Close();
                return newAufgaben;
            }
            catch
            {
                return null;
            }
        }

        private void DelOneDay(object sender, RoutedEventArgs e)
        {
            Aufgabe aufgabe = (Aufgabe) posGrid.SelectedItem;
            if (aufgabe != null) {
                aufgabe.faelligkeit = aufgabe.faelligkeit.Value.AddDays(-1);
            }
        }

        private void AddOneDay(object sender, RoutedEventArgs e)
        {
            Aufgabe aufgabe = (Aufgabe) posGrid.SelectedItem;
            if (aufgabe != null) {
                aufgabe.faelligkeit = aufgabe.faelligkeit.Value.AddDays(1);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SerializeObject(aufgaben);
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Futo> Futok { get; set; } = new ObservableCollection<Futo>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Beolvasas(@"futok.txt");
        }


        public void LegjobbFuto(object sender, RoutedEventArgs e)
        {
            List<Futo> Teljesitett = Futok.Where(x => x.Tav == 100).ToList();
            Futo Leggyors = Teljesitett.OrderBy(x => x.Ido).First();
            LeggyorsNev.Text = $"Név:  {Leggyors.Nev}";
            LeggyorsIdo.Text = $"Ideje:  {Leggyors.Ido} óra";
        }



        private Futo _kivalasztottFuto;
        public Futo KivalasztottFuto
        {
            get => _kivalasztottFuto;
            set
            {
                _kivalasztottFuto = value;
                OnPropertyChanged(nameof(KivalasztottFuto));
            }
        }


        public void Beolvasas(string fajlNeve)
        {
            string[] sorok = File.ReadAllLines(fajlNeve);

            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(';');

                Futok.Add(new Futo
                {
                    Nev = adatok[0],
                    Ido = double.Parse(adatok[1]),
                    Tav = int.Parse(adatok[2])
                });
            }
        }



    }
}
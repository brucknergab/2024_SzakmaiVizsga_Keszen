namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KonzolraIras konzolra = new KonzolraIras();
            JatekVezerlo jatekVezerlo = new JatekVezerlo(konzolra);

            string fajlNev = @"palya.txt";

            jatekVezerlo.Beolvasas(fajlNev);
            jatekVezerlo.JatekInditas();
        }
    }
}
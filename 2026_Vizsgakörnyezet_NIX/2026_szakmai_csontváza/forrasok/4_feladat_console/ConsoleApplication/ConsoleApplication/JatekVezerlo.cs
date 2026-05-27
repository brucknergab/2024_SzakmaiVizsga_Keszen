using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ConsoleApplication
{
    public class JatekVezerlo(KonzolraIras konzolraIras)
    {
        public bool MegyAjatek = true;
        public bool Nyertel = false;
        public int KijaratY { get; set; }
        public int KijaratX { get; set; }
        public string FileNev = @"palya.txt";
        public int Magassag {  get; set; }
        public int Szelesseg { get; set; }
        public char[,] Borton { get; set; }
        public Jatekos Or {  get; set; } = new Jatekos();
        public List<Rab> Rabok = new List<Rab>();
        public void Beolvasas(string fileNev)
        {
            string[] sorok = File.ReadAllLines(fileNev);
            Magassag = sorok.Length;
            Szelesseg = sorok[0].Length;
            Borton = new char[Magassag, Szelesseg];

            for (int y = 0; y < Magassag; y++)
            {
                for (int x = 0; x < Szelesseg; x++)
                {
                    Borton[y, x] = sorok[y][x];

                    if (Borton[y, x] == '*')
                    {
                        Rabok.Add(new Rab
                        {
                            Halott = false,
                            Y = y,
                            X = x,
                            LepesY = y,
                            LepesX = x
                        });
                    }

                    if (Borton[y, x] == 'T')
                    {
                        KijaratY = y;
                        KijaratX = x;
                    }
                    else if (Borton[y, x] == 'O')
                    {
                        Or.Halott = false;
                        Or.Y = y;
                        Or.X = x;
                        Or.KezdoY = y;
                        Or.KezdoX = x;
                        Or.LepesY = Or.Y;
                        Or.LepesX = Or.X;
                    }

                }
            }

        }


        public void JatekInditas()
        {
            while (MegyAjatek)
            {
                Console.Clear();
                Console.WriteLine($"------ Börtönlázadás Játék ------");
                Console.WriteLine($"Irányítás: WASD, Kilépés: Esc, Újrakezdés: R");
                Console.WriteLine($"Elfogott rabok: ({Rabok.Where(r => r.Halott == true).Count()}/{Rabok.Count()})");

                for (int y = 0; y < Magassag; y++)
                {
                    for (int x = 0; x < Szelesseg; x++)
                    {
                        Console.Write(Borton[y, x]);
                    }
                    Console.WriteLine();
                }


                ConsoleKeyInfo gomb = Console.ReadKey(true);

                switch (gomb.Key)
                {
                    case ConsoleKey.W: Or.LepesY--; break;
                    case ConsoleKey.S: Or.LepesY++; break;
                    case ConsoleKey.A: Or.LepesX--; break;
                    case ConsoleKey.D: Or.LepesX++; break;
                    case ConsoleKey.Escape: MegyAjatek = false; break;
                }

                if (Borton[Or.LepesY, Or.LepesX] != 'X')
                {
                    Borton[Or.LepesY, Or.LepesX] = 'O';
                    Borton[Or.Y, Or.X] = ' ';
                    Or.Y = Or.LepesY;
                    Or.X = Or.LepesX;
                }
                else
                {
                    Or.LepesY = Or.Y;
                    Or.LepesX = Or.X;
                }


                foreach (Rab rab in Rabok)
                {
                    Random rnd = new Random();
                    int sorsolas = rnd.Next(4);

                    switch (sorsolas)
                    {
                        case 1: rab.LepesY++; break;
                        case 2: rab.LepesY--; break;
                        case 3: rab.LepesX++; break;
                        case 0: rab.LepesX--; break;
                    }

                    if (Borton[rab.LepesY, rab.LepesX] == 'T')
                    {
                        MegyAjatek = false;
                        Nyertel = false;
                    }
                    else if(Borton[rab.LepesY, rab.LepesX] != 'X' && rab.Halott == false)
                    {
                        Borton[rab.LepesY, rab.LepesX] = '*';
                        Borton[rab.Y, rab.X] = ' ';
                        rab.Y = rab.LepesY;
                        rab.X = rab.LepesX;
                    }
                    else
                    {
                        rab.LepesY = rab.Y;
                        rab.LepesX = rab.X;
                    }



                    if (Or.Y == rab.Y && Or.X == rab.X)
                    {
                        rab.Halott = true;
                        Borton[rab.Y, rab.X] = ' ';
                    }

                }



                if (Rabok.Where(r => r.Halott == true).Count() == Rabok.Count())
                {
                    MegyAjatek = false;
                    Nyertel = true;
                }

            }

            Console.WriteLine();

            if (Nyertel == true)
            {
                Console.WriteLine("Gratulálok, nyertél!");
            }
            else
            {
                Console.WriteLine("Nem nyertél, egy rab megszökött.");
            }
            Thread.Sleep(2000);
            Console.ReadKey();
        }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Better_Vatera
{
    class Program
    {
        static void Main(string[] args)
        {
            Feltoltes();

            Console.ReadKey();
        }

        private static void Feltoltes()
        {
            List<Elado> eladoLista = new List<Elado>();
            List<Termek> termekLista = new List<Termek>();

            StreamReader srT = new StreamReader("Termekek.txt");
            while (!srT.EndOfStream)
            {
                string[] helper1 = srT.ReadLine().Split(',');
                Termek termek = new Termek(helper1[0], helper1[1], helper1[2], helper1[3]);
                termekLista.Add(termek);
            }
            srT.Close();

            StreamReader srE = new StreamReader("Eladok.txt");
            while (!srE.EndOfStream)
            {
                string[] helper2 = srE.ReadLine().Split(',');
                ertekeles asd = new ertekeles();
                switch (helper2[4])
                {
                    case "1":
                        asd = ertekeles.egy;
                        break;
                    case "2":
                        asd = ertekeles.ketto;
                        break;
                    case "3":
                        asd = ertekeles.harom;
                        break;
                    case "4":
                        asd = ertekeles.negy;
                        break;
                    case "5":
                        asd = ertekeles.ot;
                        break;
                }
                List<Termek> helperLista = new List<Termek>();
                for (int i = 0; i < termekLista.Count; i++)
                {
                    if (termekLista[i].Sorszam == helper2[0])
                    {
                        helperLista.Add(termekLista[i]);
                    }
                }
                Kapcsolat kapcsolat = new Kapcsolat(helper2[5], helper2[6], helper2[7], helper2[8]);
                Elado elado = new Elado();
                if (helper2[9] == "0")
                {
                    elado = new Maganszemely(helper2[1], int.Parse(helper2[2]), helper2[1], asd, helperLista, kapcsolat, helper2[10]);
                }
                else if (helper2[9] == "1")
                {
                    elado = new Jogiszemely(helper2[1], int.Parse(helper2[2]), helper2[3], asd, helperLista, kapcsolat, helper2[10]);
                }
                eladoLista.Add(elado);
            }
            srE.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Better_Vatera
{
    class Arukezelo
    {
        public BinarisKeresoFa<Termek, string> fa = new BinarisKeresoFa<Termek, string>();
        public List<Elado> eladoLista = new List<Elado>();
        public List<Termek> termekLista = new List<Termek>();
        public List<Maganszemely> maganszemelyLista = new List<Maganszemely>();
        public List<Jogiszemely> jogiszemelyLista = new List<Jogiszemely>();

        private void KeressEladoTermekeire()
        {
            Console.WriteLine("Melyik eladónak szeretnéd az összes áruját kilistázni: ");
            string eladoNeve = Console.ReadLine();
            termekLista.Clear();
            bool talalt = false;
            List<Termek> rendezett = new List<Termek>();
            foreach (var item in maganszemelyLista)
            {
                if (eladoNeve == item.Nev)
                {
                    termekLista = new List<Termek>(item.TermekLista);
                    talalt = true;
                }
            }
            foreach (var item in jogiszemelyLista)
            {
                if (eladoNeve == item.CegNev)
                {
                    termekLista = new List<Termek>(item.TermekLista);
                    talalt = true;
                }
            }
            if (talalt == false)
            {
                throw new NincsIlyenEladoException("Nincs ilyen eladó");
            }
            else
            {
                for (int j = 0; j < termekLista.Count; j++)
                {
                    rendezett = Rendezes(termekLista);
                }
                foreach (Termek item in rendezett)
                {
                    item.Kiir();
                }
            }
        }

        private List<Termek> Rendezes(List<Termek> termeklista)
        {
            List<Termek> rendezett = new List<Termek>();

            for (int i = 0; i < termeklista.Count; i++)
            {
                if (i + 1 != termekLista.Count)
                {
                    rendezett.Add(new Termek());
                    rendezett.Add(new Termek());
                    if (termeklista[i].Nev.CompareTo(termeklista[i + 1].Nev) < 0 || termeklista[i].Nev.CompareTo(termeklista[i + 1].Nev) == 0)
                    {
                        rendezett[i] = termeklista[i];
                        rendezett[i + 1] = termeklista[i + 1];
                    }
                    else if (termeklista[i].Nev.CompareTo(termeklista[i + 1].Nev) > 0)
                    {
                        rendezett[i] = termeklista[i + 1];
                        rendezett[i + 1] = termeklista[i];
                    }
                }
            }
            for (int i = 0; i < rendezett.Count; i++)
            {
                if (rendezett[i].Nev == null)
                {
                    rendezett.RemoveAt(i);
                }
            }
            return rendezett;
        }

        public void KeresesAkare()
        {
            Console.WriteLine("Akarsz keresni? {0 - nem} {1 - igen, névre} {2 - igen, cikkszámra} {3 - Eladó neve alapján szeretnék termékeket kilistázni}");
            string keresse = Console.ReadLine();
            switch (keresse)
            {
                case "0":
                    break;
                case "1":
                    try
                    {
                        KeressNevre();
                    }
                    catch (NincsIlyenTermeknevException ex)
                    {
                        Console.WriteLine(ex.Message);
                        KeresesAkare();
                    }
                    break;
                case "2":
                    try
                    {
                        KeressCikkszamra();
                    }
                    catch (NincsIlyenCikkszamException ex)
                    {
                        Console.WriteLine(ex.Message);
                        KeresesAkare();
                    }
                    break;
                case "3":
                    try
                    {
                        KeressEladoTermekeire();
                    }
                    catch (NincsIlyenEladoException ex)
                    {
                        Console.WriteLine(ex.Message);
                        KeresesAkare();
                    }
                    break;
                default:
                    Console.WriteLine("Ebből a 4 számból válasszhatsz: {0} {1} {2} {3}");
                    KeresesAkare();
                    break;
            }
        }

        private void KeressCikkszamra()
        {
            Console.WriteLine("Írja be a keresett termék cikkszámát: ");
            string KTCikkszama = Console.ReadLine();
            try
            {
                Termek KTCN = fa.Kereses(KTCikkszama);
                KTCN.Kiir();
            }
            catch
            {
                throw new NincsIlyenCikkszamException("Nincs ilyen cikkszámmal felvett termék a listában!");
            }
        }

        private void KeressNevre()
        {
            Console.WriteLine("Írja be a keresett termék nevét: ");
            string KTNeve = Console.ReadLine();
                string KTNevenekCikkszama = null;
                bool nincs = true;
                foreach (var item in fa)
                {
                    if (item.Nev == KTNeve)
                    {
                        nincs = false;
                        KTNevenekCikkszama = item.Cikkszam;
                        Termek KTNC = fa.Kereses(KTNevenekCikkszama);
                        KTNC.Kiir();
                    }
                }
                if (nincs)
                {
                    throw new NincsIlyenTermeknevException("Nincs ilyen névvel felvett termék a listában!");
                }
        }

        public void Feltoltes()
        {
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
                ertekeles ertekeles = new ertekeles();
                switch (helper2[4])
                {
                    case "1":
                        ertekeles = ertekeles.egy;
                        break;
                    case "2":
                        ertekeles = ertekeles.ketto;
                        break;
                    case "3":
                        ertekeles = ertekeles.harom;
                        break;
                    case "4":
                        ertekeles = ertekeles.negy;
                        break;
                    case "5":
                        ertekeles = ertekeles.ot;
                        break;
                }
                List<Termek> helperLista = new List<Termek>();
                foreach (Termek item in termekLista)
                {
                    if (item.Sorszam == helper2[0])
                    {
                        helperLista.Add(item);
                    }
                }
                Kapcsolat kapcsolat = new Kapcsolat(helper2[5], helper2[6], helper2[7], helper2[8]);
                Elado elado = new Elado();
                if (helper2[9] == "0")
                {
                    elado = new Maganszemely(helper2[1], int.Parse(helper2[2]), helper2[1], ertekeles, helperLista, kapcsolat, helper2[10]);
                    Listainit(helperLista, elado);
                    maganszemelyLista.Add(elado as Maganszemely);
                }
                else if (helper2[9] == "1")
                {
                    elado = new Jogiszemely(helper2[1], int.Parse(helper2[2]), helper2[3], ertekeles, helperLista, kapcsolat, helper2[10]);
                    Listainit(helperLista, elado);
                    jogiszemelyLista.Add(elado as Jogiszemely);
                }
                eladoLista.Add(elado);
            }
            try
            {
                KeresoFabaKerul(fa, termekLista);
            }
            catch (NincsIlyenEladoException ex)
            {
                Console.WriteLine(ex);
            }

            srE.Close();
        }

        private void Listainit(List<Termek> termek, Elado elado)
        {
            foreach (Termek item in termek)
            {
                item.arusito = elado;
            }
        }

        private void KeresoFabaKerul(BinarisKeresoFa<Termek, string> fa, List<Termek> termek)
        {
            foreach (Termek item in termek)
            {
                if (item.arusito == null)
                {
                    throw new NincsIlyenEladoException("Ehhez a termékhez nem tartozik eladó az eladó listában!");
                }
                fa.Beszuras(item, item.Cikkszam);
            }
        }
    }
}

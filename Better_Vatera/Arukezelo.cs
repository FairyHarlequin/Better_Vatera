using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Better_Vatera
{
    class Arukezelo
    {
        int _arLimit;
        int _nemek = 0;

        public Arukezelo(int arLimit)
        {
            this._arLimit = arLimit;
        }

        public BinarisKeresoFa<Termek, string> fa = new BinarisKeresoFa<Termek, string>();
        public LancoltLista<Elado> eladoLista = new LancoltLista<Elado>();
        public LancoltLista<Termek> termekLista = new LancoltLista<Termek>();
        public LancoltLista<Maganszemely> maganszemelyLista = new LancoltLista<Maganszemely>();
        public LancoltLista<Jogiszemely> jogiszemelyLista = new LancoltLista<Jogiszemely>();
        public LancoltLista<Termek> ingyenes = new LancoltLista<Termek>();
        public Termek[] ingyensFelhasznalo;

        public void Modok()
        {
            foreach (ListaElem<Elado> item in eladoLista)
            {

                if (item.Tartalom.Fizetos == "ingyenes")
                {

                    ingyensFelhasznalo = new Termek[item.Tartalom.TermekLista.count];
                    int index = 0;

                    foreach (ListaElem<Termek> item1 in item.Tartalom.TermekLista)
                    {
                        ingyensFelhasznalo[index] = item1.Tartalom;
                        index++;
                    }

                    for (int i = ingyensFelhasznalo.Length-1; i > 0; i--)
                    {
                        int max = i;

                        for (int j = 0; j <= i; j++)
                        {

                            if (ingyensFelhasznalo[j].Ar < ingyensFelhasznalo[max].Ar)
                            {
                                max = j;
                            }
                            else if (ingyensFelhasznalo[j].Ar == ingyensFelhasznalo[max].Ar)
                            {
                                if (int.Parse(ingyensFelhasznalo[j].HanyszorVasaroltakMeg) < int.Parse(ingyensFelhasznalo[max].HanyszorVasaroltakMeg))
                                {
                                    max = j;
                                }
                            }

                            Termek maxtermek = ingyensFelhasznalo[i];
                            ingyensFelhasznalo[i] = ingyensFelhasznalo[max];
                            ingyensFelhasznalo[max] = maxtermek;
                        }
                    }

                    item.Tartalom.TermekLista.ListaClear();
                    double sum = 0;

                    for (int k = 0; k < ingyensFelhasznalo.Length; k++)
                    {

                        if (sum + ingyensFelhasznalo[k].Ar <= _arLimit)
                        {
                            sum = sum + ingyensFelhasznalo[k].Ar;
                            item.Tartalom.TermekLista.Beszur(ingyensFelhasznalo[k]);
                        }
                    }
                }
            }
        }

        //public void Modok()
        //{
        //    for (int k = 0; k < eladoLista.count; k++)
        //    {
        //        if (eladoLista[k].Fizetos == "ingyenes")
        //        {

        //            for (int i = eladoLista[k].TermekLista.Count - 1; i > 0; i--)
        //            {

        //                int max = i;
        //                for (int j = 0; j <= i; j++)
        //                {

        //                    if (int.Parse(eladoLista[k].TermekLista[j].HanyszorVasaroltakMeg) < int.Parse(eladoLista[k].TermekLista[max].HanyszorVasaroltakMeg))
        //                    {
        //                        max = j;
        //                    }
        //                    Termek maxtermek = eladoLista[k].TermekLista[i];
        //                    eladoLista[k].TermekLista[i] = eladoLista[k].TermekLista[max];
        //                    eladoLista[k].TermekLista[max] = maxtermek;
        //                }
        //            }

        //            if (eladoLista[k].TermekLista.Count > _maxDarabTemek)
        //            {
        //                eladoLista[k].TermekLista.RemoveRange(_maxDarabTemek, eladoLista[k].TermekLista.Count - _maxDarabTemek);
        //            }
        //        }
        //    }
        //}

        private void _KeressEladoTermekeire()
        {
            Console.WriteLine("Melyik eladónak szeretnéd az összes áruját kilistázni: ");
            string eladoNeve = Console.ReadLine();
            termekLista.ListaClear();
            bool talalt = false;
            LancoltLista<Termek> rendezett = new LancoltLista<Termek>();
           
            foreach (ListaElem<Maganszemely> item in maganszemelyLista)
            {
               
                if (eladoNeve == item.Tartalom.Nev)
                {
                    termekLista = item.Tartalom.TermekLista;
                    talalt = true;
                }
            }
           
            foreach (ListaElem<Jogiszemely> item in jogiszemelyLista)
            {
               
                if (eladoNeve == item.Tartalom.CegNev)
                {
                    termekLista = item.Tartalom.TermekLista;
                    talalt = true;
                }
            }
           
            if (talalt == false)
            {
                throw new NincsIlyenEladoException("Nincs ilyen eladó");
            }
            else
            {
               
                //for (int j = 0; j < termekLista.count; j++)
                //{
                //    rendezett = _Rendezes(termekLista);
                //}
               
                foreach (ListaElem<Termek> item in /*rendezett*/ termekLista)
                {
                    item.Tartalom.Kiir();
                }
            }
        }

        //private LancoltLista<Termek> _Rendezes(LancoltLista<Termek> termeklista)
        //{
        //    LancoltLista<Termek> rtn = termekLista;
           
        //    for (int i = 1; i < rtn.Count; i++)
        //    {
        //        Termek kulcs = termekLista[i];
        //        int j = i - 1;
               
        //        while (j>=0 && termekLista[j].Nev.CompareTo(kulcs.Nev) > 0)
        //        {
        //            rtn[j + 1] = rtn[j];
        //            j = j - 1;
        //        }
        //        rtn[j + 1] = kulcs;
        //    }
           
        //    return rtn;

        //}

        public void KeresesAkare()
        {
            Console.WriteLine("Válassz az alábbi menüpontok közül: \n{0 - nem} \n{1 - Termék nevére keresni} \n" + "{2 - Termék cikkszámára keresni} \n{3 - Eladó neve alapján termékeket kilistázni} \n{x - Kilépés a programból}");
            string keresse = Console.ReadLine();
            
            switch (keresse)
            {
                case "0":
                    _nemek++;
                   
                    if (_nemek >= 3)
                    {
                        Console.WriteLine("\nLégyszi válassz valamit, vagy lépj ki.\n");
                    }
                    break;
                case "1":
                    try
                    {
                        _KeressNevre();
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
                        _KeressCikkszamra();
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
                        _KeressEladoTermekeire();
                    }
                    catch (NincsIlyenEladoException ex)
                    {
                        Console.WriteLine(ex.Message);
                        KeresesAkare();
                    }
                    break;
                case "x":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ezek közül válasszhatsz: {0} {1} {2} {3} {x}");
                    KeresesAkare();
                    break;
            }

            KeresesAkare();
        }

        private void _KeressCikkszamra()
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

        private void _KeressNevre()
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
                Termek termek = new Termek(helper1[0], helper1[1], helper1[2], double.Parse(helper1[3]), helper1[4]);
                termekLista.Beszur(termek);
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

                LancoltLista<Termek> helperLista = new LancoltLista<Termek>();
                
                foreach (ListaElem<Termek> item in termekLista)
                {
                    
                    if (item.Tartalom.Sorszam == helper2[0])
                    {
                        helperLista.Beszur(item.Tartalom);
                    }
                }

                Kapcsolat kapcsolat = new Kapcsolat(helper2[5], helper2[6], helper2[7], helper2[8]);
                Elado elado = new Elado();
               
                if (helper2[9] == "0")
                {
                    elado = new Maganszemely(helper2[1], int.Parse(helper2[2]), helper2[1], ertekeles, helperLista, kapcsolat, helper2[10]);
                    _Listainit(helperLista, elado);
                    maganszemelyLista.Beszur(elado as Maganszemely);
                }
                else if (helper2[9] == "1")
                {
                    elado = new Jogiszemely(helper2[1], int.Parse(helper2[2]), helper2[3], ertekeles, helperLista, kapcsolat, helper2[10]);
                    _Listainit(helperLista, elado);
                    jogiszemelyLista.Beszur(elado as Jogiszemely);
                }

                eladoLista.Beszur(elado);
            }
            try
            {
                _KeresoFabaKerul(fa, termekLista);
            }
            catch (NincsIlyenEladoException ex)
            {
                Console.WriteLine(ex);
            }

            srE.Close();
        }

        private void _Listainit(LancoltLista<Termek> termek, Elado elado)
        {
            foreach (ListaElem<Termek> item in termek)
            {
                item.Tartalom.arusito = elado;
            }
        }

        private void _KeresoFabaKerul(BinarisKeresoFa<Termek, string> fa, LancoltLista<Termek> termek)
        {
            foreach (ListaElem<Termek> item in termek)
            {
               
                if (item.Tartalom.arusito == null)
                {
                    throw new NincsIlyenEladoException("Ehhez a termékhez nem tartozik eladó az eladó listában!");
                }

                fa.Beszuras(item.Tartalom, item.Tartalom.Cikkszam);
            }
        }
    }
}

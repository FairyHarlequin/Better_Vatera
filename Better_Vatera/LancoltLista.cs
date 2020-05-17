using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class ListaElem<T> 
    {
        public T Tartalom { get; set; }
        public ListaElem<T> Kovetkezo { get; set; }
    }
    class LancoltLista<T> : IEnumerable, IEnumerator where T : class, IComparable<T>
    {
        private ListaElem<T> fej;

        private ListaElem<T> _current;

        public int count;

        //IEnumerator
        public object Current
        {
            get
            {
                return _current;
            }
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = fej;
                return true;
            }
            else if (_current.Kovetkezo != null)
            {
                _current = _current.Kovetkezo;
                return true;
            }
            else
            {
                this.Reset();
                return false;
            }
        }

        public void Reset()
        {
            _current = null;
        }

        //IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this as IEnumerator;
        }

        //Feladatok
        public void Beszur(T tartalom)
        {
            ListaElem<T> uj = new ListaElem<T>();
            uj.Tartalom = tartalom;
            
            if (fej == null)
            {
                uj.Kovetkezo = null;
                fej = uj;
            }
            else
            {
                
                if (fej.Tartalom.CompareTo(tartalom) > 0)
                {
                    uj.Kovetkezo = fej;
                    fej = uj;
                }
                else
                {
                    ListaElem<T> p = fej;
                    ListaElem<T> e = new ListaElem<T>();
                   
                    while (p != null && p.Tartalom.CompareTo(tartalom) < 0)
                    {
                        e = p;
                        p = p.Kovetkezo;
                    }
                    if (p == null)
                    {
                        uj.Kovetkezo = null;
                        e.Kovetkezo = uj;
                    }
                    else
                    {
                        uj.Kovetkezo = p;
                        e.Kovetkezo = uj;
                    }
                }
            }

            this.ListaCount();
        }

        public T TartalomAlapjanKeres(T tartalom)
        {
            T vissza = default(T);
            bool megtalalta = false;
            
            while (this.MoveNext() != false && megtalalta == false)
            {
                if (this._current.Tartalom.Equals(tartalom))
                {
                    vissza = this._current.Tartalom;
                    megtalalta = true;
                }
            }

            return vissza;
        }

        public void TartalomAlapjanTorol(T tartalom)
        {
            ListaElem<T> e = null;
            ListaElem<T> p = fej;

            while (p != null && !p.Tartalom.Equals(tartalom))
            {
                e = p;
                p = p.Kovetkezo;
            }

            if (p != null)
            {
                //torles
                if (e == null)
                {
                    //elso elemet kell torolni
                    fej = p.Kovetkezo;
                }
                else
                {
                    //valahanzadik elemet kell torolni
                    e.Kovetkezo = p.Kovetkezo;
                }
            }
            else
            {
                //kivetel
                throw new NincsIlyenElemException("Nincs ilyen elem a lancolt listaban");
            }
        }

        public void ListaCount()
        {
            ListaElem<T> p = fej;
            count = 0;

            while (p != null)
            {
                count++;
                p = p.Kovetkezo;
            }
        }

        public void ListaClear()
        {
            ListaElem<T> p;

            while (fej != null)
            {
                p = fej;
                fej = fej.Kovetkezo;
                p = null;
            }
        }
    }
}

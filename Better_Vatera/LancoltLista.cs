using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class LancoltLista<T, K> : IEnumerable, IEnumerator where K : IComparable where T : IComparable
    {
        class ListaElem
        {
            public T Tartalom { get; set; }
            public K Kulcs { get; set; }
            public ListaElem Kovetkezo { get; set; }
        }

        private ListaElem fej;

        private ListaElem _current;

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

        //Rendezett beszúrás
        public void Beszur(T tartalom, K kulcs)
        {
            ListaElem uj = new ListaElem();
            uj.Kulcs = kulcs;
            uj.Tartalom = tartalom;
            if (fej == null)
            {
                uj.Kovetkezo = null;
                fej = uj;
            }
            else
            {
                if (fej.Kulcs.CompareTo(kulcs) > 0)
                {
                    uj.Kovetkezo = fej;
                    fej = uj;
                }
                else
                {
                    ListaElem p = fej;
                    ListaElem e = null;
                    while (p != null && p.Kulcs.CompareTo(kulcs) < 0)
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
        }
        // Kulcs alapján keres T-t
        public T KulcsAlapjanKeres(K kulcs)
        {
            T vissza = default(T);
            bool megtalalta = false;
            while (this.MoveNext() != false && megtalalta == false)
            {
                if (this._current.Kulcs.Equals(kulcs))
                {
                    vissza = this._current.Tartalom;
                    megtalalta = true;
                }
            }
            return vissza;
        }
        // Tartalom alapján keress K-t
        public K TartalomAlapjanKeres(T tartalom)
        {
            K vissza = default(K);
            bool megtalalta = false;
            while (this.MoveNext() != false && megtalalta == false)
            {
                if (this._current.Tartalom.Equals(tartalom))
                {
                    vissza = this._current.Kulcs;
                    megtalalta = true;
                }
            }
            return vissza;
        }
    }
}

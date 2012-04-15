using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Aprendiendo.luminary.comun
{
    public class Letra
    {
        private static Hashtable hashSenas;
        private String _caracter;

        /// <summary>
        /// 
        /// </summary>
        public String caracterSena {
            get {
                Object cO = hashSenas[Convert.ToInt32(_caracter.ToCharArray()[0])];
                String c = cO+"";
                return c; 
            }
        }

        public String caracter {
            get {
                return _caracter;
            }
            set {
                _caracter = value;
            }
        }

        public Letra() {
            hashSenas = new Hashtable();
            hashSenas.Add(Convert.ToInt32('a'), "assets/a.gif");
            hashSenas.Add(Convert.ToInt32('b'), "assets/b.gif");
            hashSenas.Add(Convert.ToInt32('c'), "assets/c.gif");
            hashSenas.Add(Convert.ToInt32('d'), "assets/d.gif");
            hashSenas.Add(Convert.ToInt32('e'), "assets/e.gif");
            hashSenas.Add(Convert.ToInt32('f'), "assets/f.gif");
            hashSenas.Add(Convert.ToInt32('g'), "assets/g.gif");
            hashSenas.Add(Convert.ToInt32('h'), "assets/h.gif");
            hashSenas.Add(Convert.ToInt32('i'), "assets/i.gif");
            hashSenas.Add(Convert.ToInt32('j'), "assets/j.gif");
            hashSenas.Add(Convert.ToInt32('k'), "assets/k.gif");
            hashSenas.Add(Convert.ToInt32('l'), "assets/l.gif");
            hashSenas.Add(Convert.ToInt32('m'), "assets/m.gif");
            hashSenas.Add(Convert.ToInt32('n'), "assets/n.gif");
            hashSenas.Add(Convert.ToInt32('o'), "assets/o.gif");
            hashSenas.Add(Convert.ToInt32('p'), "assets/p.gif");
            hashSenas.Add(Convert.ToInt32('q'), "assets/q.gif");
            hashSenas.Add(Convert.ToInt32('r'), "assets/r.gif");
            hashSenas.Add(Convert.ToInt32('s'), "assets/s.gif");
            hashSenas.Add(Convert.ToInt32('t'), "assets/t.gif");
            hashSenas.Add(Convert.ToInt32('u'), "assets/u.gif");
            hashSenas.Add(Convert.ToInt32('v'), "assets/v.gif");
            hashSenas.Add(Convert.ToInt32('w'), "assets/w.gif");
            hashSenas.Add(Convert.ToInt32('x'), "assets/x.gif");
            hashSenas.Add(Convert.ToInt32('y'), "assets/y.gif");
            hashSenas.Add(Convert.ToInt32('z'), "assets/z.gif");

            hashSenas.Add(Convert.ToInt32('A'), "assets/a.gif");
            hashSenas.Add(Convert.ToInt32('B'), "assets/b.gif");
            hashSenas.Add(Convert.ToInt32('C'), "assets/c.gif");
            hashSenas.Add(Convert.ToInt32('D'), "assets/d.gif");
            hashSenas.Add(Convert.ToInt32('E'), "assets/e.gif");
            hashSenas.Add(Convert.ToInt32('F'), "assets/f.gif");
            hashSenas.Add(Convert.ToInt32('G'), "assets/g.gif");
            hashSenas.Add(Convert.ToInt32('H'), "assets/h.gif");
            hashSenas.Add(Convert.ToInt32('I'), "assets/i.gif");
            hashSenas.Add(Convert.ToInt32('J'), "assets/j.gif");
            hashSenas.Add(Convert.ToInt32('K'), "assets/k.gif");
            hashSenas.Add(Convert.ToInt32('L'), "assets/l.gif");
            hashSenas.Add(Convert.ToInt32('M'), "assets/m.gif");
            hashSenas.Add(Convert.ToInt32('N'), "assets/n.gif");
            hashSenas.Add(Convert.ToInt32('O'), "assets/o.gif");
            hashSenas.Add(Convert.ToInt32('P'), "assets/p.gif");
            hashSenas.Add(Convert.ToInt32('Q'), "assets/q.gif");
            hashSenas.Add(Convert.ToInt32('R'), "assets/r.gif");
            hashSenas.Add(Convert.ToInt32('S'), "assets/s.gif");
            hashSenas.Add(Convert.ToInt32('T'), "assets/t.gif");
            hashSenas.Add(Convert.ToInt32('U'), "assets/u.gif");
            hashSenas.Add(Convert.ToInt32('V'), "assets/v.gif");
            hashSenas.Add(Convert.ToInt32('W'), "assets/w.gif");
            hashSenas.Add(Convert.ToInt32('X'), "assets/x.gif");
            hashSenas.Add(Convert.ToInt32('Y'), "assets/y.gif");
            hashSenas.Add(Convert.ToInt32('Z'), "assets/z.gif");
        }

    }
}

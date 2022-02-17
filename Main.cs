using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ultrabalaton
{
    class Main
    {
        private List<Versenyzo> versenyzok = new List<Versenyzo>();
        public void Fill()
        {
            foreach (var item in File.ReadAllLines("ub2017egyeni.txt").Skip(1))
            {
                versenyzok.Add(new Versenyzo(item));
            }
        }
        public int VersenyzoCount
        {
            get
            {
                return versenyzok.Count();
            }
        }
        public Versenyzo Keres(object sender, RoutedEventArgs e, TextBox tb)
        {
            Versenyzo v = versenyzok[0];
            foreach (var item in versenyzok.Where(r=> r.Nev == tb.Text || tb.Text == v.Nev))
            {
                return item;
            }
            return null;

        }
        public void Category(ComboBox cb)
        {
            HashSet<string> kat = new HashSet<string>();
            foreach (var item in versenyzok)
            {
                kat.Add(item.Kategoria);
            }
            cb.ItemsSource = kat;
        }
        private List<Versenyzo> v = new List<Versenyzo>();
        public void KategoriaVersenyzo(ListBox lb, ComboBox cb)
        {
            v.Clear();
            foreach (var item in versenyzok.Where(r=> r.Kategoria == (string)cb.SelectedItem))
            {
                v.Add(item);
            }
            lb.ItemsSource = v.Select(s => s.Nev);

        }
        public int CelbaErt()
        {

            return v.Where(r => r.Tav == 100).Count(); ;
        }
        public Versenyzo KatGyoztes(ComboBox cb)
        {
            Versenyzo vr = versenyzok[0];
            foreach (var item in versenyzok.Where(r=> r.Tav == 100 && r.idoTS < vr.idoTS && r.Kategoria == (string)cb.SelectedItem))
            {
                vr = item;
            }


            return vr;
        }
        public int Save()
        {
            List<string> toF = new List<string>();
            foreach (var item in v.Where(r=> r.Tav == 100).OrderBy(o=> o.idoTS))
            {
                toF.Add($"{item.Nev};{item.Ido}");
            }
            File.WriteAllLines($"{v[0].Kategoria}.txt", toF);
            return 1;
        }
    }
}

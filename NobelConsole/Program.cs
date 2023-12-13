using NobelConsole.Data;
using NobelConsole.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NobelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AdatContext db = new AdatContext();



            



            if (!db.Tipusok.Any())
            {
                string[] sorok = File.ReadAllLines(@"C:\Users\Attila\Desktop\Nobel\Fajtak.txt");
                foreach (var sor in sorok)
                {
                    db.Tipusok.Add(new Fajta(sor));
                }
                db.SaveChanges();            
            } 
            
            if (!db.Nobel.Any())
            {
                string[] sorok2 = File.ReadAllLines(@"C:\Users\Attila\Desktop\Nobel\nobel.csv");
                var sorok = sorok2.Skip(1);
                foreach (var sor in sorok)
                {
                    string[] tombSzoveg = sor.Split(";");
                    Fajta Tipus = db.Tipusok.Where(x=>x.Tipus==tombSzoveg[1]).FirstOrDefault();  
                    db.Nobel.Add(new Adat(Convert.ToInt32(tombSzoveg[0]), Tipus, tombSzoveg[2], tombSzoveg[3]));
                }
                db.SaveChanges();            
            }
            //foreach (var item in db.Nobel)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine("3");
            var arthur = db.Nobel.Where(x => x.KeresztNev == "Arthur B." && x.VezetekNev == "McDonald").Select(x => x.Tipus).FirstOrDefault();
            if (arthur is not null)
            {
                Console.WriteLine($"{arthur}");
            }
            else {
                Console.WriteLine("Nem kapott!");
            }

            Console.WriteLine("4");
            var ki2017 = db.Nobel.Where(x => x.Ev==2017 && x.Tipus.Tipus=="Irodalmi").Select(x => new { x.KeresztNev, x.VezetekNev }).FirstOrDefault();
            Console.WriteLine(ki2017.KeresztNev+" "+ki2017.VezetekNev);
            
            Console.WriteLine();
            Console.WriteLine("5");
            var szerv = db.Nobel.Where(x => x.VezetekNev == "");
            foreach (var item in szerv)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine();
            Console.WriteLine("\n6");
            var curie = db.Nobel.Where(x => x.VezetekNev.Contains("Curie")).OrderByDescending(x=>x.Ev);
            foreach (var item in curie)
            {
                Console.WriteLine("\t"+item);
            }
            Console.WriteLine("\n7");

            var darab = db.Nobel.GroupBy(x => x.Tipus.Tipus).Select(y => new { Tipus = y.Key, db = y.Count() });

            foreach (var item in darab)
            {
                Console.WriteLine(string.Format("{0,15} {1,20}", item.Tipus, item.db+" db"));
                //Console.WriteLine("\t"+{ item.Tipus,40} + "\t\t"+item.db+" db");
            }
            Console.WriteLine("9");

            var orv = db.Nobel.Where(x => x.Tipus.Tipus == "orvosi").OrderBy(x => x.Ev).Select(x => new { x.Ev, x.KeresztNev, x.VezetekNev });
            List<string> lista = new List<string>();

            foreach (var item in orv)
            {
                lista.Add(item.Ev + ":" + item.KeresztNev + " " + item.VezetekNev);
                //Console.WriteLine(item.Ev+":"+item.KeresztNev+" "+item.VezetekNev);
            }
            File.WriteAllLines(@"C:\Users\Attila\Desktop\Nobel\orvosi.txt", lista);

            List<string> tipusok = db.Nobel.GroupBy(x => x.Tipus.Tipus).Select(y=>y.Key).ToList();
            foreach (var item in tipusok)
            {
                Console.WriteLine(item);
            }
            //File.WriteAllLines(@"C:\Users\Attila\Desktop\Nobel\Fajtak.txt", tipusok);

            DateTime datum = new DateTime();
            datum = Convert.ToDateTime("2012.12.12");
            Console.WriteLine(datum);
        }
    }
}

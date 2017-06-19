using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSpike
{
    class Program
    {
        static void Main(string[] args)
        {

            //Do();
            
            Do_Two();

            //Do_Three();

            Console.WriteLine("Main");
            Console.ReadLine();
        }


        static async Task Do()
        {
            var repo = new Repository();

            var personen = repo.Load_Personen();
            var adressen = repo.Load_Adressen();

            Console.WriteLine("Do");

            foreach (var person in await personen)
                Console.WriteLine($"Vorname: {person.Vorname}, Nachname: {person.Nachname}");

            foreach(var adresse in await adressen)
                Console.WriteLine($"Straße: {adresse.Strasse}, Hausnummer: {adresse.Hausnummer}");

            Console.WriteLine();
        }

        static async Task Do_Two()
        {
            var repo = new Repository();

            var person = await repo.Get_by_Id(1);

            Console.WriteLine("Do Two");

            //foreach (var person in person_adress)
            Console.WriteLine($"Vorname: {person.Vorname}, Nachname: {person.Nachname}, ");
                                  //$"Straße: {person.Strasse}, Hausnummer: {person.Hausnummer}");

            Console.WriteLine();

        }

        static async Task Do_Three()
        {
            var repo = new Repository();

            var persons = await repo.Get_by_Straße("Fakestreet");

            Console.WriteLine("Do Three");

            foreach (var person in persons)
                Console.WriteLine($"Vorname: {person.Vorname}, Nachname: {person.Nachname}");

            Console.WriteLine();
        }
    }
}

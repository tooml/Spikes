using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSpike
{
    public class Repository
    {
        private IEnumerable<Person> _personen;
        private IEnumerable<Adresse> _adressen;

        public Repository()
        {
            //using (var db = new PersonenDb())
            //{
            //    var adresse_1 = new Adresse() { Id = 1, Strasse = "Rosenstraße", Hausnummer = "17" };
            //    var adresse_2 = new Adresse() { Id = 2, Strasse = "Fakestreet", Hausnummer = "123" };
            //    var adresse_3 = new Adresse() { Id = 3, Strasse = "Nelkenstraße", Hausnummer = "33" };

            //    _adressen = new Adresse[] { adresse_1, adresse_2, adresse_3 };
            //    db.Adressen.Add(adresse_1);
            //    db.Adressen.Add(adresse_2);
            //    db.Adressen.Add(adresse_3);

            //    var person_1 = new Person() { Id = 1, Vorname = "Thomas", Nachname = "Leidl", Adresse = adresse_1 };
            //    var person_2 = new Person() { Id = 2, Vorname = "Marge", Nachname = "Simpson", Adresse = adresse_2 };
            //    var person_3 = new Person() { Id = 3, Vorname = "Homer", Nachname = "Simpson", Adresse = adresse_2 };
            //    var person_4 = new Person() { Id = 4, Vorname = "Uwe", Nachname = "Albrecht", Adresse = adresse_3 };

            //    _personen = new Person[] { person_1, person_2, person_3, person_4 };
            //    db.Personen.Add(person_1);
            //    db.Personen.Add(person_2);
            //    db.Personen.Add(person_3);
            //    db.Personen.Add(person_4);

            //    db.SaveChanges();
            //}

        }

        public async Task<IEnumerable<Person>> Load_Personen()
        {
            return await Task.Run(() => {
                Thread.Sleep(3000);
                return _personen;
            });
            
        }

        public async Task<IEnumerable<Adresse>> Load_Adressen()
        {
            return await Task.Run(() => {
                Thread.Sleep(2000);
                return _adressen;
            });
        }

        public async Task<Person> Get_by_Id(int id)
        {
            return await Task.Run(() =>
            {
                //Thread.Sleep(5000);
                //return from person in _personen
                //        from adresse in _adressen 
                //        where person.Id == id && person.Adresse.Id == adresse.Id
                //        select new { person.Vorname, person.Nachname, adresse.Strasse, adresse.Hausnummer };

                using (var db = new PersonenDb())
                {
                    var person = db.Personen.Find(1);
                    return person;
                }
            });
        }

        public async Task<IEnumerable<Person>> Get_by_Straße(string straße)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                return _adressen.Where(adr => adr.Strasse.Equals(straße)).
                                Join(_personen, adr => adr.Id,
                                                pers => pers.Adresse.Id, (adr, pers) => pers);

            });
        }

        public IEnumerable<Person> Get_All()
        {
            using (var db = new PersonenDb())
            {
                var all = from pers in db.Personen
                          join add in db.Adressen on pers.Adresse.Id equals add.Id
                          group new { pers, add } by add into g
                          select new
                          {
                              a = g.Key.Strasse,
                              b = g

                            };

                var a = 1;
            }            
                              
            return new List<Person>();
        }
    }
}

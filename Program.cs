using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Program
    {
       public static string menu()
        {
            
                var fruit = AnsiConsole.Prompt(
   new SelectionPrompt<string>()
       .Title("[green]Witaj![/] co zamierzasz zrobić ?")
       .PageSize(10)
       .MoreChoicesText("[grey]()[/]")
       .AddChoices(new[] {
            "Dodaj", "Edytuj", "Usuń",
            "Wyświetl",
       }));
                return fruit.ToString();
            
        }
        static void Main(string[] args)
        {
          using (var db = new Model1Container())
                        {
            while(true)
                switch (menu())
                {
                    case "Dodaj":
                        
                            var tabela = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
               .Title("[blue]Co zamierzasz dodać?          [/]")
               .PageSize(12)
               .MoreChoicesText("[grey]()[/]")
               .AddChoices(new[] {
            "Adres Klienta","Adres Pracownika", "Dane Kontaktowe klienta","Dane Kontaktowe Pracownika", "Faktura",
            "Faktura produktu","Klient","Pracownik","Producent","Produkt","Zdjęcia","Kategoria","Kategoria produktu"
               }));
                            if (tabela == "Produkt")
                            {
                              
                                string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe produktu[/]?");
                                string opis = AnsiConsole.Ask<string>("Podaj [green]opis[/]?");
                                double cena_netto = AnsiConsole.Ask<double>("Podaj [green]cena netto[/]?");
                                double procent = AnsiConsole.Ask<double>("Podaj [green]procent vat[/]?");
                            int id_kategorii_produktu = AnsiConsole.Ask<int>("Podaj [green]id_kategorii_produktu[/]?");


                             int id_zdjecia = AnsiConsole.Ask<int>("Podaj [green]id_zdjecia [/]?");
                                var produkt = new Produkt()
                                    {
                                        nazwa = nazwa,
                                        opis = opis,
                                       
                                        cena_netto = cena_netto,
                                        Id_kategorii_produktu = id_kategorii_produktu,
                                        procent_vat = procent,
                                       
                                       
                                        Id_zdjecia = id_zdjecia
                                    };
                              
                              
                                try {db.ProduktSet.Add(produkt);
                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    
                                    if (e.Source != null) {
                                      
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]"); }
                                    Thread.Sleep(4000);
                                    
                                }
                               
                                Console.Clear();
                                

                            }
                            if (tabela == "Adres Klienta")
                            {
                                string miasto = AnsiConsole.Ask<string>("Podaj [green]miasto[/]?");
                                string powiat = AnsiConsole.Ask<string>("Podaj [green]powiat[/]?");
                                string ulica = AnsiConsole.Ask<string>("Podaj [green]ulica[/]?");
                                int numer_domu = AnsiConsole.Ask<int>("Podaj [green]numer domu[/]?");
                                int numer_lokalu = AnsiConsole.Ask<int>("What's your [green]numer_lokalu[/]?");
                                int id_klienta = AnsiConsole.Ask<int>("What's your [green]id klienta[/]?");


                                try
                                {

                                    var adres = new Adres
                                    {
                                        miasto = miasto,
                                        powiat = powiat,
                                        ulica = ulica,
                                        numer_lokalu = numer_lokalu,
                                        numer_domu = numer_domu,
                                        KlientId_klienta = id_klienta
                                         

                                        }; 
                                        
                                   
                                        db.AdresSet.Add(adres);
                                        db.SaveChanges();
                                    
                                           }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        Console.Clear();
                                        AnsiConsole.Markup("[green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                     
                                       // Thread.Sleep(4000);
                                    }
                                 }
                                Console.Clear();
                                 }

                            if (tabela == "Adres Pracownika")
                            {
                                string miasto = AnsiConsole.Ask<string>("Podaj [green]miasto[/]?");
                                string powiat = AnsiConsole.Ask<string>("Podaj [green]powiat[/]?");
                                string ulica = AnsiConsole.Ask<string>("Podaj [green]ulica[/]?");
                                int numer_domu = AnsiConsole.Ask<int>("Podaj [green]numer domu[/]?");
                                int numer_lokalu = AnsiConsole.Ask<int>("Podaj [green]numer_lokalu[/]?");
                                int id_klienta = AnsiConsole.Ask<int>("Podaj[green]id klienta[/]?");


                                try
                                {

                                    var adres = new Adres
                                    {
                                        miasto = miasto,
                                        powiat = powiat,
                                        ulica = ulica,
                                        numer_lokalu = numer_lokalu,
                                        numer_domu = numer_domu,
                                        PracownikId_pracownika1 = id_klienta

                                        // Klient.= Int32.Parse(id_klienta)

                                    };


                                    db.AdresSet.Add(adres);
                                    db.SaveChanges();

                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        Console.Clear();
                                        AnsiConsole.Markup("[green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                      
                                        // Thread.Sleep(4000);
                                    }
                                }
                                Console.Clear();
                            }

                            if (tabela == "Faktura")//działa
                            {
                                var id_klienta = AnsiConsole.Prompt(new TextPrompt<int>("Podaj[green]id klienta[/]?").AllowEmpty());
                                DateTime data = AnsiConsole.Ask<DateTime>("Podaj [green]date sprzedaży[/]?(W formie 05/06/2021)");
                                
                                double wartość_netto = AnsiConsole.Ask<double>("Podaj [green]wartośc netto[/]?");
                                double procent = AnsiConsole.Ask<double>("Podaj [green]wartość podatku" + "[/]?");
                                bool czy_dostawa = AnsiConsole.Ask<bool>("Czy była dostawa wpisz [green] true jeśli dostawa lub false, jeśli jej brak" + "[/]?");
                                //var k = db.Faktura_produktuSet.Find(7);
                                //var faktura2 = from b in db.Faktura_produktuSet
                                //               where b.Id_faktura_produktu == 7
                                //               select b;

                                var faktura = new Faktura
                                {
                                    Id_klienta = id_klienta,
                                    data_sprzedaży = data,
                                   
                                    wartość_netto = wartość_netto,
                                    procent_podatku = procent,
                                    czy_dostawa =czy_dostawa
                                };
                                try
                                {
                                    db.FakturaSet.Add(faktura);

                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    // Extract some information from this exception, and then
                                    // throw it to the parent method.
                                    if (e.Source != null)
                                    {
                                        Console.Clear();
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                        Thread.Sleep(4000);
                                    }
                                }
                                Console.Clear();

                            }
                            if (tabela == "Faktura produktu")
                            {
                                int id_produktu = AnsiConsole.Ask<int>("Podaj [green]id produktu[/]?");
                                int numer_faktury = AnsiConsole.Ask<int>("Podaj [green]numer faktury[/]?");



                                var faktura_produktu = new Faktura_produktu()
                                {
                                    Id_produktu = id_produktu,
                                    numer_faktury=numer_faktury,
                                    
                                   
                                  

                                };
                                try
                                {
                                    db.Faktura_produktuSet.Add(faktura_produktu);

                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    // Extract some information from this exception, and then
                                    // throw it to the parent method.
                                    if (e.Source != null)
                                    {
                                        Console.Clear();
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                        Thread.Sleep(4000);
                                    }
                                }
                                Console.Clear();
                                

                            }
                            if (tabela == "Kategoria")
                            {
                                string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe[/]?");



                                var faktura_produktu = new Kategoria()
                                {
                                    nazwa=nazwa



                                };
                                try
                                {
                                    db.KategoriaSet.Add(faktura_produktu);


                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    // Extract some information from this exception, and then
                                    // throw it to the parent method.
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                    }
                                    Thread.Sleep(4000);

                                }
                                Console.Clear();
                            }

                            if (tabela == "Kategoria produktu")
                            {
                                int id_producenta=AnsiConsole.Ask<int>("Podaj [green]id producenta[/]?");
                                int id_kategori= AnsiConsole.Ask<int>("Podaj [green]id kategorii[/]?");



                                var kategoria_produktu = new Kategoria_produktu()
                                {
                                    Id_kategorii=id_kategori,
                                    Id_producenta=id_kategori
                                    



                                };
                                try
                                {
                                    db.Kategoria_produktuSet.Add(kategoria_produktu);
                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    // Extract some information from this exception, and then
                                    // throw it to the parent method.
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                    }
                                    Thread.Sleep(4000);

                                }
                                Console.Clear();
                                
                            }
                            if (tabela == "Dane Kontaktowe klienta")
                            {
                                int id_klienta = AnsiConsole.Ask<int>("Podaj [green]id klienta[/]?");
                                int numer = AnsiConsole.Ask<int>("Podaj [green]numer[/]?");
                                string email=AnsiConsole.Ask<string>("Podaj [green]numer[/]?");

                                Klient dk;
                                dk = db.KlientSet.Where(k => k.Id_klienta == id_klienta).First();
                                var dane_Kontaktowe = new Dane_kontaktowe()
                                {
                                    Klient = dk,
                                    numer=numer,emial=email
                              };

                                try
                                {
                                    db.Dane_kontaktoweSet.Add(dane_Kontaktowe);

                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                   
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                    }
                                    Thread.Sleep(4000);

                                }
                                Console.Clear();
                            }
                            if (tabela == "Dane Kontaktowe Pracownika")
                            {
                                int id_pracownika = AnsiConsole.Ask<int>("Podaj [green]id pracownika[/]?");
                                int numer = AnsiConsole.Ask<int>("Podaj [green]numer[/]?");
                                string email = AnsiConsole.Ask<string>("Podaj [green]numer[/]?");
                                var query = from a in db.PracownikSet
                                            select a;
                               
                                Pracownik dk;
                               dk = db.PracownikSet.Where(k => k.Id_pracownika ==id_pracownika ).First();
                               
                                var Pracownik = new Pracownik();
                                var dane_Kontaktowe = new Dane_kontaktowe()
                                {
                                    
                                   Pracownik=dk,
                                    numer = numer,
                                    emial = email
                                };

                                try
                                {
                                    db.Dane_kontaktoweSet.Add(dane_Kontaktowe);
                                   
                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    // Extract some information from this exception, and then
                                    // throw it to the parent method.
                                    if (e.Source != null)
                                    { 
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                    }
                                    Thread.Sleep(4000);

                                }
                                Console.Clear();
                            }
                            if (tabela == "Pracownik")
                            {
                               string imie = AnsiConsole.Ask<string>("Podaj [green]imie[/]?");
                                string nazwisko = AnsiConsole.Ask<string>("Podaj [green]nazwisko[/]?");
                                
                                DateTime data = AnsiConsole.Ask<DateTime>("Podaj [green]date zatrudnie[/]?(W formie 05/06/2021)");

                              

                                var pracownik = new Pracownik()
                                {
                                    imie=imie,nazwisko=nazwisko,data_zatrunienia=data
                                
                                };
                                try
                                {
                                    db.PracownikSet.Add(pracownik);
                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                       
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                    }
                                    Thread.Sleep(4000);

                                }
                                Console.Clear();
                                
                            }
                            if (tabela == "Producent")
                            {
                                string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe[/]?");
                                var producent = new Producent()
                                {
                                    nazwa = nazwa

                                };
                                try
                                {
                                    db.ProducentSet.Add(producent); db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                   
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                    }
                                    Thread.Sleep(4000);

                                }


                                Console.Clear();
                            }
                            if (tabela == "Zdjęcia")
                            {
                                string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe[/]?");
                                DateTime localDate = DateTime.Now;

                                int id_produktu = AnsiConsole.Ask<int>("Podaj [green]id produktu[/]?");

                                var zdjęcia = new Zdjęcia()
                                {
                                    nazwa = nazwa,data=localDate,ProduktId_produktu=id_produktu

                                };
                                try
                                {
                                    db.ZdjęciaSet.Add(zdjęcia); db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                    }
                                    if (e== null)
                                    {
                                        AnsiConsole.Markup("[underline green]Udało się dodać do bazy. \nZa chwile wrócisz do menu [/]");

                                    }
                                    Thread.Sleep(4000);


                                }

                                Console.Clear();
                            }
                            if (tabela == "Klient")
                            {
                                string imie = AnsiConsole.Ask<string>("Podaj [green]imiee[/]?");
                                string nazwisko = AnsiConsole.Ask<string>("Podaj [green]nazwisko[/]?");
                               

                              

                                var klient = new Klient()
                                {
                                   imie=imie,nazwisko=nazwisko
                                };
                                try
                                {
                                    db.KlientSet.Add(klient); db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    
                                    if (e.Source != null)
                                    {
                                      
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                    }
                                    Thread.Sleep(4000);

                                }

                                Console.Clear();
                            }
                           
                            continue;

                        case "Wyświetl":
                            tabela = AnsiConsole.Prompt(
                               new SelectionPrompt<string>()
                                   .Title("[blue]Co zamierzasz wyświetlić?[/]")
                                   .PageSize(10)
                                   .MoreChoicesText("[grey]()[/]")
                                   .AddChoices(new[] {
                                   "Adres", "Dane Kontaktowe", "Faktura",
                                   "Faktura produktu","Kateguria","Kateguria produktu","Klient","Pracownik","Producent","Produkt","Zdjęcia"
                                   }));
                            if (tabela == "Adres")
                            {
                                var query = from a in db.AdresSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Miasto", "Powiat", "Ulica", "Numer domu", "Numer lokalu", "Id klienta");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_adresu), item.miasto, item.powiat, item.ulica, Convert.ToString(item.numer_domu), Convert.ToString(item.numer_lokalu),Convert.ToString(item.KlientId_klienta));

                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Dane Kontaktowe")
                            {
                                var query = from a in db.Dane_kontaktoweSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Numer telefonu", "Email");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_kontaktu), Convert.ToString(item.numer), item.emial);
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Faktura")
                            {
                                var query = from a in db.FakturaSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Numer faktury", "Id klienta", "Data sprzedaży", "Wartość netto", "Dostawa", "Procent podatku");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.numer_faktury), Convert.ToString(item.Id_klienta), Convert.ToString(item.data_sprzedaży), Convert.ToString(item.wartość_netto), Convert.ToString(item.czy_dostawa), Convert.ToString(item.procent_podatku));
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Faktura produktu")
                            {
                                var query = from a in db.Faktura_produktuSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Numer telefonu", "Email");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_faktura_produktu), Convert.ToString(item.Id_produktu), Convert.ToString(item.numer_faktury));
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Kategoria")
                            {
                                var query = from a in db.KategoriaSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Nazwa");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_kategorii), item.nazwa);
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Kategoria produktu")
                            {
                                var query = from a in db.Kategoria_produktuSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Id producenta", "Id kategorii");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_kategoria_produktu), Convert.ToString(item.Id_producenta), Convert.ToString(item.Id_kategorii));
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Klient")
                            {
                                var query = from a in db.KlientSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Id kontaktu", "Id_adresu", "Imię", "Nazwisko");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_klienta),  item.imie, item.nazwisko);
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Pracownik")
                            {
                                var query = from a in db.PracownikSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Imię", "Nazwisko", "Data zatrudnienia", "Id adresu");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_pracownika), item.imie, item.nazwisko, Convert.ToString(item.data_zatrunienia));
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Producent")
                            {
                                var query = from a in db.ProducentSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Nazwa");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_producenta), item.nazwa);
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Produkt")
                            {
                                var query = from a in db.ProduktSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Id kat prod", "Nazwa", "Opis", "Id zdjęcia", "Cena netto", "Procent vat", "Cena_brutto");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_produktu), Convert.ToString(item.Id_kategorii_produktu), item.nazwa, item.opis, Convert.ToString(item.Id_zdjecia), Convert.ToString(item.cena_netto), Convert.ToString(item.procent_vat));
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Zdjęcia")
                            {
                                var query = from a in db.ZdjęciaSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Nazwa", "Data", "Id produktu", "Produkt id produkt");
                                foreach (var item in query)
                                {
                                    table.AddRow(item.nazwa, Convert.ToString(item.data), Convert.ToString(item.ProduktId_produktu));
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }

                            break;

                        case "usuń":
                        Console.WriteLine("Failed measurement.");
                        break;
                    case "wyświetl":
                        Console.WriteLine("Failed measurement.");
                        break;

                    default:
                        Console.WriteLine("default");
                        break;
                }
            }
            
               
                }
            }
        }
    


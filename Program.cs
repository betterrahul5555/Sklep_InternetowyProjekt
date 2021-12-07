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
            "Adres", "Dane Kontaktowe", "Faktura",
            "Faktura produktu","Klient","Pracownik","Producent","Produkt","Zdjęcia","Kategoria","Kategoria produktu"
               }));
                            if (tabela == "Produkt")
                            {
                              
                                string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe produktu[/]?");
                                string opis = AnsiConsole.Ask<string>("Podaj [green]opis[/]?");
                                double cena_netto = AnsiConsole.Ask<double>("Podaj [green]cena netto[/]?");
                                double procent = AnsiConsole.Ask<double>("Podaj [green]procent vat[/]?");
                                double cena_brutto = AnsiConsole.Ask<double>("Podaj [green]cena brutto[/]?");
                               //= AnsiConsole.Ask<int>("Podaj [green]id_kategorii[/]?");
                                AnsiConsole.Markup("Podaj [green]id kategorii produktu[/]? ");
                                int id_kategorii_produktu = AnsiConsole.Ask<int>("Podaj [green]id_kategorii_produktu[/]?");


                                int id_faktura_produktu = AnsiConsole.Ask<int>("Podaj [green]id_faktura_produktu[/]?");


                                 int id_zdjecia = AnsiConsole.Ask<int>("Podaj [green]id_kategorii_produktu [/]?");




                                    var produkt = new Produkt()
                                    {
                                        nazwa = nazwa,
                                        opis = opis,
                                        cena_brutto = cena_brutto,
                                        cena_netto = cena_netto,
                                        Id_kategorii_produktu = id_kategorii_produktu,
                                        procent_vat = procent,
                                        Faktura_produktuId_faktura_produktu = id_faktura_produktu,
                                        Id_zdjecia = id_zdjecia
                                    };
                                
                                try {db.ProduktSet.Add(produkt);
                                    db.SaveChanges();
                                }
                                catch (Exception e)
                                {
                                    // Extract some information from this exception, and then
                                    // throw it to the parent method.
                                    if (e.Source != null) {
                                        AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]"); }
                                    Thread.Sleep(4000);
                                    
                                }
                               
                                Console.Clear();
                                

                            }
                            if (tabela == "Adres")//działa
                            {
                                string miasto = AnsiConsole.Ask<string>("Podaj [green]miasto[/]?");
                                string powiat = AnsiConsole.Ask<string>("Podaj [green]powiat[/]?");
                                string ulica = AnsiConsole.Ask<string>("Podaj [green]ulica[/]?");
                                int numer_domu = AnsiConsole.Ask<int>("Podaj [green]numer domu[/]?");
                                int numer_lokalu = AnsiConsole.Ask<int>("What's your [green]numer_lokalu[/]?");
                                var id_klienta = AnsiConsole.Prompt(
            new TextPrompt<int>("[grey][[Uzupełnij tylko jeśli je znasz]][/] Podaj[green]id klienta[/]?")
                .AllowEmpty());

                                var adres = new Adres
                                {
                                    miasto = miasto,
                                    powiat = powiat,
                                    ulica = ulica,
                                    numer_lokalu = numer_lokalu,
                                    numer_domu = numer_domu,
                                    Klient_Id_klienta = id_klienta

                                };
                             

                                try
                                {
                                    db.AdresSet.Add(adres);
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

                            //// Display all Blogs from the database
                            //var query = from b in db.AdresSet
                            //                //orderby b.imie
                            //            select b;

                            //Console.WriteLine("All blogs in the database:");
                            //foreach (var item in query)
                            //{
                            //    Console.WriteLine(item.miasto);
                            //}

                            //Console.WriteLine("Press any key to exit...");
                            //Console.ReadKey();
                            if (tabela == "Faktura")//działa
                            {
                                var id_klienta = AnsiConsole.Prompt(new TextPrompt<int>("[grey][[Uzupełnij tylko jeśli je znasz]][/] Podaj[green]id klienta[/]?").AllowEmpty());
                                DateTime data = AnsiConsole.Ask<DateTime>("Podaj [green]date sprzedaży[/]?(W formie 05/06/2021)");
                                
                                double wartość_netto = AnsiConsole.Ask<double>("Podaj [green]wartośc netto[/]?");
                                double procent = AnsiConsole.Ask<double>("Podaj [green]wartość podatku" + "[/]?");
                                bool czy_dostawa = AnsiConsole.Ask<bool>("Czy była dostawa wpisz [green] true jeśli dostawa lub false, jeśli jej brak" + "[/]?");
                                //var k = db.Faktura_produktuSet.Find(7);
                                var faktura2 = from b in db.Faktura_produktuSet
                                               where b.Id_faktura_produktu == 7
                                               select b;

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
                            if (tabela == "Dane Kontaktowe")
                            {
                                int id_kontaktu = AnsiConsole.Ask<int>("Podaj [green]id kontaktu[/]?");
                                int numer = AnsiConsole.Ask<int>("Podaj [green]numer[/]?");
                                string email=AnsiConsole.Ask<string>("Podaj [green]numer[/]?");
                                    

                                var dane_Kontaktowe = new Dane_kontaktowe()
                                {
                                    Id_kontaktu=id_kontaktu,
                                    numer=numer,emial=email
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
                                int id_adresu= AnsiConsole.Ask<int>("Podaj [green]id adresu[/]?");
                                int id_kontaktu = AnsiConsole.Ask<int>("Podaj [green]id kontaktu[/]?");
                                


                                var pracownik = new Pracownik()
                                {
                                    imie=imie,nazwisko=nazwisko,data_zatrunienia=data,Id_adresu=id_adresu,Id_kontaktu=id_kontaktu
                                
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
                            if (tabela == "Zdjecia")
                            {
                                string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe[/]?");
                                DateTime localDate = DateTime.Now;

                                int id_produktu = AnsiConsole.Ask<int>("Podaj [green]id produktu[/]?");

                                var zdjęcia = new Zdjęcia()
                                {
                                    nazwa = nazwa,data=localDate,Id_produktu=id_produktu

                                };
                                try
                                {
                                    db.ZdjęciaSet.Add(zdjęcia); db.SaveChanges();
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
                            if (tabela == "Klient")
                            {
                                string imie = AnsiConsole.Ask<string>("Podaj [green]imiee[/]?");
                                string nazwisko = AnsiConsole.Ask<string>("Podaj [green]nazwisko[/]?");
                                int id_kontaktu = AnsiConsole.Ask<int>("Podaj [green]id kontaktu[/]?");

                                int id_adresu = AnsiConsole.Ask<int>("Podaj [green]id adresu[/]?");

                                int id_produktu = AnsiConsole.Ask<int>("Podaj [green]id produktu[/]?");

                                var klient = new Klient()
                                {
                                   imie=imie,nazwisko=nazwisko,Id_adresu=id_adresu,Id_kontaktu=id_kontaktu
                                };
                                try
                                {
                                    db.KlientSet.Add(klient); db.SaveChanges();
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
                           
                            continue;

                    case "edytuj":
                            AnsiConsole.Markup("[underline green]Hello[/] ");
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
    


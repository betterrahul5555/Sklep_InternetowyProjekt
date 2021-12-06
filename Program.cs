using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Program
    {
       public static string menu()
        {
            using (var db = new Model1Container())
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
               .Title("[blue]Co zamierzasz dodać?[/]")
               .PageSize(10)
               .MoreChoicesText("[grey]()[/]")
               .AddChoices(new[] {
            "Adres", "Dane Kontaktowe", "Faktura",
            "Faktura produktu","Klient","Pracownik","Producent","Produkt","Zdjęcia"
               }));
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
                                db.AdresSet.Add(adres);
                              
                                db.SaveChanges();
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
                                db.FakturaSet.Add(faktura);

                                db.SaveChanges();



                                db.SaveChanges();
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
                                db.Faktura_produktuSet.Add(faktura_produktu);

                                db.SaveChanges();
                            }
                            if (tabela == "Kategoria")
                            {
                                string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe[/]?");



                                var faktura_produktu = new Kategoria()
                                {
                                    nazwa=nazwa



                                };
                                db.KategoriaSet.Add(faktura_produktu);

                                db.SaveChanges();
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
                                db.Kategoria_produktuSet.Add(kategoria_produktu);

                                db.SaveChanges();
                            }

                            continue;

                    case "edytuj":
                        Console.WriteLine($"Measured value is ; too high.");
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
    


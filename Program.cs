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
                            if (tabela == "Adres")
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
                            if (tabela == "Dane Kontaktowe")
                            {
                                int numer = AnsiConsole.Ask<int>("Podaj [green]numer telefonu[/]?");
                               
                                string email = AnsiConsole.Ask<string>("Podaj [green]emial[/]?");
                                
                                
                                var dane_kontaktowe = new Dane_kontaktowe
                                {
                                    
                                    
                                   numer=numer,
                                    emial=email

                                };
                                db.Dane_kontaktoweSet.Add(dane_kontaktowe);

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
    


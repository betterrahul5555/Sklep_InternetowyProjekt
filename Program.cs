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
            "Adres Klienta","Adres Pracownika", "Dane Kontaktowe Klienta","Dane Kontaktowe Pracownika", "Faktura",
            "Faktura produktu","Klient","Pracownik","Producent","Produkt","Zdjęcia","Kategoria","Kategoria produktu"
               }));
                            if (tabela == "Produkt")
                            {

                                string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe produktu[/]?");
                                string opis = AnsiConsole.Ask<string>("Podaj [green]opis[/]?");
                                double cena_netto = AnsiConsole.Ask<double>("Podaj [green]cena netto[/]?");
                                double procent = AnsiConsole.Ask<double>("Podaj [green]procent vat[/]?");
                                int id_kategorii_produktu = AnsiConsole.Ask<int>("Podaj [green]id_kategorii_produktu[/]?");


                                //  int id_zdjecia = AnsiConsole.Ask<int>("Podaj [green]id_zdjecia [/]?");
                                var id_zdjecia = AnsiConsole.Prompt(
    new TextPrompt<string>("[grey][[Optional]][/] [green]Favorite color[/]?")
        .AllowEmpty());
                                if (id_zdjecia == "")
                                {
                                    var produkt = new Produkt()
                                    {
                                        nazwa = nazwa,
                                        opis = opis,

                                        cena_netto = cena_netto,
                                        Id_kategorii_produktu = id_kategorii_produktu,
                                        procent_vat = procent,


                                        Id_zdjecia = null
                                    };


                                    try
                                    {
                                        db.ProduktSet.Add(produkt);
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
                                else
                                {
                                    var produkt = new Produkt()
                                    {
                                        nazwa = nazwa,
                                        opis = opis,

                                        cena_netto = cena_netto,
                                        Id_kategorii_produktu = id_kategorii_produktu,
                                        procent_vat = procent,


                                        Id_zdjecia = Int32.Parse(id_zdjecia)
                                    };


                                    try
                                    {
                                        db.ProduktSet.Add(produkt);
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

                            }
                            if (tabela == "Adres Klienta")
                            {
                                string miasto = AnsiConsole.Ask<string>("Podaj [green]miasto[/]?");
                                string powiat = AnsiConsole.Ask<string>("Podaj [green]powiat[/]?");
                                string ulica = AnsiConsole.Ask<string>("Podaj [green]ulice[/]?");
                                int numer_domu = AnsiConsole.Ask<int>("Podaj [green]numer domu[/]?");
                                int numer_lokalu = AnsiConsole.Ask<int>("Podaj [green]numer lokalu[/]?");
                                int id_klienta = AnsiConsole.Ask<int>("POdaj [green]id klienta[/]?");


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
                                int id_pracownika = AnsiConsole.Ask<int>("Podaj[green]id pracownika[/]?");


                                try
                                {

                                    var adres = new Adres
                                    {
                                        miasto = miasto,
                                        powiat = powiat,
                                        ulica = ulica,
                                        numer_lokalu = numer_lokalu,
                                        numer_domu = numer_domu,
                                        PracownikId_pracownika1 = id_pracownika

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
                                DateTime data = AnsiConsole.Ask<DateTime>("Podaj [green]date sprzedaży[/]?(W formie np 05/06/2021 16:10)");

                                double wartość_netto = AnsiConsole.Ask<double>("Podaj [green]wartośc netto[/]?");
                                double procent = AnsiConsole.Ask<double>("Podaj [green]wartość podatku[/]?");
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
                                    czy_dostawa = czy_dostawa
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
                                    numer_faktury = numer_faktury,




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
                                    nazwa = nazwa



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
                                int id_producenta = AnsiConsole.Ask<int>("Podaj [green]id producenta[/]?");
                                int id_kategori = AnsiConsole.Ask<int>("Podaj [green]id kategorii[/]?");



                                var kategoria_produktu = new Kategoria_produktu()
                                {
                                    Id_kategorii = id_kategori,
                                    Id_producenta = id_kategori




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
                            if (tabela == "Dane Kontaktowe Klienta")
                            {
                                int id_klienta = AnsiConsole.Ask<int>("Podaj [green]id klienta[/]?");
                                int numer = AnsiConsole.Ask<int>("Podaj [green]numer[/]?");
                                string email = AnsiConsole.Ask<string>("Podaj [green]numer[/]?");

                                Klient dk;
                                dk = db.KlientSet.Where(k => k.Id_klienta == id_klienta).First();
                                var dane_Kontaktowe = new Dane_kontaktowe()
                                {
                                    Klient = dk,
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
                                dk = db.PracownikSet.Where(k => k.Id_pracownika == id_pracownika).First();

                                var Pracownik = new Pracownik();
                                var dane_Kontaktowe = new Dane_kontaktowe()
                                {

                                    Pracownik = dk,
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
                                    imie = imie,
                                    nazwisko = nazwisko,
                                    data_zatrunienia = data

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
                                    nazwa = nazwa,
                                    data = localDate,
                                    ProduktId_produktu = id_produktu

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
                                    if (e == null)
                                    {
                                        AnsiConsole.Markup("[underline green]Udało się dodać do bazy. \nZa chwile wrócisz do menu [/]");

                                    }
                                    Thread.Sleep(4000);


                                }

                                Console.Clear();
                            }
                            if (tabela == "Klient")
                            {
                                string imie = AnsiConsole.Ask<string>("Podaj [green]imie[/]?");
                                string nazwisko = AnsiConsole.Ask<string>("Podaj [green]nazwisko[/]?");




                                var klient = new Klient()
                                {
                                    
                                    imie = imie,
                                    nazwisko = nazwisko
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
                                   "Faktura produktu","Kategoria","Kategoria produktu","Klient","Pracownik","Producent","Produkt","Zdjęcia"
                                   }));
                            if (tabela == "Adres")
                            {
                                var query = from a in db.AdresSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Miasto", "Powiat", "Ulica", "Numer domu", "Numer lokalu", "Id pracownika", "Id klienta");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_adresu), item.miasto, item.powiat, item.ulica, Convert.ToString(item.numer_domu), Convert.ToString(item.numer_lokalu), Convert.ToString(item.PracownikId_pracownika1), Convert.ToString(item.KlientId_klienta));

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
                                table.AddColumns("Id", "Id produktu", "Numer faktury", "Ilość");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_faktura_produktu), Convert.ToString(item.Id_produktu), Convert.ToString(item.numer_faktury), Convert.ToString(item.ilość));
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
                                table.AddColumns("Id", "Imię", "Nazwisko");
                                foreach (var item in query)
                                {
                                    table.AddRow(Convert.ToString(item.Id_klienta), item.imie, item.nazwisko);
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }
                            if (tabela == "Pracownik")
                            {
                                var query = from a in db.PracownikSet
                                            select a;

                                var table = new Table();
                                table.AddColumns("Id", "Imię", "Nazwisko", "Data zatrudnienia");
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
                                table.AddColumns("Id", "Id kat prod", "Nazwa", "Opis", "Id zdjęcia", "Cena netto", "Procent vat");
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
                                table.AddColumns("Id", "Nazwa", "Data", "Id produktu");
                                foreach (var item in query)
                                {
                                    table.AddRow(item.nazwa, Convert.ToString(item.data), Convert.ToString(item.ProduktId_produktu));
                                }
                                table.BorderColor(Color.Blue);
                                AnsiConsole.Write(table);
                            }

                            break;
                        case "Edytuj":

                            var tabela_edit = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title("[blue]Co zamierzasz edytować?          [/]")
                   .PageSize(12)
                   .MoreChoicesText("[grey]()[/]")
                   .AddChoices(new[] {
            "Adres Klienta","Adres Pracownika", "Dane Kontaktowe", "Faktura",
            "Faktura produktu","Klient","Pracownik","Producent","Produkt","Zdjęcia","Kategoria","Kategoria produktu"
                   }));
                            if (tabela_edit == "Adres Klienta")
                            {
                                Adres ad;
                                int wybor_id_adresu = AnsiConsole.Ask<int>("[underline yellow]Podaj id adresu, który chcesz edytować:[/]");
                                try
                                {
                                    ad = db.AdresSet.SingleOrDefault(a => a.Id_adresu == wybor_id_adresu);
                                    db.SaveChangesAsync();
                                    string miasto = AnsiConsole.Ask<string>("Podaj [green]miasto[/]?");
                                    string powiat = AnsiConsole.Ask<string>("Podaj [green]powiat[/]?");
                                    string ulica = AnsiConsole.Ask<string>("Podaj [green]ulica[/]?");
                                    int numer_domu = AnsiConsole.Ask<int>("Podaj [green]numer domu[/]?");
                                    int numer_lokalu = AnsiConsole.Ask<int>("What's your [green]numer_lokalu[/]?");
                                    int id_klienta = AnsiConsole.Ask<int>("What's your [green]id klienta[/]?");
                                    if (ad != null)
                                    {
                                        ad.miasto = miasto;
                                        ad.powiat = powiat;
                                        ad.ulica = ulica;
                                        ad.numer_domu = numer_domu;
                                        ad.numer_lokalu = numer_lokalu;
                                        ad.KlientId_klienta = id_klienta;

                                    }
                                    try
                                    {
                                        db.SaveChangesAsync();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }

                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Adres o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Adres Pracownika")
                            {
                                Adres ad;
                                int wybor_id_adresu = AnsiConsole.Ask<int>("[underline yellow]Podaj id adresu, który chcesz edytować:[/]");
                                try
                                {
                                    ad = db.AdresSet.SingleOrDefault(a => a.Id_adresu == wybor_id_adresu);
                                    db.SaveChangesAsync();
                                    string miasto = AnsiConsole.Ask<string>("Podaj [green]miasto[/]?");
                                    string powiat = AnsiConsole.Ask<string>("Podaj [green]powiat[/]?");
                                    string ulica = AnsiConsole.Ask<string>("Podaj [green]ulica[/]?");
                                    int numer_domu = AnsiConsole.Ask<int>("Podaj [green]numer domu[/]?");
                                    int numer_lokalu = AnsiConsole.Ask<int>("Podaj [green]numer_lokalu[/]?");
                                    int id_pracownika = AnsiConsole.Ask<int>("Podaj[green]id klienta[/]?");
                                    if (ad != null)
                                    {
                                        ad.miasto = miasto;
                                        ad.powiat = powiat;
                                        ad.ulica = ulica;
                                        ad.numer_domu = numer_domu;
                                        ad.numer_lokalu = numer_lokalu;
                                        ad.PracownikId_pracownika1 = id_pracownika;

                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }

                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Adres o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Klient")
                            {
                                Klient k;
                                int wybor_id_klienta = AnsiConsole.Ask<int>("[underline yellow]Podaj id klienta, którego chcesz edytować:[/]");
                                try
                                {
                                    k = db.KlientSet.SingleOrDefault(a => a.Id_klienta == wybor_id_klienta);
                                    db.SaveChangesAsync();
                                    string imie = AnsiConsole.Ask<string>("Podaj [green]imie[/]?");
                                    string nazwisko = AnsiConsole.Ask<string>("Podaj [green]nazwisko[/]?");
                                    if (k != null)
                                    {
                                        k.imie = imie;
                                        k.nazwisko = nazwisko;
                                    }
                                    try
                                    {
                                        db.SaveChangesAsync();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu[/]");
                                            Thread.Sleep(1000);
                                        }
                                    }
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Klient o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Zdjęcia")
                            {
                                Zdjęcia z;
                                int wybor_id_zdjecia = AnsiConsole.Ask<int>("[underline yellow]Podaj id zdjęcia, które chcesz edytować:[/]");
                                try
                                {
                                    z = db.ZdjęciaSet.SingleOrDefault(a => a.Id_zdjecia == wybor_id_zdjecia);
                                    db.SaveChangesAsync();
                                    string nazwa = AnsiConsole.Ask<string>("Podaj [green] nową nazwę[/]");
                                    DateTime localDate = DateTime.Now;
                                    int id_produktu = AnsiConsole.Ask<int>("Podaj [green]id produktu[/]?");
                                    if (z != null)
                                    {
                                        z.nazwa = nazwa;
                                        z.data = localDate;
                                        z.ProduktId_produktu = id_produktu;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Adres o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Dane Kontaktowe")
                            {
                                Dane_kontaktowe dk;
                                int wybor_id_danych = AnsiConsole.Ask<int>("[underline yellow]Podaj id danych, który chcesz edytować:[/]");
                                try
                                {
                                    dk = db.Dane_kontaktoweSet.SingleOrDefault(a => a.Id_kontaktu == wybor_id_danych);
                                    db.SaveChangesAsync();
                                    int numer = AnsiConsole.Ask<int>("Podaj [green]numer[/]?");
                                    string email = AnsiConsole.Ask<string>("Podaj [green]email[/]?");
                                    if (dk != null)
                                    {
                                        dk.numer = numer;
                                        dk.emial = email;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Dane kontaktowe o podanym ID nie istnieją! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Faktura")
                            {
                                Faktura f;
                                int wybor_nr_faktury = AnsiConsole.Ask<int>("[underline yellow]Podaj numer faktury, który chcesz edytować:[/]");
                                try
                                {
                                    f = db.FakturaSet.SingleOrDefault(a => a.numer_faktury == wybor_nr_faktury);
                                    db.SaveChangesAsync();
                                    var id_klienta = AnsiConsole.Prompt(new TextPrompt<int>("Podaj[green]id klienta[/]?").AllowEmpty());
                                    DateTime data = AnsiConsole.Ask<DateTime>("Podaj [green]date sprzedaży[/]?(W formie 05/06/2021)");
                                    double wartość_netto = AnsiConsole.Ask<double>("Podaj [green]wartośc netto[/]?");
                                    double procent = AnsiConsole.Ask<double>("Podaj [green]wartość podatku" + "[/]?");
                                    bool czy_dostawa = AnsiConsole.Ask<bool>("Czy była dostawa wpisz [green] true jeśli dostawa lub false, jeśli jej brak" + "[/]?");
                                    if (f != null)
                                    {
                                        f.Id_klienta = id_klienta;
                                        f.data_sprzedaży = data;
                                        f.wartość_netto = wartość_netto;
                                        f.procent_podatku = procent;
                                        f.czy_dostawa = czy_dostawa;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Faktura o podanym numerze nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Faktura produktu")
                            {
                                Faktura_produktu fp;
                                int wybor_faktura_produktu = AnsiConsole.Ask<int>("[underline yellow]Podaj id faktury produktu, który chcesz edytować:[/]");
                                try
                                {
                                    fp = db.Faktura_produktuSet.SingleOrDefault(a => a.Id_faktura_produktu == wybor_faktura_produktu);
                                    db.SaveChangesAsync();
                                    DateTime data = AnsiConsole.Ask<DateTime>("Podaj [green]date sprzedaży[/]?(W formie 05/06/2021)");
                                    int id_produktu = AnsiConsole.Ask<int>("Podaj [green]id produktu[/]?");
                                    int numer_faktury = AnsiConsole.Ask<int>("Podaj [green]numer faktury[/]?");
                                    if (fp != null)
                                    {
                                        fp.Id_produktu = id_produktu;
                                        fp.numer_faktury = numer_faktury;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Faktura produktu o podanym id nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Pracownik")
                            {
                                Pracownik p;
                                int wybor_id_pracownika = AnsiConsole.Ask<int>("[underline yellow]Podaj id pracownika, który chcesz edytować:[/]");
                                try
                                {
                                    p = db.PracownikSet.SingleOrDefault(a => a.Id_pracownika == wybor_id_pracownika);
                                    db.SaveChangesAsync();
                                    string imie = AnsiConsole.Ask<string>("Podaj [green]imie[/]?");
                                    string nazwisko = AnsiConsole.Ask<string>("Podaj [green]nazwisko[/]?");
                                    DateTime data = AnsiConsole.Ask<DateTime>("Podaj [green]date zatrudnie[/]?(W formie 05/06/2021)");
                                    if (p != null)
                                    {
                                        p.imie = imie;
                                        p.nazwisko = nazwisko;
                                        p.data_zatrunienia = data;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Pracownik o podanym id nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Producent")
                            {
                                Producent pro;
                                int wybor_id_producenta = AnsiConsole.Ask<int>("[underline yellow]Podaj id producenta, który chcesz edytować:[/]");
                                try
                                {
                                    pro = db.ProducentSet.SingleOrDefault(a => a.Id_producenta == wybor_id_producenta);
                                    db.SaveChangesAsync();
                                    string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe[/]");
                                    if (pro != null)
                                    {
                                        pro.nazwa = nazwa;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Producent o podanym id nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Produkt")
                            {
                                Produkt pro;
                                int wybor_id_produktu = AnsiConsole.Ask<int>("[underline yellow]Podaj id produktu, który chcesz edytować:[/]");
                                try
                                {
                                    pro = db.ProduktSet.SingleOrDefault(a => a.Id_produktu == wybor_id_produktu);
                                    db.SaveChangesAsync();
                                    string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe produktu[/]?");
                                    string opis = AnsiConsole.Ask<string>("Podaj [green]opis[/]?");
                                    double cena_netto = AnsiConsole.Ask<double>("Podaj [green]cena netto[/]?");
                                    double procent = AnsiConsole.Ask<double>("Podaj [green]procent vat[/]?");
                                    int id_kategorii_produktu = AnsiConsole.Ask<int>("Podaj [green]id_kategorii_produktu[/]?");
                                    if (pro != null)
                                    {
                                        pro.nazwa = nazwa;
                                        pro.opis = opis;
                                        pro.cena_netto = cena_netto;
                                        pro.Id_kategorii_produktu = id_kategorii_produktu;
                                        pro.procent_vat = procent;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Produkt o podanym id nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Kategoria")
                            {
                                Kategoria kat;
                                int wybor_id_kategorii = AnsiConsole.Ask<int>("Podaj id kategorii, którą chcesz edytować");
                                try
                                {
                                    kat = db.KategoriaSet.SingleOrDefault(a => a.Id_kategorii == wybor_id_kategorii);
                                    db.SaveChangesAsync();
                                    string nazwa = AnsiConsole.Ask<string>("Podaj [green]nazwe produktu[/]?");

                                    if (kat != null)
                                    {
                                        kat.nazwa = nazwa;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Kategoria o podanym id nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            if (tabela_edit == "Kategoria produktu")
                            {
                                Kategoria_produktu kp;
                                int wybor_kategorii_produktu = AnsiConsole.Ask<int>("[underline yellow]Podaj id kategorii produktu, który chcesz edytować:[/]");
                                try
                                {
                                    kp = db.Kategoria_produktuSet.SingleOrDefault(a => a.Id_kategoria_produktu == wybor_kategorii_produktu);
                                    db.SaveChangesAsync();
                                    int id_producenta = AnsiConsole.Ask<int>("Podaj [green]id producenta[/]?");
                                    int id_kategori = AnsiConsole.Ask<int>("Podaj [green]id kategorii[/]?");

                                    if (kp != null)
                                    {
                                        kp.Id_kategorii = id_kategori;
                                        kp.Id_producenta = id_producenta;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Source != null)
                                        {
                                            Console.Clear();
                                            AnsiConsole.Markup("[underline green]Nie udało się dodać do bazy.\nSprawdź dane!\n Za chwile wrócisz do menu [/]");
                                            Thread.Sleep(1000);
                                        }
                                    }

                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Kategoria produktu o podanym id nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            break;

                        case "Usuń":

                            var tabela3 = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title("[blue]W której tabeli chcesz usunąć rekord?          [/]")
                   .PageSize(12)
                   .MoreChoicesText("[grey]()[/]")
                   .AddChoices(new[] {
            "Adres", "Dane Kontaktowe", "Faktura",
            "Faktura produktu","Klient","Pracownik","Producent","Produkt","Zdjęcia","Kategoria","Kategoria produktu"
                   }));
                            //1
                            if (tabela3 == "Adres")
                            {
                                Adres adr;
                                int id_adresu_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID adresu, który chcesz usunąć z bazy:[/]");

                                try
                                {
                                    adr = db.AdresSet.Where(a => a.Id_adresu == id_adresu_do_usuniecia).First();
                                    db.AdresSet.Remove(adr);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Adres o ID: {0}, z danymi: (Miasto:{1}, Powiat:{2}, Ulica:{3}, Numer domu:{4}) został pomyślnie usunięty. ", adr.Id_adresu, adr.miasto, adr.powiat, adr.ulica, adr.numer_domu);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Adres o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //2
                            if (tabela3 == "Dane Kontaktowe")
                            {
                                Dane_kontaktowe dk;
                                int id_kontaktu_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID kontaktu, który chcesz usunąć z bazy:[/]");

                                try
                                {
                                    dk = db.Dane_kontaktoweSet.Where(k => k.Id_kontaktu == id_kontaktu_do_usuniecia).First();
                                    db.Dane_kontaktoweSet.Remove(dk);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Kontakt o ID: {0}, z danymi: (Numer telefonu:{1}, Email:{2}) został pomyślnie usunięty. ", dk.Id_kontaktu, dk.numer, dk.emial);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Kontakt o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //3
                            if (tabela3 == "Faktura")
                            {
                                Faktura fk;
                                Faktura_produktu fkp;
                                int id_faktury_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID faktury, którą chcesz usunąć z bazy:[/]");

                                try
                                {
                                    fk = db.FakturaSet.Where(a => a.numer_faktury == id_faktury_do_usuniecia).First();
                                    db.FakturaSet.Remove(fk);

                                    fkp = db.Faktura_produktuSet.Where(a => a.numer_faktury == id_faktury_do_usuniecia).First();
                                    db.Faktura_produktuSet.Remove(fkp);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Faktura o numerze: {0}, z danymi: (Id klienta: {1}, Data sprzedaży: {2}, Wartość netto: {3}, Dostawa: {4}, Podatek: {5} %) została usunięta. ", fk.numer_faktury, fk.Id_klienta, fk.data_sprzedaży, fk.wartość_netto, fk.czy_dostawa, fk.procent_podatku);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Faktura o podanym numerze nie istnieje! Spróbuj z innym numerem[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //4
                            if (tabela3 == "Faktura produktu")
                            {
                                Faktura_produktu fkp;
                                int id_fkp_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID faktury_produktu, który chcesz usunąć z bazy:[/]");

                                try
                                {
                                    fkp = db.Faktura_produktuSet.Where(a => a.Id_faktura_produktu == id_fkp_do_usuniecia).First();
                                    db.Faktura_produktuSet.Remove(fkp);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Faktura_produktu o ID: {0}, z danymi: (Id produktu: {1}, Numer faktury:{2}) została usunięta. ", fkp.Id_faktura_produktu, fkp.Id_produktu, fkp.numer_faktury);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Faktura_produktu o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //5
                            if (tabela3 == "Klient")
                            {
                                Klient kl;
                         
                                Adres adr;
                                Faktura fk;
                                int id_klienta_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID klienta, którego chcesz usunąć z bazy:[/]");

                                try
                                {
                                   
                                    kl = db.KlientSet.Where(a => a.Id_klienta == id_klienta_do_usuniecia).First();
                                    db.KlientSet.Remove(kl);
                               
                                   

           

                                    adr = db.AdresSet.Where(a => a.KlientId_klienta == id_klienta_do_usuniecia).First();
                                    db.AdresSet.Remove(adr);

                                    fk = db.FakturaSet.Where(a => a.Id_klienta == id_klienta_do_usuniecia).First();
                                    db.FakturaSet.Remove(fk);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Klient o ID: {0}, z danymi: (Imie: {1}, Nazwisko: {2}) został usunięty. ", kl.Id_klienta, kl.imie, kl.nazwisko);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {

                                        AnsiConsole.Markup("[red]Klient o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //6
                            if (tabela3 == "Pracownik")
                            {
                                Pracownik pr;
                               
                                Adres adr;
                                int id_pracownika_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID pracownika, którego chcesz usunąć z bazy:[/]");

                                try
                                {
                                    pr = db.PracownikSet.Where(a => a.Id_pracownika == id_pracownika_do_usuniecia).First();
                                    db.PracownikSet.Remove(pr);

                                     

                                    adr = db.AdresSet.Where(a => a.PracownikId_pracownika1 == id_pracownika_do_usuniecia).First();
                                    db.AdresSet.Remove(adr);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Pracownik o ID: {0}, z danymi: (Imie: {1}, Nazwisko: {2}, Data zatrudnienia: {3}) został usunięty. ", pr.Id_pracownika, pr.imie, pr.nazwisko, pr.data_zatrunienia);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Pracownik o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //7
                            if (tabela3 == "Producent")
                            {
                                Producent pro;
                                Kategoria_produktu kat_pr;
                                int id_producenta_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID producenta, którego chcesz usunąć z bazy:[/]");

                                try
                                {
                                    pro = db.ProducentSet.Where(a => a.Id_producenta == id_producenta_do_usuniecia).First();
                                    db.ProducentSet.Remove(pro);

                                    kat_pr = db.Kategoria_produktuSet.Where(a => a.Id_producenta == id_producenta_do_usuniecia).First();
                                    db.Kategoria_produktuSet.Remove(kat_pr);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Producent o ID: {0}, z Nazwą: {1}, został usunięty. ", pro.Id_producenta, pro.nazwa);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Producent o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                    
                            //8
                            if (tabela3 == "Produkt")
                            {
                                Produkt produkt;
                                Zdjęcia zdj;
                                
                                int id_produktu_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID produktu, który chcesz usunąć z bazy:[/]");

                                try
                                {
                                    produkt = db.ProduktSet.Where(a => a.Id_produktu == id_produktu_do_usuniecia).First();
                                    db.ProduktSet.Remove(produkt);

                                    zdj = db.ZdjęciaSet.Where(a => a.ProduktId_produktu == id_produktu_do_usuniecia).First();
                                    db.ZdjęciaSet.Remove(zdj);

                                 //  fkp = db.Faktura_produktuSet.Where(a => a.id_produktu == id_produktu_do_usuniecia).first();
                                  // db.Faktura_produktuSet.Remove(fkp);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Produkt o ID: {0}, z danymi: (Nazwa: {1}, Opis: {2}, Cena netto: {3}, VAT: {4}% ) został usunięty. ", produkt.Id_produktu, produkt.nazwa, produkt.opis, produkt.cena_netto, produkt.procent_vat);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Produkt o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //9
                            if (tabela3 == "Zdjęcia")
                            {
                                Zdjęcia zdj;
                                int id_zdj_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID zdjęcia, które chcesz usunąć z bazy:[/]");

                                try
                                {
                                    zdj = db.ZdjęciaSet.Where(a => a.Id_zdjecia == id_zdj_do_usuniecia).First();
                                    db.ZdjęciaSet.Remove(zdj);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Zdjęcie o ID: {0}, z danymi: (Nazwa: {1}, Data: {2}) zostało usunięte. ", zdj.Id_zdjecia, zdj.nazwa, zdj.data);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Zdjęcie o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //10
                            if (tabela3 == "Kategoria")
                            {
                                Kategoria kat;
                                Kategoria_produktu kat_pr;

                                int id_kategorii_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID kategorii, którą chcesz usunąć z bazy:[/]");

                                try
                                {
                                    kat = db.KategoriaSet.Where(a => a.Id_kategorii == id_kategorii_do_usuniecia).First();
                                    db.KategoriaSet.Remove(kat);

                                    kat_pr = db.Kategoria_produktuSet.Where(a => a.Id_kategorii == id_kategorii_do_usuniecia).First();
                                    db.Kategoria_produktuSet.Remove(kat_pr);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Kategoria o ID: {0}, z Nazwą: {1}, została usunięta. ", kat.Id_kategorii, kat.nazwa);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Kategoria o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            //11  tu troche nie ogarniam pogadac o tym
                            if (tabela3 == "Kategoria produktu")
                            {
                                Kategoria_produktu kat_pr;
                                int id_kat_pr_do_usuniecia = AnsiConsole.Ask<int>("Podaj [blue]ID kategorii_produktu, którą chcesz usunąć z bazy:[/]");

                                try
                                {
                                    kat_pr = db.Kategoria_produktuSet.Where(a => a.Id_kategoria_produktu == id_kat_pr_do_usuniecia).First();
                                    db.Kategoria_produktuSet.Remove(kat_pr);

                                    db.SaveChangesAsync();
                                    Console.WriteLine("\n Kategoria_produktu o ID: {0}, z danymi: (Id_producenta:{1}, Id_kategorii:{2}) został usunięty. ", kat_pr.Id_kategoria_produktu, kat_pr.Id_producenta, kat_pr.Id_kategorii);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    if (e.Source != null)
                                    {
                                        AnsiConsole.Markup("[red]Kategoria_produktu o podanym ID nie istnieje! Spróbuj z innym ID[/]");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            continue;
                        
                    

                       
                    default:
                        Console.WriteLine("default");
                        break;
                }
            }
            
               
                }
            }
        }
    


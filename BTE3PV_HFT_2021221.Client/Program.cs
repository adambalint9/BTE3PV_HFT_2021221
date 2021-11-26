
using BTE3PV_HFT_2021221.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BTE3PV_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(5000);

            RestService rest = new RestService("http://localhost:4854");


            
            
            int option = 1000;

            while (option != 0)
            {
                Console.Clear();

                Console.WriteLine("Choose an option");
                Console.WriteLine("1 Books");
                Console.WriteLine("2 Authors");
                Console.WriteLine("3 Publishers");
                Console.WriteLine("4 Statisctics");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    while (option != 6)
                    {
                        Console.Clear();

                        Console.WriteLine("Choose an option");
                        Console.WriteLine("1 List Books");
                        Console.WriteLine("2 select Book");
                        Console.WriteLine("3 Update Books");
                        Console.WriteLine("4 Delete Books");
                        Console.WriteLine("5 Create Books");
                        Console.WriteLine("6 go back");

                        option = int.Parse(Console.ReadLine());


                        if (option == 1)
                        {
                            List<Book> q = rest.Get<Book>("Book");
                            writer(q);
                            Console.WriteLine(" press enter continue...");
                            Console.ReadLine();
                        }
                        else if (option == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("What is the id of the book?");
                            int a = int.Parse(Console.ReadLine());

                            var q = rest.GetSingle<Book>("Book/" + a);
                            Console.WriteLine(q.ToString());
                            Console.WriteLine(" press enter continue...");
                            Console.ReadLine();

                        }
                        else if (option == 3)
                        {
                            Console.Clear();
                            Book newbook = new Book();

                            Console.WriteLine("title,Language,Lenght,topic, yearofissue,PublisherID,AuthorId");



                            newbook.Title = Console.ReadLine();
                            newbook.Language = Console.ReadLine();
                            newbook.Lenght = int.Parse(Console.ReadLine());

                            newbook.Topic = Console.ReadLine();
                            newbook.YearOfIssue = int.Parse(Console.ReadLine());
                            newbook.PublisherID = int.Parse(Console.ReadLine());
                            newbook.AuthorID = int.Parse(Console.ReadLine());


                            rest.Put<Book>(newbook, "Book");
                            Console.WriteLine("Book has been updated press enter continue...");
                            Console.WriteLine();

                        }
                        else if (option == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("What is the id of the book?");
                            int a = int.Parse(Console.ReadLine());
                            rest.Delete(a, "Book");
                            Console.WriteLine("Book has been deleted press enter continue...");
                            Console.WriteLine();

                        }

                        else if (option == 5)
                        {
                            Console.WriteLine("title,Language,Lenght,topic, yearofissue,PublisherID,AuthorId,");

                            Book newbook = new Book();


                            newbook.Title = Console.ReadLine();
                            newbook.Language = Console.ReadLine();
                            newbook.Lenght = int.Parse(Console.ReadLine());

                            newbook.Topic = Console.ReadLine();
                            newbook.YearOfIssue = int.Parse(Console.ReadLine());
                            newbook.PublisherID = int.Parse(Console.ReadLine());
                            newbook.AuthorID = int.Parse(Console.ReadLine());

                            rest.Post<Book>(newbook, "Book");

                            Console.WriteLine("Book has been added press enter continue...");
                            Console.WriteLine();
                        }

                    }
                }

                else if (option == 2)
                {
                    while (option != 6)
                    {
                        Console.Clear();

                        Console.WriteLine("Choose an option");
                        Console.WriteLine("1 List Authors");
                        Console.WriteLine("2 select Author");
                        Console.WriteLine("3 Update Author");
                        Console.WriteLine("4 Delete Author");
                        Console.WriteLine("5 Create Author");
                        Console.WriteLine("6 go back");

                        option = int.Parse(Console.ReadLine());

                        if (option == 1)
                        {
                            List<Author> q = rest.Get<Author>("Author");
                            writer(q);
                            Console.ReadLine();
                        }
                        else if (option == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("What is the id of the Author?");
                            int a = int.Parse(Console.ReadLine());

                            var q = rest.GetSingle<Author>("Author/" + a);
                            Console.WriteLine(q.ToString());
                            Console.WriteLine(" press enter continue...");
                            Console.ReadLine();


                        }
                        else if (option == 3)
                        {
                            Console.Clear();
                            Author newA = new Author();

                            Console.WriteLine(" AuthoreName , Birthcountry,  BirthYear, Specialization, WritingLanguage ");



                            newA.AuthoreName = Console.ReadLine();
                            newA.Birthcountry = Console.ReadLine();
                            newA.BirthYear = int.Parse(Console.ReadLine());
                            newA.Specialization = Console.ReadLine();
                            newA.WritingLanguage = Console.ReadLine();


                            rest.Put<Author>(newA, "Author");
                            Console.WriteLine("Author has been updated press enter continue...");
                            Console.WriteLine();

                        }
                        else if (option == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("What is the id of the Author?");
                            int a = int.Parse(Console.ReadLine());
                            rest.Delete(a, "Author");
                            Console.WriteLine("Author has been deleted press enter continue...");
                            Console.WriteLine();
                        }
                        else if (option == 3)
                        {
                            Console.Clear();
                            Author newA = new Author();

                            Console.WriteLine(" AuthoreName , Birthcountry,  BirthYear, Specialization, WritingLanguage ");



                            newA.AuthoreName = Console.ReadLine();
                            newA.Birthcountry = Console.ReadLine();
                            newA.BirthYear = int.Parse(Console.ReadLine());
                            newA.Specialization = Console.ReadLine();
                            newA.WritingLanguage = Console.ReadLine();


                            rest.Put<Author>(newA, "Author");
                            Console.WriteLine("Author has been created press enter continue...");
                            Console.WriteLine();

                        }
                    }

                }

                else if (option == 3)
                {
                    while (option != 6)
                    {
                        Console.Clear();

                        Console.WriteLine("Choose an option");
                        Console.WriteLine("1 List Publishers");
                        Console.WriteLine("2 select Publisher");
                        Console.WriteLine("3 Update Publishers");
                        Console.WriteLine("4 Delete Publishers");
                        Console.WriteLine("5 Create Publishers");
                        Console.WriteLine("6 go back");

                        option = int.Parse(Console.ReadLine());

                        if (option == 1)
                        {
                            var q = rest.Get<Publisher>("Publisher");
                            writer(q);
                            Console.WriteLine(" press enter continue...");
                            Console.ReadLine();
                        }
                        else if (option == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("What is the id of the Publisher?");
                            int a = int.Parse(Console.ReadLine());

                            var q = rest.GetSingle<Publisher>("Publisher/" + a);
                            Console.WriteLine(q.ToString());
                            Console.WriteLine(" press enter continue...");
                            Console.ReadLine();


                        }
                        else if (option == 3)
                        {
                            Console.Clear();
                            Publisher newP = new Publisher();

                            Console.WriteLine("PublisherName, TelphoneNumber, Email, Headquarters, YearOfFundation ");

                            newP.PublisherName = Console.ReadLine();
                            newP.TelphoneNumber = int.Parse(Console.ReadLine());
                            newP.Email = Console.ReadLine();
                            newP.Headquarters = Console.ReadLine();
                            newP.YearOfFundation = int.Parse(Console.ReadLine());




                            rest.Put<Publisher>(newP, "Publisher");
                            Console.WriteLine("Publisher has been updated press enter continue...");
                            Console.WriteLine();

                        }
                        else if (option == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("What is the id of the Publisher?");
                            int a = int.Parse(Console.ReadLine());
                            rest.Delete(a, "Publisher");
                            Console.WriteLine("Publisher has been deleted press enter continue...");
                            Console.WriteLine();

                        }
                        else if (option == 5)
                        {
                            Console.Clear();
                            Publisher newP = new Publisher();

                            Console.WriteLine("PublisherName, TelphoneNumber, Email, Headquarters, YearOfFundation ");

                            newP.PublisherName = Console.ReadLine();
                            newP.TelphoneNumber = int.Parse(Console.ReadLine());
                            newP.Email = Console.ReadLine();
                            newP.Headquarters = Console.ReadLine();
                            newP.YearOfFundation = int.Parse(Console.ReadLine());




                            rest.Put<Publisher>(newP, "Publisher");
                            Console.WriteLine("Publisher has been Created press enter continue...");
                            Console.WriteLine();

                        }
                    }

                }
                else if (option == 4)
                {
                    while (option != 7)
                    {


                        Console.Clear();

                        Console.WriteLine("Choose an option");

                        Console.WriteLine("1 Avrage year books publisehd");
                        Console.WriteLine("2 Count Book By Author");
                        Console.WriteLine("3 Count how many book was writen on diferent topics by one author");
                        Console.WriteLine("4 Was the book writen on the author main language");
                        Console.WriteLine("5 Count Book By Publisher");
                        Console.WriteLine("6 Avrage brith year of the authors");
                        Console.WriteLine("7 go back");

                        option = int.Parse(Console.ReadLine());

                        if (option == 1)
                        {
                            var f = rest.Get<KeyValuePair<string, int>>("Stat/AVGYeraPublished");

                            writer(f);

                        }
                        else if (option == 2)
                        {
                            var f = rest.Get<KeyValuePair<string, int>>("Stat/CountBookByAuthor");

                            writer(f);

                        }
                        else if (option == 3)
                        {
                            var f = rest.Get<KeyValuePair<string, int>>("Stat/CountBookByTopic");

                            writer(f);

                        }
                        else if (option == 4)
                        {
                            var f = rest.Get<KeyValuePair<string, int>>("Stat/ISMothrtounge");

                            writer(f);

                        }
                        else if (option == 5)
                        {
                            var f = rest.Get<KeyValuePair<string, int>>("Stat/CountBookByPublisher");

                            writer(f);

                        }
                        else if (option == 6)
                        {
                            var f = rest.GetSingle<double>("Stat/AVGBirthyear");

                            Console.WriteLine(f);

                        }
                        Console.WriteLine(" press enter continue...");
                        Console.ReadLine();

                    }
                }
            }





        }
        public static void writer(IEnumerable items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }



        }


    }
}

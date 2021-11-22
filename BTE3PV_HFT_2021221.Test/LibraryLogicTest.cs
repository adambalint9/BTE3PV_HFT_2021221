using BTE3PV_HFT_2021221.Logic;
using BTE3PV_HFT_2021221.Models;
using BTE3PV_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BTE3PV_HFT_2021221.Test
{
    [TestFixture]
    public class LibraryLogicTest
    {
        PublisherLogic pl;
        AuthorLogic al;
        BookLogic bl;
        public LibraryLogicTest()
        {
            Mock<IBookRepository> mockbookrepo = new Mock<IBookRepository>();
            Mock<IAuthorRepository> mockauthorrpo = new Mock<IAuthorRepository>();
            Mock<IPublisherRepository> mockpulisherrepo = new Mock<IPublisherRepository>();


            mockauthorrpo.Setup((t) => t.Create(It.IsAny<Author>()));
            mockauthorrpo.Setup((t) => t.ReadAll()).Returns(
               new List<Author>()
                 {
                     new Author()
                     {
                            AuthoreName = "Proba",
                            Birthcountry = "England",
                            BirthYear = 2000,
                            WritingLanguage = "English",
                            Specialization = "Math",
                            Books= new List<Book>()
                            {
                                new Book()
                                {
                                     Language = "English",
                                      Title = "Test1",
                                     YearOfIssue = 2010,
                                    Topic = "Math",
                                    Lenght = 500,


                                }
                            }

                     },
                     new Author()
                     {      AuthoreName = "Probalina",
                             Birthcountry = "Hungary",
                            BirthYear = 1000,
                            WritingLanguage = "Hungarian",
                            Specialization = "Biology",


                            Books= new List<Book>()
                            {
                                new Book()
                                {
                                    Language = "English",
                                    Title = "Test2",
                                    YearOfIssue = 2010,
                                    Topic = "Biology",
                                    Lenght = 500,


                                },

                                 new Book()
                                {
                                    Language = "English",
                                    Title = "Test3",
                                    YearOfIssue = 2010,
                                    Topic = "Biology",
                                    Lenght = 500,


                                },
                                new Book()
                                {
                                    Language = "Hungarian",
                                    Title = "Test4",
                                    YearOfIssue = 2010,
                                    Topic = "Phisics",
                                    Lenght = 500,


                                }



                            }


                     }



               }.AsQueryable());




            al = new AuthorLogic(mockauthorrpo.Object);

            Author fakeauthor = new Author()
            {
                AuthoreName = "Proba",
                Birthcountry = "England",
                BirthYear = 1995,
                WritingLanguage = "English",
                Specialization = "Math"



            };
            Author fakeauthortwo = new Author()
            {
                AuthoreName = "Probalina",
                Birthcountry = "Hungary",
                BirthYear = 1970,
                WritingLanguage = "Hungarian",
                Specialization = "Biology"



            };
            Publisher fakepublisher = new Publisher()
            {
                PublisherName = "RealPublisher",
                YearOfFundation = 1600,
                Email = "Real@.com",
                TelphoneNumber = 123,
                Headquarters = "Budapest"


            };
            mockbookrepo.Setup((t) => t.Create(It.IsAny<Book>()));
            mockbookrepo.Setup((t) => t.ReadAll()).Returns(
           new List<Book>()
           {
               new Book()
               {
                   Id=0,
                 Language = "English",
                  Title = "Test1",
                 YearOfIssue = 2010,
                Topic = "Math",
                Lenght = 500,
                Author = fakeauthor,
                Publishers = fakepublisher

               },

               new Book()
                    {
                         Id=1,
                        Language = "English",
                        Title = "Test2",
                        YearOfIssue = 2010,
                        Topic = "Biology",
                        Lenght = 500,
                        Author = fakeauthortwo,
                        Publishers = fakepublisher

                    },

                 new Book()
                { 
                     Id=2,
                    Language = "English",
                    Title = "Test3",
                    YearOfIssue = 2010,
                    Topic = "Biology",
                    Lenght = 500,
                    Author = fakeauthortwo,
                    Publishers = fakepublisher

                },
                new Book()
                {
                     Id=3,
                    Language = "Hungarian",
                    Title = "Test4",
                    YearOfIssue = 2010,
                    Topic = "Phisics",
                    Lenght = 500,
                    Author = fakeauthortwo,
                    Publishers = fakepublisher

                }
            }.AsQueryable());

            bl = new BookLogic(mockbookrepo.Object);
            mockpulisherrepo.Setup((t) => t.Create(It.IsAny<Publisher>()));
            mockpulisherrepo.Setup((t) => t.ReadAll()).Returns(
                new List<Publisher>()
                {

                    new Publisher()
                    {
                        PublisherName = "RealPublisher",
                        YearOfFundation = 1600,
                        Email = "Real@.com",
                        TelphoneNumber = 123,
                        Headquarters = "Budapest",
                        Books= new List<Book>()
                        {
                            new Book()
                           {
                             Language = "English",
                              Title = "Test1",
                             YearOfIssue = 2010,
                            Topic = "Math",
                            Lenght = 500,
                            Author = fakeauthor,
                            Publishers = fakepublisher

                           },

                                new Book()
                                {
                                    Language = "English",
                                    Title = "Test2",
                                    YearOfIssue = 2010,
                                    Topic = "Biology",
                                    Lenght = 500,
                                    Author = fakeauthortwo,
                                    Publishers = fakepublisher

                                },

                             new Book()
                            {
                                Language = "English",
                                Title = "Test3",
                                YearOfIssue = 2010,
                                Topic = "Biology",
                                Lenght = 500,
                                Author = fakeauthortwo,
                                Publishers = fakepublisher

                            },
                            new Book()
                            {
                                Language = "Hungarian",
                                Title = "Test4",
                                YearOfIssue = 2010,
                                Topic = "Phisics",
                                Lenght = 500,
                                Author = fakeauthortwo,
                                Publishers = fakepublisher

                            }

                        }

                    }

                }.AsQueryable());

            pl = new PublisherLogic(mockpulisherrepo.Object);


        }
        [Test]
        public void CountByTopicTest()
        {
            var result = bl.CountBookByTopic().ToArray();

            //Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Proba", 1)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("Probalina", 2)));


        }
        [Test]
        public void AVG()
        {
            var result = bl.AVGYeraPublished().ToArray();


            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, double>("RealPublisher", 2010)));


        }

        [Test]
        public void IsWritenOnTheWritersMothertounge()
        {
            var result = bl.IsWritenOnTheWritersMothertounge().ToArray();


            Assert.That(result[2], Is.EqualTo(new KeyValuePair<string, bool>("Test3", false)));
            // Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, bool>("Test1", true)));
        }

        [Test]
        public void CountBookByAuthor()
        {

            var results = al.CountBookByAuthor().ToArray();

            Assert.That(results[1], Is.EqualTo(new KeyValuePair<string, int>("Probalina", 3)));


        }
        [Test]
        public void CountBookByPublisher()
        {
            var results = pl.CountBookByPublisher().ToArray();

            Assert.That(results[0], Is.EqualTo(new KeyValuePair<string, int>("RealPublisher", 4)));


        }
        [TestCase("", false)]
        [TestCase("rendes", true)]
        public void CreateAuthorrTest(string name, bool result)
        {

            
            if (result)
            {
                Assert.That(() => al.Create(new Author()
                {
                    AuthoreName = name,
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => al.Create(new Author()
                {
                    AuthoreName = name,
                }), Throws.Exception);
            }


        }
        [TestCase("", false)]
        [TestCase("rendes", true)]
        public void CreatePublisherTest(string name, bool result)
        {

            
            if (result)
            {
                Assert.That(() => pl.Create(new Publisher()
                {
                    PublisherName = name,
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() =>pl.Create(new Publisher()
                {
                    PublisherName = name,
                }), Throws.Exception);
            }



        }
        [TestCase("", false)]
        [TestCase("rendes", true)]        
        public void CreateBookTest(string name, bool result)
        {

            if (result)
            {
                Assert.That(() => bl.Create(new Book()
                {
                    Title=name,
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => bl.Create(new Book()
                {
                    Title = name,
                }), Throws.Exception);
            }


        }


        [TestCase("Ujnev")]
        public void BookUpdte(string name)
        {
            var test = bl.ReadAll().ToArray();
            test[0].Title = name;

            bl.Update(test[0]);
            var sample = bl.ReadAll().ToArray();
            

            Assert.That(test[0].Title, Is.EqualTo(sample[0].Title));


        }
        [Test]
        public void AvGAuthorBirthYear()
        {


            var test = al.AGVBirthYear();

            Assert.That(test, Is.EqualTo(1500));
        
        
        }





    }
}

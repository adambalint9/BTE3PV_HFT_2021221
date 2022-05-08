using BTE3PV_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BTE3PV_HFT_2021221.WPFClient
{
    public class BookWindowWievModel:ObservableRecipient
    {
        public RestCollection<Book> Books { get; set; }

        private Book selectedBook;

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Book SelectedBook
        {
            get { return selectedBook; }
            set {

                if (value != null)
                {
                    selectedBook=new Book()
                    { AuthorID=value.AuthorID,
                        PublisherID=value.PublisherID,
                        Id=value.Id,
                        Language=value.Language,
                        Lenght=value.Lenght,                       
                        Title=value.Title,
                        Topic=value.Topic,
                        YearOfIssue=value.YearOfIssue,
  
                    };
                       
                    
                    
                    
                    
                    
                    
                    
                    OnPropertyChanged();
                    (DeleteBookCommand  as RelayCommand).NotifyCanExecuteChanged();
                   
                    
                }
                
            
            }
            
        }


        public ICommand CreateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public BookWindowWievModel()
        {
            if (!IsInDesignMode)
            {

            
                Books = new RestCollection<Book>("http://localhost:4854/", "Book","hub");
                CreateBookCommand = new RelayCommand(()=>{
            
                    Books.Add(new Book()
                    { 
                    Title =selectedBook.Title,
                    Topic =selectedBook.Topic,
                    YearOfIssue =selectedBook.YearOfIssue,
                    Language =selectedBook.Language,
                    Lenght =selectedBook.Lenght,
                    AuthorID =selectedBook.AuthorID,
                    PublisherID =selectedBook.PublisherID,
                
                
                    }); 
                    
                    
                   

                 });

                DeleteBookCommand = new RelayCommand(()=>
                {
                    Books.Delete(SelectedBook.Id);
                },
                ()=>
                {
                    return SelectedBook != null;
                }
            
                );
                }
                UpdateBookCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Books.Update(new Book()

                        {
                            Title=selectedBook.Title,
                            Topic=selectedBook.Topic,
                            Language=selectedBook.Language,
                            Lenght=selectedBook.Lenght,
                            YearOfIssue=selectedBook.YearOfIssue,
                            AuthorID=selectedBook.AuthorID,
                            PublisherID=selectedBook.PublisherID,
                            Id=selectedBook.Id

                        });
                        


                        
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                 });
            SelectedBook=new Book();
        }
    }
}

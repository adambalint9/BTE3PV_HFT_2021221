using BTE3PV_HFT_2021221.Models;
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

namespace BTE3PV_HFT_2021221.WPFClient.WievModels
{
    public class AuthorWindowWievModel :ObservableRecipient
    {
        public RestCollection<Author> Authors { get; set; }

        private Author selectedAuthor;

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Author SelectedAuthor
        { 
        
            get { return selectedAuthor; }

            set {
                if (value!=null)
                {
                    selectedAuthor = value;
                    OnPropertyChanged();
                    (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            
            }
                
        }
        public ICommand CreateAuthorCommand { get; set; }

        public ICommand DeleteAuthorCommand { get; set; }

        public ICommand UpadteAuthorCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AuthorWindowWievModel()
        {
            if (!IsInDesignMode)
            {
                Authors = new RestCollection<Author>("http://localhost:4854/", "Author");

                CreateAuthorCommand = new RelayCommand(() => { 
                    Authors.Add(new Author()
                    { 

                     AuthoreName=selectedAuthor.AuthoreName,
                     BirthYear=selectedAuthor.BirthYear,
                     Specialization=selectedAuthor.Specialization,
                     WritingLanguage=selectedAuthor.WritingLanguage,
                     Birthcountry=selectedAuthor.Birthcountry

                    } );
         
             
                });

                DeleteAuthorCommand = new RelayCommand(() => 
                {

                    Authors.Delete(selectedAuthor.Id);
                
                
                },
                ()=>
                {
                    return selectedAuthor != null;
                });

                UpadteAuthorCommand = new RelayCommand(() =>
                {

                    try
                    {

                        Authors.Update(new Author()
                        {   
                            Id=selectedAuthor.Id,
                            AuthoreName = selectedAuthor.AuthoreName,
                            Birthcountry = selectedAuthor.Birthcountry,
                            BirthYear = selectedAuthor.BirthYear,
                            Specialization = selectedAuthor.Specialization,
                            WritingLanguage = selectedAuthor.WritingLanguage

                        });

                    }
                    catch (ArgumentException ex)
                    {

                        ErrorMessage = ex.Message;
                    }




                });
                selectedAuthor = new Author();
               




            }
        
        
        
        }




    }
}

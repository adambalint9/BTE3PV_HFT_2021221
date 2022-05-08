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
    public class PublisherWiewModel:ObservableRecipient
    {
        public RestCollection<Publisher> Publishers { get; set; }

        private Publisher selectedPublisher;

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Publisher SelectedPublisher
        { 
        
          get { return selectedPublisher; }
            set
            {
                if (value!=null)
                {
                    selectedPublisher = value;
                    OnPropertyChanged();
                    (DeletPulisherCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }                              
        }
        
        public ICommand CreatePulisherCommand { get; set; }

        public ICommand UpdatePulisherCommand { get; set; }

        public ICommand DeletPulisherCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PublisherWiewModel()
        {
            if (!IsInDesignMode)
            {
                Publishers = new RestCollection<Publisher>("http://localhost:4854/", "Publisher");

                CreatePulisherCommand = new RelayCommand(() =>
                {

                      Publishers.Add(new Publisher()
                      {
                          PublisherName = SelectedPublisher.PublisherName,
                          Email = SelectedPublisher.Email,
                          TelphoneNumber = SelectedPublisher.TelphoneNumber,
                          Headquarters = SelectedPublisher.Headquarters,
                          YearOfFundation = SelectedPublisher.YearOfFundation

                      });
                });

                DeletPulisherCommand = new RelayCommand(() =>
                 {
                     Publishers.Delete(SelectedPublisher.Id);
                 },
                () =>
                {
                    return SelectedPublisher != null;
                });
                UpdatePulisherCommand = new RelayCommand(() =>
                 {
                     try
                     {
                         Publishers.Update(new Publisher()
                         {                        
                          Id = SelectedPublisher.Id,
                          PublisherName = SelectedPublisher.PublisherName,
                          Email = SelectedPublisher.Email,
                          TelphoneNumber = SelectedPublisher.TelphoneNumber,
                          Headquarters = SelectedPublisher.Headquarters,
                          YearOfFundation = SelectedPublisher.YearOfFundation
                         });                                          
                     }
                     catch (ArgumentException ex)
                     {
                         ErrorMessage = ex.Message;
                     }

                });
                SelectedPublisher=new Publisher();

            }
        
        
        
        }



    }
}

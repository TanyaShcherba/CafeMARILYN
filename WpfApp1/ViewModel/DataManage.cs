using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApp1.Annotations;
using WpfApp1.Model.Data;
using WpfApp1.Model.UnitDB;
using WpfApp1.View.AdminWindow;
using WpfApp1.View.HelperWindow;

namespace WpfApp1.ViewModel
{
    public class DataManage : INotifyPropertyChanged
    {

        #region DataProp

        private List<Hotel> allHotels = DataWorker.GetAllHotels();
        public List<Hotel> AllHotels
        {
            get => allHotels;
            set
            {
                allHotels = value;
                OnPropertyChanged("AllHotels");
            }
        }

        private List<Client> allClients = DataWorker.GetAllClients();
        public List<Client> AllClients
        {
            get => allClients;
            set
            {
                allClients = value;
                OnPropertyChanged("AllClients");
            }
        }

        private List<Staff> allStaves = DataWorker.GetAllStaves();
        public List<Staff> AllStaves
        {
            get => allStaves;
            set
            {
                allStaves = value;
                OnPropertyChanged("AllStaves");
            }
        }

        private List<Country> allCountries = DataWorker.GetAllCountries();
        public List<Country> AllCountries
        {
            get => allCountries;
            set
            {
                allCountries = value;
                OnPropertyChanged("AllCountries");
            }
        }

        private List<Discount> allDiscounts = DataWorker.GetAlDiscounts();
        public List<Discount> AllDiscounts
        {
            get => allDiscounts;
            set
            {
                allDiscounts = value;
                OnPropertyChanged("AllDiscounts");
            }
        }

        private List<Nutrition> allNutritions = DataWorker.GetAllNutritions();
        public List<Nutrition> AllNutritions
        {
            get => allNutritions;
            set
            {
                allNutritions = value;
                OnPropertyChanged("AllNutritions");
            }
        }

        private List<TourType> allTourTypes = DataWorker.GetAllTourTypes();
        public List<TourType> AllTourTypes
        {
            get => allTourTypes;
            set
            {
                allTourTypes = value;
                OnPropertyChanged("AllTourTypes");
            }
        }

        private List<Tour> allTours = DataWorker.GetAllTours();
        public List<Tour> AllTours
        {
            get => allTours;
            set
            {
                allTours = value;
                OnPropertyChanged("AllTours");
            }
        }

        #endregion

        #region Command prop
        public string Login { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        #endregion

        #region Command to open windows

        private RelayCommand openAdminField;
        public RelayCommand OpenAdminField
        {
            get => openAdminField ?? new RelayCommand(obj =>
            {
                if (Login == "root" && Password == "root" && Position == "Администратор")
                {
                    OpenAdminFieldMethod();
                }
                else
                {
                    ShowMessageBox("Заполните поля");
                }

            });
        }

        private RelayCommand openHotelList;

        public RelayCommand OpenHotelList
        {
            get => openHotelList ?? new RelayCommand(obj =>
            {
                OpenHotelListMethod();
            });
        }

        #endregion

        #region Methods to open windows

        private void OpenAdminFieldMethod()
        {
            AdminMainWindow newAdminMainWindow = new AdminMainWindow();
            SetCenterPosAndOpen(newAdminMainWindow);
        }

        private void OpenHotelListMethod()
        {
            HotelList hotelList = new HotelList();
            SetCenterPosAndOpen(hotelList);
        }

        private void SetCenterPosAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Application.Current.MainWindow.Hide();
            window.ShowDialog();
        }

        private void ShowMessageBox(string message)
        {
            MessegeWindows messege = new MessegeWindows(message);
            SetCenterPosAndOpen(messege);
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using BOOKSTORE_PROJECT_PO.Dal_Models;
using System;
using System.Windows;

namespace BOOKSTORE_PROJECT_PO
{
    /// <summary>
    /// This class includes all functionality to manipulate city data
    /// </summary>
    public partial class NewCityWindow : Window
    {
        CityDal cityDal = new CityDal();

        public NewCityWindow()
        {
            InitializeComponent();
            LoadCityData();
        }

        private void BtnBackToMainWindow(object sender, RoutedEventArgs e) => this.Close();

        private void LoadCityData() => this.gridCities.ItemsSource = cityDal.getCityNameList;

        private void clearInput() => this.cityInput.Text = "";

        private void BtnAddNewCity(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (this.cityInput.Text.Length == 0) 
                    throw new Exception("Fields can not be empty");

                cityDal.Add(cityInput.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.Message}");
            }

            LoadCityData();
            clearInput();
        }

        protected string cityToRemove;
        private void gridCities_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.gridCities.SelectedIndex >= 0)
            {
                try
                {
                    if (this.gridCities.SelectedItems.Count >= 0)
                    {
                        var city = (CityDalModel)this.gridCities.SelectedItems[0];
                        cityToRemove = city.City;

                        this.cityToDelete.Text = city.City;

                    }
                }
                catch (InvalidCastException) { }
            }
        }

        private void BtnDeleteCity(object sender, RoutedEventArgs e)
        {
            cityDal.Delete(cityToRemove);
            LoadCityData();
            this.cityToDelete.Text = "";
        }
    }
}

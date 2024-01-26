using BOOKSTORE_PROJECT_PO.Dal_Models;
using BOOKSTORE_PROJECT_PO.Dals;
using BOOKSTORE_PROJECT_PO.Validators;
using System;
using System.Windows;

namespace BOOKSTORE_PROJECT_PO
{
    /// <summary>
    ///This class includes all functionality to manipulate customer data
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        CityDal cityDal = new CityDal();
        CustomerDal customerDal = new CustomerDal();
        CustomerValidator customerValidator = new CustomerValidator();
        
        public NewCustomerWindow()
        {
            InitializeComponent();
            LoadCustomerData();
            LoadSelectorData();
        }

        private void LoadCustomerData() => this.gridCustomer.ItemsSource = customerDal.getCustomerList;

        private void LoadSelectorData() => this.comboBoxData.ItemsSource = cityDal.getCityList;

        private void BtnBackToMainWindow(object sender, RoutedEventArgs e) => this.Close();

        private void clearInput()
        {
            this.firstName.Text = "";
            this.lastName.Text = "";
            this.email.Text = "";

            this.nameUpdate.Text = "";
            this.emailUpdate.Text = "";
        }

        private void BtnAddNewCustomer(object sender, RoutedEventArgs e)
        {
            var validateResult = customerValidator.Validate(firstName.Text, lastName.Text, email.Text);
            if (!validateResult.IsCorrect)
            {
                MessageBox.Show($"Validaton error: { validateResult.ErrorMessage}");
                return;
            }

            try
            {
                customerDal.Add(
                    firstName.Text,
                    lastName.Text,
                    email.Text,
                    int.Parse(comboBoxData.SelectedValue.ToString())
                    );
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: { err.Message}");
            }

            LoadCustomerData();
            clearInput();
        }

        protected string customerEmail;
        private void gridCustomer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.gridCustomer.SelectedIndex >= 0)
            {
                try
                {
                    if (this.gridCustomer.SelectedItems.Count >= 0)
                    {
                        var customer = (CustomerDalModel)this.gridCustomer.SelectedItems[0];

                        customerEmail = customer.Email;

                        this.nameUpdate.Text = customer.Name;
                        this.emailUpdate.Text = customer.Email;
                        this.comboBoxCityUpdate.ItemsSource = cityDal.getCityList;
                        this.comboBoxCityUpdate.SelectedValue = cityDal.GetCityID(customer.City);
                    }
                }
                catch (InvalidCastException) { }
            }
        }

        private void BtnUpdateCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nameUpdate.Text.Length == 0 || emailUpdate.Text.Length == 0)
                    throw new Exception("Fields can not be empty");

                string newEmail = emailUpdate.Text;
                int newCityId = int.Parse(comboBoxCityUpdate.SelectedValue.ToString());

                customerDal.Update(customerEmail, newEmail, newCityId);
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: { err.Message}");
            }

            LoadCustomerData();
            clearInput();
        }

        private void BtnDeleteCustomer(object sender, RoutedEventArgs e)
        {
            customerDal.Delete(customerEmail);
            LoadCustomerData();
        }
    }
}
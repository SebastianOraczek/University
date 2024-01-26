using BOOKSTORE_PROJECT_PO.Dal_Models;
using BOOKSTORE_PROJECT_PO.Dals;
using System;
using System.Windows;

namespace BOOKSTORE_PROJECT_PO
{
    /// <summary>
    /// This class includes all functionality to manipulate book data
    /// </summary>
    public partial class NewBookWIndow : Window
    {
        AuthorDal authorDal = new AuthorDal();
        StatusDal statusDal = new StatusDal();
        CustomerDal customerDal = new CustomerDal();
        BooksDal bookDal = new BooksDal();

        public NewBookWIndow()
        {
            InitializeComponent();
            LoadSelectorAuthorData();
            LoadSelectorStatusData();
            LoadSelectorCustomerData();
            LoadBooksData();
        }

        private void LoadSelectorAuthorData() => this.comboBoxAuthor.ItemsSource = authorDal.getAuthorList;

        private void LoadSelectorStatusData() => this.comboBoxStatus.ItemsSource = statusDal.getStatusForSelectorList;

        private void LoadSelectorCustomerData() => this.comboBoxCustomer.ItemsSource = customerDal.getCustomerForSelecorList;

        private void LoadBooksData() => this.gridBooks.ItemsSource = bookDal.getBooksList;

        private void BtnBackToMainWindow(object sender, RoutedEventArgs e) => this.Close();

        private void clearInput() => this.title.Text = "";

        private void BtnAddNewBook(object sender, RoutedEventArgs e)
        {
            try
            {
                bookDal.Add(
                    title.Text,
                    datePicker.SelectedDate.Value.Date,
                    int.Parse(comboBoxQuantity.SelectedValue.ToString()),
                    int.Parse(comboBoxAuthor.SelectedValue.ToString()),
                    int.Parse(comboBoxStatus.SelectedValue.ToString()),
                    int.Parse(comboBoxCustomer.SelectedValue.ToString())
                    );
            }
            catch (Exception) 
            {
                MessageBox.Show("Error: Fields can not be empty");
            }

            LoadBooksData();
            clearInput();
        }

        protected string bookTitle;
        private void gridBooks_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.gridBooks.SelectedIndex >= 0)
            {
                try
                {
                    if (this.gridBooks.SelectedItems.Count >= 0)
                    {
                        var book = (BookDalModel)this.gridBooks.SelectedItems[0];
                        bookTitle = book.Title;
                    }
                }
                catch (InvalidCastException) { }
            }
        }

        private void BtnDeleteNewBook(object sender, RoutedEventArgs e)
        {
            bookDal.Delete(bookTitle);
            LoadBooksData();
        }
    }
}

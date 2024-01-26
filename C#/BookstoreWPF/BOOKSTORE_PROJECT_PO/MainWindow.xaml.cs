using BOOKSTORE_PROJECT_PO.Dals;
using System.Windows;

namespace BOOKSTORE_PROJECT_PO
{
    /// <summary>
    /// This class includes events that open a specific window
    /// </summary>
    public partial class MainWindow : Window
    {
        BooksDal bookDal = new BooksDal();

        public MainWindow() 
        { 
            InitializeComponent();
            LoadBooksData();
        }

        private void BtnNewCustomerWindow(object sender, RoutedEventArgs e) => new NewCustomerWindow().Show();

        private void BtnNewBookWindow(object sender, RoutedEventArgs e) => new NewBookWIndow().Show();

        private void BtnNewCityWindow(object sender, RoutedEventArgs e) => new NewCityWindow().Show();

        private void BtnNewAuthorWindow(object sender, RoutedEventArgs e) => new NewAuthorWindow().Show();

        private void BtnStatusWindow(object sender, RoutedEventArgs e) => new StatusWindow().Show();

        private void LoadBooksData() => this.gridBooks.ItemsSource = bookDal.getBooksList;

        private void BtnLoadData(object sender, RoutedEventArgs e) => LoadBooksData();
    }
}
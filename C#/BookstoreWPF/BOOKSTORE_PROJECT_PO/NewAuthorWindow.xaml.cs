using System;
using System.Windows;
using BOOKSTORE_PROJECT_PO.Dal_Models;
using BOOKSTORE_PROJECT_PO.Dals;
using BOOKSTORE_PROJECT_PO.Validators;

namespace BOOKSTORE_PROJECT_PO
{
    /// <summary>
    /// This class includes all functionality to manipulate author data
    /// </summary>
    public partial class NewAuthorWindow : Window
    {
        AuthorDal authorDal = new AuthorDal();
        AuthorValidator authorValidator = new AuthorValidator();

        public NewAuthorWindow()
        {
            InitializeComponent();
            LoadAuthorData();
        }

        private void LoadAuthorData() => this.gridAuthors.ItemsSource = authorDal.getAuthorNameList;

        private void BtnBackToMainWindow(object sender, RoutedEventArgs e) => this.Close();

        private void clearInput()
        {
            this.authorName.Text = "";
            this.authorLastName.Text = "";
            this.authorNameUpdate.Text = "";
            this.authorLastNameUpdate.Text = "";
        }

        private void BtnAddAuthor(object sender, RoutedEventArgs e)
        {
            var validateResult = authorValidator.Validate(authorName.Text, authorLastName.Text);
            if (!validateResult.IsCorrect)
            {
                MessageBox.Show($"Validaton error: { validateResult.ErrorMessage}");
                return;
            }

            try
            {
                if (authorName.Text.Length == 0 || authorLastName.Text.Length == 0) 
                    throw new Exception("Fields can not be empty");

                authorDal.Add(
                    authorName.Text,
                    authorLastName.Text
                    );
            }
            catch (Exception err) 
            {
                MessageBox.Show($"Error: {err.Message}");
            }

            LoadAuthorData();
            clearInput();
        }

        protected string authorUpdateLastName;
        private void gridAuthors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.gridAuthors.SelectedIndex >= 0)
            {
                try
                {
                    if (this.gridAuthors.SelectedItems.Count >= 0)
                    {
                        var author = (AuthorDalModel)this.gridAuthors.SelectedItems[0];

                        authorUpdateLastName = author.LastName;

                        this.authorNameUpdate.Text = author.FirstName;
                        this.authorLastNameUpdate.Text = author.LastName;

                    }
                }
                catch (InvalidCastException) { }
            }
        }

        private void BtnDeleteAuthor(object sender, RoutedEventArgs e)
        {
            authorDal.Delete(authorUpdateLastName);
            clearInput();
            LoadAuthorData();
        }
    }
}

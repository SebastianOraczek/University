namespace BOOKSTORE_PROJECT_PO.Dal_Models.AuthorModels
{
    /// <summary>
    /// Model created to put author to the combobox. It display name, but identify author by ID.
    /// </summary>
    public class AuthorDalModelForSelector
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

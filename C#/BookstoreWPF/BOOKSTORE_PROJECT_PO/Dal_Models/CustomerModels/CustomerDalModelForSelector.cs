namespace BOOKSTORE_PROJECT_PO.Dal_Models.CustomerModels
{
    /// <summary>
    /// Model created to put customer to the combobox. It display name, but identify customer by ID.
    /// </summary>
    public class CustomerDalModelForSelector
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

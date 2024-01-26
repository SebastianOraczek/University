using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace Lab9_WPF
{
    public partial class MainWindow : Window
    {
        // Default values for a initial render
        public static string Type { get; set; } = "";
        public static int PageSize { get; set; } = 10;
        public static int PageNumber { get; set; } = 1;
        public static int LastPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            PageReponse response = FetchSnippets(PageNumber, PageSize, Type);

            this.gridSnippet.ItemsSource = response.Batches;
            this.PageNumberLabel.Content = $"Page {PageNumber} from {response.PagesCount}";
            this.LastPageBtn.Content = response.PagesCount.ToString();
            LastPage = response.PagesCount;
        }

        // Handle Page Size change
        public void Btn_LoadPageSizeData(object sender, RoutedEventArgs e)
        {
            PageSize = int.Parse(this.comboBoxPageSize.SelectedValue.ToString());
            LoadData();
        }

        // Handle type change
        public void ChangeType(string type)
        {
            Type = type;
            PageNumber = 1;
            LoadData();
        }

        private void Btn_Text_Click(object sender, RoutedEventArgs e) => ChangeType(Types.Text);
        private void Btn_Bash_Click(object sender, RoutedEventArgs e) => ChangeType(Types.Bash);
        private void Btn_Cpp_Click(object sender, RoutedEventArgs e) => ChangeType(Types.Cpp);
        private void Btn_CSharp_Click(object sender, RoutedEventArgs e) => ChangeType(Types.CSharp);
        private void Btn_Java_Click(object sender, RoutedEventArgs e) => ChangeType(Types.Java);
        private void Btn_CSS_Click(object sender, RoutedEventArgs e) => ChangeType(Types.CSS);
        private void Btn_HTML_Click(object sender, RoutedEventArgs e) => ChangeType(Types.HTML);
        private void Btn_JS_Click(object sender, RoutedEventArgs e) => ChangeType(Types.JavaScript);
        private void Btn_PHP_Click(object sender, RoutedEventArgs e) => ChangeType(Types.PHP);
        private void Btn_Python_Click(object sender, RoutedEventArgs e) => ChangeType(Types.Python);
        private void Btn_SQL_Click(object sender, RoutedEventArgs e) => ChangeType(Types.SQL);
        private void Btn_All_Click(object sender, RoutedEventArgs e) => ChangeType("");

        // Handle Page Number change
        public void ChangePageNumber(int num)
        {
            PageNumber = num;
            LoadData();
        }

        private void Btn_Prev_Click(object sender, RoutedEventArgs e) => ChangePageNumber(PageNumber - 1);
        private void Btn_Next_Click(object sender, RoutedEventArgs e) => ChangePageNumber(PageNumber + 1);
        private void Btn_First_Click(object sender, RoutedEventArgs e) => ChangePageNumber(1);
        private void Btn_Last_Click(object sender, RoutedEventArgs e) => ChangePageNumber(LastPage);

        public static string FetchData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        public static PageReponse FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            string url = $"https://dirask.com/api/snippets?pageNumber={pageNumber}&pageSize={pageSize}&dataOrder=newest&dataGroup=batches&snippetsType={Uri.EscapeUriString(snippetsType)}";
            string data = FetchData(url);

            return JsonSerializer.Deserialize<PageReponse>(data);
        }
    }
}
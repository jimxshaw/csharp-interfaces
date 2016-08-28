using PersonRepository.Interface;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServiceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchData("Service");
        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchData("CSV");
        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchData("SQL");
        }

        private void FetchData(string repositoryType)
        {
            ClearListBox();
            // We're programming to the IPersonRepository interface by relying on the 
            // factory pattern to provide our concrete repository types. Extensibility 
            // increases because we can add however many more repository types we want 
            // and only have to modify the factory. 
            IPersonRepository repository = RepositoryFactory.GetRepository(repositoryType);
            var people = repository.GetPeople();

            foreach (var person in people)
            {
                PersonListBox.Items.Add(person);
            }

            ShowRepositoryType(repository);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            PersonListBox.Items.Clear();
        }

        private void ShowRepositoryType(IPersonRepository repository)
        {
            MessageBox.Show(string.Format("Repository Type:\n{0}",
                repository.GetType().ToString()));
        }
    }
}

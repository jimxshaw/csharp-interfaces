using PersonLibrary;
using System.Collections.Generic;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        PeopleRepository peopleRepo = new PeopleRepository();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConcreteFetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();

            List<Person> people = peopleRepo.GetPeople();

            PersonListBox.ItemsSource = people;

            //foreach (var person in people)
            //{
            //    PersonListBox.Items.Add(person);
            //}
        }

        private void InterfaceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();

            // Whether we use a Person array or List of Person, each type of collection implements
            // IEnumerable. When we code to the abstraction, we don't care about the specific class 
            // that's returning. All we care about is that it's a class that fulfills the contract. 
            // This makes our code more resistant to change. Pretty much every collections in .NET 
            // implements IEnumerable. Our library can change to a stack, queue, observable collection 
            // or something else and that will be fine as our code will still function the same with no 
            // code modifications. This is known as futureproofing.
            // Notice that our variable people can be either IEnumerable or IEnumerable<T> type. If 
            // IEnumerable is used than a particular person within the people collection will be of 
            // type object, whereas using IEnumerable<Person> will understandably make each person of 
            // type Person. Foreach will work with either of these interfaces.    
            IEnumerable<Person> people = peopleRepo.GetPeople();

            // ItemsSource of our ListBox is an IEnumerable so we can simply assign our people collection 
            // to it instead of using foreach to manually assign each person in the collection. 

            PersonListBox.ItemsSource = people;

            //foreach (var person in people)
            //{
            //    PersonListBox.Items.Add(person);
            //}
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            // Keep in mind that if we choose to use ItemsSource instead of Items, we have to set the 
            // ItemsSource to null instead of calling the Clear method on Items. This makes sense because 
            // it makes no sense to call a method on Items if we're not using Items.

            //PersonListBox.Items.Clear();
            PersonListBox.ItemsSource = null;
        }
    }
}

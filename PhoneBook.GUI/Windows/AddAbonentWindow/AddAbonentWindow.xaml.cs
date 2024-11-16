using System.Windows;
using Abonent = PhoneBook.Core.Abonent;
using AppContext = PhoneBook.Core.AppContext;

namespace PhoneBook.GUI.Windows.AddAbonentWindow;

public partial class AddAbonentWindow : Window
{
    private readonly AppContext _db;
    
    public AddAbonentWindow()
    {
        InitializeComponent();
        
        _db = Application.Current.Resources["DB"] as AppContext;
    }

    private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
    {
        _db.Abonents.Add(new Abonent() { Phone = InputPhone.Text, Name = InputName.Text });
        _db.SaveChanges();
        
        Clear();
    }

    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        InputPhone.Clear();
        InputName.Clear();
    }
}
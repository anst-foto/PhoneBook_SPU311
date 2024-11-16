using System.Windows;
using PhoneBook.Core;
using AppContext = PhoneBook.Core.AppContext;

namespace PhoneBook.GUI.Windows.UpdateAbonentWindow;

public partial class UpdateAbonentWindow : Window
{
    private readonly AppContext _db;
    private readonly string _name;
    private readonly string _phone;
    
    public UpdateAbonentWindow(string name, string phone)
    {
        _name = name;
        _phone = phone;
        
        InitializeComponent();
        
        _db = Application.Current.Resources["DB"] as AppContext;

        Loaded += (_, _) =>
        {
            InputName.Text = _name;
            InputPhone.Text = _phone;
        };
    }
    
    private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
    {
        var abonent = _db.Abonents.FirstOrDefault(a => a.Name == _name && a.Phone == _phone);
        abonent.Name = InputName.Text;
        abonent.Phone = InputPhone.Text;
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
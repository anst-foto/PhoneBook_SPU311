using System.Windows;
using AppContext = PhoneBook.Core.AppContext;

namespace PhoneBook.GUI.Windows.MainWindow;


public partial class MainWindow : Window
{
    private readonly AppContext _db;
    
    public MainWindow()
    {
        InitializeComponent();
        
        _db = Application.Current.Resources["DB"] as AppContext;
        
        Reload();
    }


    private void MenuItemLoad_OnClick(object sender, RoutedEventArgs e)
    {
        Reload();
    }

    private void MenuItemAdd_OnClick(object sender, RoutedEventArgs e)
    {
        var window = new AddAbonentWindow.AddAbonentWindow();
        window.Show();
    }

    private void MenuItemUpdate_OnClick(object sender, RoutedEventArgs e)
    {
        var selectedItem = Abonents.SelectedItem as string;
        var temp = selectedItem.Split(' ');
        var name = temp[0];
        var phone= temp[1];
        var window = new UpdateAbonentWindow.UpdateAbonentWindow(name, phone);
        window.Show();
    }

    private void MenuItemDelete_OnClick(object sender, RoutedEventArgs e)
    {
        var selectedItem = Abonents.SelectedItem as string;
        var temp = selectedItem.Split(' ');
        var name = temp[0];
        var phone= temp[1];
        
        var abonent = _db.Abonents.FirstOrDefault(a => a.Name == name && a.Phone == phone);
        _db.Abonents.Remove(abonent);
        _db.SaveChanges();
        
        Abonents.Items.Remove(Abonents.SelectedItem);
    }

    private void MenuItemReload_OnClick(object sender, RoutedEventArgs e)
    {
        Reload();
    }

    private void Reload()
    {
        Abonents.Items.Clear();
        
        foreach (var abonent in _db.Abonents)
        {
            Abonents.Items.Add(abonent.ToString());
        }
    }
}
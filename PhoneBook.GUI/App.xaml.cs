using System.Windows;
using AppContext = PhoneBook.Core.AppContext;

namespace PhoneBook.GUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        this.Resources.Add("Title", "Телефонный справочник");
        this.Resources.Add("DB", new AppContext());
    }
}
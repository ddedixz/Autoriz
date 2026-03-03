using System.Windows;
using ProductClientApp.Services;

namespace ProductClientApp.Views;

public partial class LoginWindow : Window
{
    private readonly ApiService _apiService = new();
    public LoginWindow()
    {
        InitializeComponent();
    }

    private async void Login_Click(object sender, RoutedEventArgs e)
    {
        var login = LoginBox.Text;
        var password = PasswordBox.Password;

        try
        {
            var success = await _apiService.LoginAsync(login, password);

            if (success)
            {
                var productsWindow =  new ProductsWindow();
                productsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("неверный логин и пароль");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка сервера: {ex.Message}");
        }
    }
}
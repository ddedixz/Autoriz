using System.Windows;
using ProductClientApp.Models;
using ProductClientApp.Services;

namespace ProductClientApp.Views;

public partial class ProductsWindow : Window
{
    private readonly ApiService _apiService = new();
    public ProductsWindow()
    {
        InitializeComponent();
        LoadProducts();
    }
    
    private async void LoadProducts()
    {
        try
        {
            var products = await _apiService.GetProductsAsync();
            ProductsGrid.ItemsSource = products;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}");
        }
    }
}
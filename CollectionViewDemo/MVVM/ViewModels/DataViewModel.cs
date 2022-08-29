using CollectionViewDemo.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewDemo.MVVM.ViewModels
{
    public partial class DataViewModel : ObservableObject 
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        /* Start Binding ************************************************************/

        [ObservableProperty]
        bool isRefreshing;

        // Seleced Single Product
        [ObservableProperty]
        Product selectedProduct;

        // Seleced Multiple Product
        [ObservableProperty]
        List<object> selectedProducts = new List<object>();

        public DataViewModel()
        {
            RefreshItems();

            // Select elements of CollectionView for "Multiple" mode
            //SelectedProducts.Add(Products.Skip(1).FirstOrDefault());
            //SelectedProducts.Add(Products.Skip(2).FirstOrDefault());

            // Select elements of CollectionView for "Single" mode
            //SelectedProduct = Products.Skip(2).FirstOrDefault();
        }

        /* End Binding ************************************************************/

        //lastIndex => This paramiter will be use to know which one the last item will be loading in the list
        private void RefreshItems(int lastIndex = 0)
        {
            //Incrementally data loading
            int numberOfItemsPerPage = 5;
            var items = new ObservableCollection<Product>
               {
                    new Product
                     {
                         Name = "Yogurt",
                         Price = 60.0m,
                         Image = "yogurt.png",
                         HasOffer = false,
                         Stock = 28
                     },
                     new Product
                     {
                         Name = "Watermelon",
                         Price = 30.0m,
                         Image = "watermelon.png",
                         HasOffer = true,
                         Stock = 87
                     },
                     new Product
                     {
                         Name = "Water Bottle",
                         Price = 80.0m,
                         Image = "water_bottle.png",
                         HasOffer = true,
                         OfferPrice = 69.99m,
                         Stock = 33
                     },
                     new Product
                     {
                         Name = "Tomato",
                         Price = 120.0m,
                         Image = "tomato.png",
                         HasOffer = false,
                         Stock = 0
                     },
                     new Product
                     {
                         Name = "Shrimp",
                         Price = 300.0m,
                         Image = "shrimp.png",
                         HasOffer = true,
                         OfferPrice = 250.0m,
                         Stock = 58
                     },
               };

            //to contain the products 10 by 10 
            var pageItems =
                items.Skip(lastIndex)
                .Take(numberOfItemsPerPage);

            foreach (var item in pageItems)
            {
                Products.Add(item);
            }
        }

        /* Start Command ***************************************************/

        [RelayCommand]
        async void Refresh()
        {
            IsRefreshing = true; 
            /*
            Products.Insert(0, new Product
            {
                Name = "Nattapong",
                Price = 100m,
                Image = "dotnet_bot.png",
                HasOffer = true,
                Stock = 10
            });
            */
            await Task.Delay(1000);
            //RefreshItems();
            IsRefreshing = false;
        }

        [RelayCommand]
        void ThresholdReached()
        {
            RefreshItems(Products.Count);
        }

        [RelayCommand]
        void Delete(Product p)
        {
            Products.Remove(p);
        }


        // Single Selection
        [RelayCommand]
        public void ProductChanged()
        {
            // If you want to "Selected Single Product", Use this code
            //var selectedProduct = SelectedProduct;

            // If you want to "Selected Multiple Product", Use this code
            var productList = SelectedProducts;
            Console.WriteLine(productList);
        }

        /* End Command ***************************************************/

    }
}

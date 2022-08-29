using Android.OS;
using CollectionViewDemo.MVVM.ViewModels;

namespace CollectionViewDemo.MVVM.Views;

public partial class ProductsView : ContentPage
{
	public ProductsView()
	{
		InitializeComponent();

		BindingContext = new ProductViewModel();
	}

	private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
	{
	}
}
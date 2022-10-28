using CollectionViewDemo.MVVM.ViewModels;
using System.Diagnostics;

namespace CollectionViewDemo.MVVM.Views;

public partial class ProductsView : ContentPage
{
	public ProductsView()
	{
		InitializeComponent();

		BindingContext = new ProductViewModel();
	}

	int i = 0;

	private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
	{
		Debug.WriteLine("-----------------------");
		Debug.WriteLine("i = " + i);
		Debug.WriteLine("HorizontalDeta: " + e.HorizontalDelta);
		Debug.WriteLine("VerticalDelta: " + e.VerticalDelta);
		Debug.WriteLine("HorizontalOffset " + e.HorizontalOffset);
		Debug.WriteLine("VerticalOffset: " + e.VerticalOffset);
		Debug.WriteLine("FirstVisibleItemIndex: " + e.FirstVisibleItemIndex);
		Debug.WriteLine("CenterItemIndex: " + e.CenterItemIndex);
		Debug.WriteLine("LatVisibleItemIndex: : " + e.LastVisibleItemIndex);
		i++;

	}

	private void Button_Clicked(object sender, EventArgs e)
	{


		var vm = BindingContext as ProductViewModel;

		//Navigation ScrollTo Id = 20
		//var product = vm.Products.SelectMany(p => p).FirstOrDefault(x => x.Id == 20);
		//collectionView.ScrollTo(product, animate: false, position: ScrollToPosition.Center);

		//vm.Products.Add(new Models.ProductsGroup("New Group",
		//	new List<Models.Product>
		//	{
		//		new Models.Product
		//		{
		//			Id = 100,
		//			Name = "Bitcoin",
		//			Price = 999999,
		//		}
		//	}
		//	));

		collectionView.ScrollTo(10);
	}
}
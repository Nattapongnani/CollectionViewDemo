using CollectionViewDemo.MVVM.ViewModels;

namespace CollectionViewDemo.MVVM.Views;

public partial class CollectionLayoutView : ContentPage
{
	public CollectionLayoutView()
	{
		InitializeComponent();

		BindingContext = new CollectionLayoutViewModel();
	}
}
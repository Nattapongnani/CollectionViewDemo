using CollectionViewDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewDemo.Selectors
{
    public class ProductDataTemplateSelector : DataTemplateSelector
    {
        // This generates a method that will allow us to go through each of the elements of
        // the list to decide at runtime which dat template should be applied.
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var product =
                item as Product;
            //Display HasOffer = false
            if (!product.HasOffer)
            {
                //What is the style we want to apply to a product that dose not have an offer?
                Application
                    .Current
                    .Resources
                    .TryGetValue("ProductStyle", out var productStyle); //In case the resource is found, we will store in a variable productStyle
                return productStyle as DataTemplate;
            }else
            {
                Application
                    .Current
                    .Resources
                    .TryGetValue("OfferStyle", out var offerStyle); //In case the resource is found, we will store in a variable productStyle
                return offerStyle as DataTemplate;

            }
            //use this data template selector as part of the XAML file.
            return new DataTemplate();
        }
    }
}

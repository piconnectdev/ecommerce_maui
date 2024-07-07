﻿
using EcommerceMAUI.Model;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        private ObservableCollection<ProductListModel> _AllProductDataList = [];
        public ObservableCollection<ProductListModel> AllProductDataList
        {
            get => _AllProductDataList;
            set => SetProperty(ref _AllProductDataList, value);
        }

        private ObservableCollection<ProductListModel> _FeaturedBrandsDataList = [];
        public ObservableCollection<ProductListModel> FeaturedBrandsDataList
        {
            get => _FeaturedBrandsDataList;
            set => SetProperty(ref _FeaturedBrandsDataList, value);
        }
        public string PageTitle
        {
            get
            {
                return CategoryModel.CategoryName;
            }
        }

        private CategoriesModel _CategoryModel = new();
        public CategoriesModel CategoryModel
        {
            get => _CategoryModel;
            set
            {
                if (_CategoryModel != value)
                {
                    _CategoryModel = value;
                    OnPropertyChanged(nameof(CategoryModel));
                    OnPropertyChanged(nameof(PageTitle));
                }
            }
        }       

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand BackCommand { get; }
        public ICommand SelectProductCommand { get; }
        public CategoryDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            BackCommand = new Command<object>(GoBack);
            SelectProductCommand = new Command<ProductListModel>(SelectProduct);
        }

        public override async Task OnNavigatedTo(NavigationParameters parameters)
        {
            await base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey(NavigationParameterKeys.CategoryData))
            {
                CategoryModel = new();               
                CategoryModel = parameters.GetValue<CategoriesModel>(NavigationParameterKeys.CategoryData);
            }
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
            await Task.Delay(500);
            //TODO: Remove Delay here and call API
            AllProductDataList.Clear();
            AllProductDataList.Add(new ProductListModel() { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = "$755", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = "$450", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = "$900", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Smart Luggage", BrandName = "Smart Inc", Price = "$1200", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Bang and Olufsen", Price = "$90", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "B&o Desk Lamp", BrandName = "Bang and Olufsen", Price = "$450", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "BeoPlay Stand Speaker", BrandName = "Bang and Olufse", Price = "$3000", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Airpods", BrandName = "B&o Phone Case", Price = "$30", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" });

            FeaturedBrandsDataList.Clear();
            FeaturedBrandsDataList.Add(new ProductListModel() { BrandName = "B&o", Details = "5693 Products", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png" });
            FeaturedBrandsDataList.Add(new ProductListModel() { BrandName = "Beats", Details = "1124 Products", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/beats.png" });
            FeaturedBrandsDataList.Add(new ProductListModel() { BrandName = "Apple Inc", Details = "5693 Products", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Apple.png" });
            IsLoaded = true;
        }

        private async void GoBack(object obj)
        {
            await navigationService.PopToRoot();
        }
        private async void SelectProduct(ProductListModel obj)
        {
            await navigationService.Push<ProductDetailsView>();
        }

    }
}

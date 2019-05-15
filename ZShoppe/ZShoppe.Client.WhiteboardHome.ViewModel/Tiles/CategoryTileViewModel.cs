using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Categories;
using ZShoppe.Client.Common.Contracts.ContentTree.Models;
using ZShoppe.Client.Common.Contracts.PubSubEvents;
using ZShoppe.Client.Common.ViewModels;

namespace ZShoppe.Client.WhiteboardHome.ViewModels.Tiles
{
    class CategoryTileViewModel : BaseViewModel, ICategoryTile
    {
        private readonly IEventAggregator _eventAggregator;

        public ICommand ActivateTileCommand { get; set; }
        public bool Enabled { get; set; }
        public ICommand NavigateToCategoryDetailsCommand { get; }
        public IEnumerable<CategoryModel> CategoriesModels { get; set; }
        public string DisplayName { get; set; }
        public string FeatureBackgroundImage { get; set; }
        public string Url { get; set; }

        public CategoryTileViewModel(int index, CategoryTileModel model, IEventAggregator eventAggregator)
        {
            DisplayName = model.DisplayName;
            FeatureBackgroundImage = model.FeatureBackgroundImage;
            Url = model.Url;
            CategoriesModels = model.CategoriesModels;
            _eventAggregator = eventAggregator;
            NavigateToCategoryDetailsCommand = new DelegateCommand<CategoryModel>(ExecuteCategoryDetails);
        }

        private void ExecuteCategoryDetails(CategoryModel categoryModel)
        {
            if (categoryModel != null)
            {
                _eventAggregator.GetEvent<CategoryDetailsEvent>().Publish(categoryModel);
            }
        }
    }
}

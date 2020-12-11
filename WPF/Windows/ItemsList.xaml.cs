using BusinessLogic.Interfaces;
using CourseProjectWPF.ViewModels;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using Unity.Resolution;

namespace CourseProjectWPF.Windows
{
    /// <summary>
    /// Interaction logic for ItemsList.xaml
    /// </summary>
    public partial class ItemsList : Window
    {
        ItemsListModel _itemListViewModel;
        CollectionViewSource _itemCollection;
       

        public ItemsList(ItemsListModel vm)
        {
            _itemListViewModel = vm;
            DataContext = vm;
            InitializeComponent();

            var l =_itemListViewModel.ItemsList();
            foreach (var item in l)
            {
                dgItems.Items.Add(item);
            }

            _itemCollection = (CollectionViewSource)(Resources["ItemCollection"]);
            _itemCollection.Filter += _itemCollection_Filter;
        }

        private void _itemCollection_Filter(object sender, FilterEventArgs e)
        {
            var filter = txtFilter.Text;
            var item = e.Item as ItemDTO;
            if (item.Name.Contains(filter))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            _itemCollection.View.Refresh();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            var itemDetailsWindow = ((App)Application.Current).Container.Resolve<ItemDetails>();
            itemDetailsWindow.ShowDialog();
            _itemListViewModel.Update();
        }

        private void dgItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          
           DataGrid grid = sender as DataGrid;
           var item = (ItemDTO)grid.SelectedItem;
           var detailsViewModel = ((App)Application.Current).Container.Resolve<ItemDetailsModel>(new ParameterOverride("item", item)) ;
           var itemDetailsWindow = new ItemDetails(detailsViewModel);
           itemDetailsWindow.ShowDialog();
           _itemListViewModel.Update();
        }

        private void dgItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _itemCollection.View.Refresh();
        }
    }
}

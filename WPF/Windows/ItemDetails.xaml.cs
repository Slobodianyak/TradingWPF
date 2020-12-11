using CourseProjectWPF.ViewModels;
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

namespace CourseProjectWPF.Windows
{
    /// <summary>
    /// Interaction logic for ItemDetails.xaml
    /// </summary>
    public partial class ItemDetails : Window
    {
        ItemDetailsModel _itemDetailsModel;
        public ItemDetails(ItemDetailsModel vm)
        {
            _itemDetailsModel = vm;
            DataContext = vm;

            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _itemDetailsModel.Save();
            DialogResult = true;
            this.Close();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

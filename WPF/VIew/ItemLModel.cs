using BL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.VIew
{
    partial class ItemLModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private IUser _manager;
        private ObservableCollection<ItemDTO> _itemList;
        public ObservableCollection<ItemDTO> itemList
        {
            get { return _itemList; }
            set
            {
                _itemList = value;
                OnPropertyChanged(nameof(itemList));
            }
        }

        public ItemsListModel(IUser manager)
        {

            _manager = manager;
        }


        public List<ItemDTO> ItemsList()
        {
            return _manager.ShowItems();
        }



        public void Update()
        {
            var items = _manager.ShowItems();
            itemList = new ObservableCollection<ItemDTO>(items);
        }
    }
}

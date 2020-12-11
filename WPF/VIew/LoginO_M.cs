using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.VIew
{
    public partial class LoginO_M:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }

    public string _username;
    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public string Password
    {
        private get;
        set;
    }

    private readonly IUser _security;

    public LoginOrder_managerModel(IUser security)
    {
        _security = security;
    }

    public bool Login()
    {
        return _security.Log(Username, Password);
    }

}

using Bank.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
       UserModel model { get; set; }

        public UserViewModel()
        {
            model = new UserModel();    
        }
    }

        
        
    
}

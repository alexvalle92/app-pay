using AppXamarin.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.API.Interfaces
{
    interface IPaypal
    {
        ServiceTokenModel GetToken();
        void SendPay(double valAmount);
    }
}

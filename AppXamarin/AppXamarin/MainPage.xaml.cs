using AppXamarin.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            PaypalAPI paypal = new PaypalAPI();
            paypal.SendPay(Convert.ToDouble(valuePay.Text));
            DisplayAlert("Atenção", "Executando pagamento" + valuePay.Text, "Ok");
        }
    }
}

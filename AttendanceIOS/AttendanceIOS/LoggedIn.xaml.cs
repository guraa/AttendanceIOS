using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.QrCode;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace AttendanceIOS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoggedIn : ContentPage
    {
        ZXingScannerPage scanPage;


        public LoggedIn(List<values> val)
        {
            InitializeComponent();

            Userid.Text = "Välkommen " + val.FirstOrDefault().FirstName;

            buttonScanDefaultOverlay.Clicked += async delegate {
                scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) => {
                    scanPage.IsScanning = false;

                    Device.BeginInvokeOnMainThread(() => {
                        Navigation.PopModalAsync();
                        DisplayAlert("Scanned Barcode", result.Text, "OK");
                    });
                };

                await Navigation.PushModalAsync(scanPage);
            };



        }

    }
}



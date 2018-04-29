using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.QrCode;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace AttendanceIOS
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoggedIn : ContentPage
    {
        ZXingScannerPage scanPage;
        

        public LoggedIn(List<values> val)
        {
            InitializeComponent();

            Userid.Text = "Välkommen " + val.FirstOrDefault().FirstName ;

            buttonScanDefaultOverlay.Clicked += delegate (object sender, EventArgs e){ ButtonScanDefaultOverlay_Clicked(sender, e, val); };


        }

        private async void ButtonScanDefaultOverlay_Clicked(object sender, EventArgs e, List<values> val)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopModalAsync();
                    DisplayAlert("Hej " + val.FirstOrDefault().FirstName + " Kod", result.Text, "OK");
                    CreateParticipation(result.Text, val.FirstOrDefault().Id);
                });
            };

            await Navigation.PushModalAsync(scanPage);

        }



        public async void CreateParticipation(string code, string studentid)
        {
            Participation CreatePart = new Participation() { StudentId = studentid, Code = code, Attendance = true };
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(CreatePart);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://192.168.1.228/aa/api/Values", content);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Klass", "Tack, du är nu registrerad", "Ok");

            }
            else
            {
                await DisplayAlert("Klass", "Ajaj, något gick fel. Försök igen", "Ok");
            }



        }
    }
}


// POST api/values

//Example POST
//POST /api/values/participate HTTP/1.1
//Host: localhost:59858
//Content-Type: application/json
//Cache-Control: no-cache
//Postman-Token: d5a3752e-4bbc-db8c-52ea-38e5a140431f

//    {
//     "Id": 1,
//     "ClassId" : 2,
//     "Code" : "222",
//     "StudentId" : 2,
//     "Attendance" : 1,
//     "StudentMessage" : "It Worked!"
//    }

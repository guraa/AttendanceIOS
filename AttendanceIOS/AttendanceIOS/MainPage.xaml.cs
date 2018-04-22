using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace AttendanceIOS
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            //  GetProducts();

         


        
    }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            var id = userName.Text;
            var pw = pass.Text;

            var client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.1.228/aa/api/Values?get=" + id);
            var deserializeLogin = JsonConvert.DeserializeObject<List<values>>(response);




            if(id == deserializeLogin.FirstOrDefault().FirstName && pw == deserializeLogin.FirstOrDefault().Password)
            {
                await DisplayAlert("Du är inloggad", "Välkommen " + deserializeLogin.FirstOrDefault().FirstName, "OK");
                await Navigation.PushModalAsync(new LoggedIn(deserializeLogin));
            }
            else
            {
                await DisplayAlert("Felaktiga inloggningsuppgifter", "Det finns ingen användare med de inloggningsuppgifterna", "OK");
            }


            
        }



    }
}



//async void OnLoginButtonClicked(object sender, EventArgs e)
//{
//    var user = new User
//    {
//        Username = usernameEntry.Text,
//        Password = passwordEntry.Text
//    };

//    var isValid = AreCredentialsCorrect(user);
//    if (isValid)
//    {
//        App.IsUserLoggedIn = true;
//        Navigation.InsertPageBefore(new MainPage(), this);
//        await Navigation.PopAsync();
//    }
//    else
//    {
//        messageLabel.Text = "Login failed";
//        passwordEntry.Text = string.Empty;
//    }
//}
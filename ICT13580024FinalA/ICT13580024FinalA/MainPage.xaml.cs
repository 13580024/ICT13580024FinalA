using ICT13580024FinalA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT13580024FinalA
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            newButton.Clicked += NewButton_Clicked;
		}


        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EmployeePage());
        }

        protected override void OnAppearing()
        {
            LoadData();
        }

        void LoadData()
        {
            employeeListView.ItemsSource = App.DbHelper.GetEmployees();
        }

        void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var employee = button.CommandParameter as Employee;
            Navigation.PushModalAsync(new EmployeePage(employee));
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");

            if (isOk)
            {
                var button = sender as MenuItem;
                var employee = button.CommandParameter as Employee;
                App.DbHelper.DeleteEmployee(employee);

                await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลสินค้าเรียบร้อย", "ตกลง");
                LoadData();
            }
        }
    }
}

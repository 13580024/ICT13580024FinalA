using ICT13580024FinalA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580024FinalA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeePage : ContentPage
	{
        Employee employee;

		public EmployeePage (Employee employee=null)
		{
			InitializeComponent ();

            this.employee = employee;

            titleLabel.Text = employee == null ? "เพิ่มพนักงานใหม่" : "แก้ไขข้อมูลพนักงาน";

            genderPicker.Items.Add("ชาย");
            genderPicker.Items.Add("หญิง");

            departmentPicker.Items.Add("แผนกบัญชี");
            departmentPicker.Items.Add("แผนกการตลาด");
            departmentPicker.Items.Add("แผนกซ่อมบำรุง");
            departmentPicker.Items.Add("แผนกทรัพยากรมนุษย์");

            marryPicker.Items.Add("แต่งงานแล้ว");
            marryPicker.Items.Add("ยังไม่แต่งงาน");

            mySlider.ValueChanged += MySlider_ValueChanged;

            myStepper.ValueChanged += MyStepper_ValueChanged;

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            if (employee != null)
            {
                firstNameEntry.Text = employee.FirstName;
                lastNameEntry.Text = employee.LastName;
                ageEntry.Text = employee.Age.ToString();
                genderPicker.SelectedItem = employee.Gender;
                departmentPicker.SelectedItem = employee.Department;
                telNumberEntry.Text = employee.TelNumber.ToString();
                emailEntry.Text = employee.Email;
                addressEditor.Text = employee.Address;
                marryPicker.SelectedItem = employee.Marry;
                babyLabel.Text = employee.Baby.ToString();
                salaryLabel.Text = employee.Salary.ToString();
            }
        }


        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOK = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

            if (isOK)
            {
                if (employee == null)
                {   employee = new Employee();
                    employee.FirstName = firstNameEntry.Text;
                    employee.LastName = lastNameEntry.Text;
                    employee.Age = int.Parse(ageEntry.Text);
                    employee.Gender = genderPicker.SelectedItem.ToString();
                    employee.Department = departmentPicker.SelectedItem.ToString();
                    employee.TelNumber = int.Parse(telNumberEntry.Text);
                    employee.Email = emailEntry.Text;
                    employee.Address = addressEditor.Text;
                    employee.Marry = marryPicker.SelectedItem.ToString();
                    employee.Baby = int.Parse(babyLabel.Text);
                    employee.Salary = int.Parse(salaryLabel.Text);

                    var id = App.DbHelper.AddEmployee(employee);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสพนักงานของท่านคือ #" + id, "ตกลง");
                }
                else
                {   employee.FirstName = firstNameEntry.Text;
                    employee.LastName = lastNameEntry.Text;
                    employee.Age = int.Parse(ageEntry.Text);
                    employee.Gender = genderPicker.SelectedItem.ToString();
                    employee.Department = departmentPicker.SelectedItem.ToString();
                    employee.TelNumber = int.Parse(telNumberEntry.Text);
                    employee.Email = emailEntry.Text;
                    employee.Address = addressEditor.Text;
                    employee.Marry = marryPicker.SelectedItem.ToString();
                    employee.Baby = int.Parse(babyLabel.Text);
                    employee.Salary = int.Parse(salaryLabel.Text);

                    var id = App.DbHelper.UpdateEmployee(employee);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลพนักงานเรียบร้อย", "ตกลง");
                }
                await Navigation.PopModalAsync();
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void MyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            babyLabel.Text = value.ToString();
        }

        private void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            salaryLabel.Text = value.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMICalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Customer
        {
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string phoneNumber { get; set; }
            public int heightInches { get; set; }
            public int weightLbs { get; set; }
            public int custBMI { get; set; }
            public string statusTitle { get; set; }
        }



        public MainWindow()
        {
            InitializeComponent();
        }
        #region Part 1 of lab. ClearBtn & ExitBtn
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            xPhoneBox.Text = "";
            xFirstNameBox.Text = "";
            xLastNameBox.Text = "";
            xHeightInchesBox.Text = "";
            xWeightLbsBox.Text = "";
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer customer1 = new Customer();

            customer1.firstName = xFirstNameBox.Text;
            customer1.lastName = xLastNameBox.Text;
            customer1.phoneNumber = xPhoneBox.Text;
            customer1.heightInches = Convert.ToInt32(xHeightInchesBox.Text);
            customer1.weightLbs = Convert.ToInt32(xWeightLbsBox.Text);

            customer1.custBMI = BMIFormula(customer1.weightLbs, customer1.heightInches);

            string yourBMIStatus = "NA";
            customer1.statusTitle = yourBMIStatus;

            //MessageBox.Show($"The Customer's name is {customer1.firstName} {customer1.lastName} and they can be reached at {customer1.phoneNumber}. They are {customer1.heightInches} inches tall. Their weight is {customer1.weightLbs}. Their BMI is {customer1.custBMI}");

            xYourBMIResults.Text = $"{customer1.custBMI}";

            if (customer1.custBMI < 18.5)
            {
                xBMIMessage.Text = "According to CDC.gov BMI Calculator you are underweight.";
                customer1.statusTitle = "Underweight";
            }
            else if (customer1.custBMI < 24.9)
            {
                xBMIMessage.Text = "According to CDC.gov BMI Calculator you have a normal body weight.";
                customer1.statusTitle = "Normal";
            }
            else if (customer1.custBMI < 29.9)
            {
                xBMIMessage.Text = "According to CDC.gov BMI Calculator you are overweight.";
                customer1.statusTitle = "Overweight";
            }
            else
            {
                xBMIMessage.Text = "According to CDC.gov BMI Calculator you are obese.";
                customer1.statusTitle = "Obese";
            }
        }

        public int BMIFormula(int weight, int height)
        {
            int bmi;
            bmi = 703 * weight / (height * height);
            return bmi;
        }
    }
}

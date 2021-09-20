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
using Time_Management;

namespace semester_planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeManagement i = new TimeManagement();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtCode.Clear();
            txtName.Clear();
            txtHours.Clear();
            txtCredits.Clear();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Info_Output.Items.Clear();
            Info_Output.Items.Add("Course Information");
            Info_Output.Items.Add("--------------------------------");
            for (int x = 0; x < i.getCounnter(); x++)
            {
                Info_Output.Items.Add("Course: " + i.getModuleCode(x));
                Info_Output.Items.Add("Code: " + i.getModuleName(x));
                Info_Output.Items.Add("No of credits: " + i.getModuleCredits(x));
                Info_Output.Items.Add("Class hours(p/w): " + i.getHoursPerWeek(x) + "Hours");
                Info_Output.Items.Add("--------------------------------");
            }

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (txtCourse.Text == "" || txtNumOfWeeks.Text == "" || txtHoursStud.Text == "")
            {
                MessageBox.Show("Please enter the correct values" +
                     "\n" + "-No Leaving the textbox empty");
            }
            double numberOfDays = i.getNumberOfWeeks() * 7;
            i.setNumberOFWeeks(Convert.ToInt32(txtNumOfWeeks.Text));
            i.setSemesterDate(Convert.ToDateTime(dpSemesterStartDate.SelectedDate));
            SelfStudyOutput.Items.Clear();
            SelfStudyOutput.Items.Add("Course Management");
            for (int x = 0; x < i.getCounnter(); x++)
            {
                SelfStudyOutput.Items.Add("Code: " + i.getModuleCode(x));
                SelfStudyOutput.Items.Add("Course: " + i.getModuleName(x));
                SelfStudyOutput.Items.Add("No of Credits: " + i.getModuleCredits(x));
                SelfStudyOutput.Items.Add("Class hours: " + i.getHoursPerWeek(x) + "Hours");

            }
            SelfStudyOutput.Items.Add("");
            SelfStudyOutput.Items.Add("SELF STUDY HOURS REQUIRED");
            SelfStudyOutput.Items.Add("-----------------------------");
            for (int x = 0; x < i.getCounnter(); x++)
            {

                double HoursCalc = ((Convert.ToDouble(i.getModuleCredits(x)) * 10 / Convert.ToDouble(i.getNumberOfWeeks()) -
                    Convert.ToDouble(i.getHoursPerWeek(x))));
                if (HoursCalc > 0)
                {
                    SelfStudyOutput.Items.Add("Self Study Hours Required" + HoursCalc + "Hours");
                }
                else
                {
                    SelfStudyOutput.Items.Add("Self Study Hours Required:No need to Study");
                }
                SelfStudyOutput.Items.Add("---------------------------------------------------");
            }
            SelfStudyOutput.Items.Add("");
            SelfStudyOutput.Items.Add("Semester Information");
            SelfStudyOutput.Items.Add("---------------------------------------------------");
            SelfStudyOutput.Items.Add("Number of Days in Semester:" + numberOfDays);
            SelfStudyOutput.Items.Add("Semester start Date:" + i.getStartDate());
            SelfStudyOutput.Items.Add("Semester End Date: " + i.getSemesterEndDate());
            SelfStudyOutput.Items.Add("---------------------------------------------------");
        }

        private void btnCalculate1_Click(object sender, RoutedEventArgs e)
        {
            double numberOfDays = i.getNumberOfWeeks() * 7;
            i.setSemsterEndDdate(i.getStartDate().AddDays(numberOfDays));
            i.setDateStudied(Convert.ToDateTime(dpSemesterStartDate.SelectedDate));
            i.setHoursWorked(Convert.ToDouble(txtHoursStud.Text));
            FinalOutput.Items.Clear();
            FinalOutput.Items.Add("Course Management");
            FinalOutput.Items.Add("------------------------------------");
            for (int x = 0; x < i.getCounnter(); x++)
            {
                FinalOutput.Items.Add("Code: " + i.getModuleCode(x));
                FinalOutput.Items.Add("Course: " + i.getModuleName(x));
                FinalOutput.Items.Add("No of Credits: " + i.getModuleCredits(x));
                FinalOutput.Items.Add("Class hours: " + i.getHoursPerWeek(x) + "Hours");
                FinalOutput.Items.Add("------------------------------------");
            }
            if (i.getDateStudied() >= i.getStartDate() && i.getDateStudied() <= i.getSemesterEndDate())
            {
                for (int x = 0; x < i.getCounnter(); x++)
                {
                    double RemainingHourCal = (Convert.ToDouble(i.getModuleCredits(x)) * 10 / Convert.ToDouble(i.getNumberOfWeeks()) -
                        Convert.ToDouble(i.getHoursPerWeek(x)) - i.getHoursWorked());

                    FinalOutput.Items.Add("Week in Month:" + i.getWeekNumberofMonth());
                    FinalOutput.Items.Add("Module Code: " + i.getModuleCode(x));
                    FinalOutput.Items.Add("Self Study Hours Remaining: " + RemainingHourCal);
                }
                FinalOutput.Items.Add("--------------------------------------");
            }
            else
            {
                MessageBox.Show("An invalid date has been chosen, please Select a valid date");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String ModuleCode = txtCode.Text;
            String ModuleName = txtName.Text;
            int ModuleCredits = Convert.ToInt32(txtCredits.Text);
            double HoursPerWeek = Convert.ToDouble(txtHours.Text);
            if (i.addToArray(ModuleName, ModuleCode, ModuleCredits, HoursPerWeek) == false)
            {
                MessageBox.Show("The number of modules you would like to enter has been exceeded.");
            }
            else
            {
                MessageBox.Show("Your Module information has been added");
            }
        }

        private void txtCount_Click(object sender, RoutedEventArgs e)
        {
            if (txtAmtModules.Text == "" )
            {
                MessageBox.Show("Please enter the correct values" +
                     "\n" + "-No Leaving the textbox empty");
            }
            i.setArray(Convert.ToInt32(txtAmtModules.Text));
            MessageBox.Show("Please Proceed to enter Module Information");
            txtAmtModules.Clear();
        }

        private void FinalOutput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtNumOfWeeks_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Info_Output.Items.Clear();
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            txtCourse.Clear();
            txtNumOfWeeks.Clear();
            txtHoursStud.Clear();
        }

        private void btnClear1_Click(object sender, RoutedEventArgs e)
        {
            FinalOutput.Items.Clear();
                
        }
    }
}

using AutoMapper;
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
using System.Windows.Shapes;
using TimeSheet.Maper;
using TimeSheet.Repository;
using TimeSheet.Repository.DTOs;
using TimeSheet.Service;

namespace TimeSheet
{
    /// <summary>
    /// Interaction logic for TimeWindow.xaml
    /// </summary>
    public partial class TimeWindow : Window
    {
        TimeSheetEntryDbContext context;

        IMapper mapper;

        TimeSheetEntryService timeSheetEntryService;

        List<TimeSheetEntryDTO> sheet;

        public TimeWindow()
        {
            var mapperconfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            mapper = mapperconfig.CreateMapper();
            context = new TimeSheetEntryDbContext();
            

            timeSheetEntryService = new TimeSheetEntryService(mapper, context);

            sheet = new List<TimeSheetEntryDTO>();
            
            InitializeComponent();

            InicialazeTimeSheet();
        }

        public void InicialazeTimeSheet() {
            sheet = timeSheetEntryService.GetAll();
            LbMounth.Content = DateTime.Now.Month;
            if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) < 31)
            {   
                lbH31.Visibility = Visibility.Hidden;
                lbD31.Visibility = Visibility.Hidden;
                LbDay_31.Visibility = Visibility.Hidden;
            }
            if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) < 30)
            {
                lbH30.Visibility = Visibility.Hidden;
                lbD30.Visibility = Visibility.Hidden;
                LbDay_30.Visibility = Visibility.Hidden;
            }
            if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) < 29)
            {
                lbH29.Visibility = Visibility.Hidden;
                lbD29.Visibility = Visibility.Hidden;
                LbDay_29.Visibility = Visibility.Hidden;
            }
            foreach (TimeSheetEntryDTO dto in sheet) {
                switch (dto.Date.Day) 
                {
                    case 1:
                        lbH1.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-01", MainWindow.logedEmploye.Id);
                        break;
                    case 2:
                        lbH2.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0" + LbMounth.Content + "-02", MainWindow.logedEmploye.Id);
                        break;
                    case 3:
                        lbH3.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-03", MainWindow.logedEmploye.Id);
                        break;
                    case 4:
                        lbH4.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-04", MainWindow.logedEmploye.Id);
                        break;
                    case 5:
                        lbH5.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-05", MainWindow.logedEmploye.Id);
                        break;
                    case 6:
                        lbH6.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-06", MainWindow.logedEmploye.Id );
                        break;
                    case 7:
                        lbH7.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-07", MainWindow.logedEmploye.Id);
                        break;
                    case 8:
                        lbH8.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-08", MainWindow.logedEmploye.Id);
                        break;
                    case 9:
                        lbH10.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-09", MainWindow.logedEmploye.Id);
                        break;
                    case 10:
                        lbH10.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-10", MainWindow.logedEmploye.Id);
                        break;
                    case 11:
                        lbH11.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-11", MainWindow.logedEmploye.Id);
                        break;
                    case 12:
                        lbH12.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-12", MainWindow.logedEmploye.Id);
                        break;
                    case 13:
                        lbH13.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-13", MainWindow.logedEmploye.Id);
                        break;
                    case 14:
                        lbH14.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-14", MainWindow.logedEmploye.Id);
                        break;
                    case 15:
                        lbH15.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-15", MainWindow.logedEmploye.Id);
                        break;
                    case 16:
                        lbH16.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-16", MainWindow.logedEmploye.Id);
                        break;
                    case 17:
                        lbH17.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-17", MainWindow.logedEmploye.Id);
                        break;
                    case 18:
                        lbH18.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-18", MainWindow.logedEmploye.Id);
                        break;
                    case 19:
                        lbH19.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-19", MainWindow.logedEmploye.Id);
                        break;
                    case 20:
                        lbH20.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-20", MainWindow.logedEmploye.Id);
                        break;
                    case 21:
                        lbH21.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-21", MainWindow.logedEmploye.Id);
                        break;
                    case 22:
                        lbH22.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-22", MainWindow.logedEmploye.Id);
                        break;
                    case 23:
                        lbH23.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-23", MainWindow.logedEmploye.Id);
                        break;
                    case 24:
                        lbH24.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-24", MainWindow.logedEmploye.Id);
                        break;
                    case 25:
                        lbH25.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-25", MainWindow.logedEmploye.Id);
                        break;
                    case 26:
                        lbH26.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-26", MainWindow.logedEmploye.Id);
                        break;
                    case 27:
                        lbH27.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-27", MainWindow.logedEmploye.Id);
                        break;
                    case 28:
                        lbH28.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-28", MainWindow.logedEmploye.Id);
                        break;
                    case 29:
                        lbH29.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-29", MainWindow.logedEmploye.Id);
                        break;
                    case 30:
                        lbH30.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-30", MainWindow.logedEmploye.Id);
                        break;
                    case 31:
                        lbH31.Content = "Hours: " + timeSheetEntryService.GetHoursForDate("2022-0"+LbMounth.Content+"-31", MainWindow.logedEmploye.Id);
                        break;
                }
            }
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow w = new EmployeeWindow();
            w.Show();
            this.Close();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            ClienWindow w = new ClienWindow();
            w.Show();
            this.Close();
        }

        private void btnProject_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow w = new ProjectWindow();
            w.Show();
            this.Close();
        }

        private void AllDays_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lb = (Label)sender;

            string[] pom = lb.Name.Split('_');
            if ((int)LbMounth.Content < 10 && Int32.Parse(pom[1]) < 10)
            {
                Upis w = new Upis("2022-0" + LbMounth.Content + "-0" + pom[1]);
                w.Show();
            }
            else if ((int)LbMounth.Content < 10 && Int32.Parse(pom[1]) > 10)
            {
                Upis w = new Upis("2022-0" + LbMounth.Content + "-" + pom[1]);
                w.Show();
            }
            else if ((int)LbMounth.Content > 10 && Int32.Parse(pom[1]) < 10)
            {
                Upis w = new Upis("2022-" + LbMounth.Content + "-0" + pom[1]);
                w.Show();
            }
            else {
                Upis w = new Upis("2022-" + LbMounth.Content + "-" + pom[1]);
                w.Show();
            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<TimeSheetEntryDTO> pom = timeSheetEntryService.GetSalaryEmployee(MainWindow.logedEmploye.Id);
            double ret = 0;

            foreach (TimeSheetEntryDTO dto in pom ) {
                if (dto.OwertimeType == "CESUAL")
                {
                    ret += (float)(dto.Hours * dto.Employee.MoneyPerHouse);
                }
                else if (dto.OwertimeType == "OWERTIME")
                {
                    ret += (float)(dto.Hours * dto.Employee.MoneyPerHouse * 2);
                }
                else
                {
                    ret += (float)(dto.Hours * dto.Employee.MoneyPerHouse * 0.75);
                }
            }

            salary.Content = ret;
        }
    }
}

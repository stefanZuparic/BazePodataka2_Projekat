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
            foreach (TimeSheetEntryDTO dto in sheet) {
                switch (dto.Date.Day) 
                {
                    case 1:
                        lbH1.Content = "Hours: " + dto.Hours;
                        break;
                    case 2:
                        lbH2.Content = "Hours: " + dto.Hours;
                        break;
                    case 3:
                        lbH3.Content = "Hours: " + dto.Hours;
                        break;
                    case 4:
                        lbH4.Content = "Hours: " + dto.Hours;
                        break;
                    case 5:
                        lbH5.Content = "Hours: " + dto.Hours;
                        break;
                    case 6:
                        lbH6.Content = "Hours: " + dto.Hours;
                        break;
                    case 7:
                        lbH7.Content = "Hours: " + dto.Hours;
                        break;
                    case 8:
                        lbH8.Content = "Hours: " + dto.Hours;
                        break;
                    case 9:
                        lbH10.Content = "Hours: " + dto.Hours;
                        break;
                    case 10:
                        lbH10.Content = "Hours: " + dto.Hours;
                        break;
                    case 11:
                        lbH11.Content = "Hours: " + dto.Hours;
                        break;
                    case 12:
                        lbH12.Content = "Hours: " + dto.Hours;
                        break;
                    case 13:
                        lbH13.Content = "Hours: " + dto.Hours;
                        break;
                    case 14:
                        lbH14.Content = "Hours: " + dto.Hours;
                        break;
                    case 15:
                        lbH15.Content = "Hours: " + dto.Hours;
                        break;
                    case 16:
                        lbH16.Content = "Hours: " + dto.Hours;
                        break;
                    case 17:
                        lbH17.Content = "Hours: " + dto.Hours;
                        break;
                    case 18:
                        lbH18.Content = "Hours: " + dto.Hours;
                        break;
                    case 19:
                        lbH19.Content = "Hours: " + dto.Hours;
                        break;
                    case 20:
                        lbH20.Content = "Hours: " + dto.Hours;
                        break;
                    case 21:
                        lbH21.Content = "Hours: " + dto.Hours;
                        break;
                    case 22:
                        lbH22.Content = "Hours: " + dto.Hours;
                        break;
                    case 23:
                        lbH23.Content = "Hours: " + dto.Hours;
                        break;
                    case 24:
                        lbH24.Content = "Hours: " + dto.Hours;
                        break;
                    case 25:
                        lbH25.Content = "Hours: " + dto.Hours;
                        break;
                    case 26:
                        lbH26.Content = "Hours: " + dto.Hours;
                        break;
                    case 27:
                        lbH27.Content = "Hours: " + dto.Hours;
                        break;
                    case 28:
                        lbH28.Content = "Hours: " + dto.Hours;
                        break;
                    case 29:
                        lbH29.Content = "Hours: " + dto.Hours;
                        break;
                    case 30:
                        lbH30.Content = "Hours: " + dto.Hours;
                        break;
                    case 31:
                        lbH31.Content = "Hours: " + dto.Hours;
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

            Upis w = new Upis("2022-0"+LbMounth.Content+"-"+pom[1]);
            w.Show();
            this.Close();
        }
    }
}

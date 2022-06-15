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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeSheet.Maper;
using TimeSheet.Repository;
using TimeSheet.Repository.DTOs;
using TimeSheet.Service;

namespace TimeSheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeSheetEntryDbContext context;
        IMapper mapper;

        public static EmployeeDTO logedEmploye;
        EmployeeService service;
        public MainWindow()
        {
            var mapperconfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            mapper = mapperconfig.CreateMapper();

            context = new TimeSheetEntryDbContext();

            service = new EmployeeService(mapper, context);

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logedEmploye = service.GetByMail(txtEmail.Text);

            if (logedEmploye.Password == txtPassword.Password)
            {
                TimeWindow w = new TimeWindow();
                w.Show();
                this.Close();
            }

        }
    }
}

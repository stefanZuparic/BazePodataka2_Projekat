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
using TimeSheet.Repository.Models;
using TimeSheet.Service;

namespace TimeSheet
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        TimeSheetEntryDbContext context;

        IMapper mapper;

        EmployeeService service;
        TechnologyService technologyService;

        List<EmployeeDTO> employees;
        List<EmployeeDataGreadDTO> employeesView;

        List<Technology> technologys;
        public EmployeeWindow()
        {
            var mapperconfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            mapper = mapperconfig.CreateMapper();

            context = new TimeSheetEntryDbContext();

            service = new EmployeeService(mapper, context);
            technologyService = new TechnologyService(mapper, context);

            employees = new List<EmployeeDTO>();
            employees = service.GetAll();
            technologys = new List<Technology>();


            
            InitializeComponent();
            
            employeesView = MapEmployeeDTOonEmployeeDataGreadDTO(employees);
            this.listEmployee.ItemsSource = employeesView;
            cmbTech.ItemsSource = technologyService.GetAll();
        }

        private List<EmployeeDataGreadDTO> MapEmployeeDTOonEmployeeDataGreadDTO(List<EmployeeDTO> employees)
        {
            List<EmployeeDataGreadDTO> ret = new List<EmployeeDataGreadDTO>();
            foreach (EmployeeDTO e in employees) {
                EmployeeDataGreadDTO e1 = new EmployeeDataGreadDTO() {
                    Id = e.Id,
                    Name = e.Name,
                    Address = e.Address,
                    Phone = e.Phone,
                    Email = e.Email,
                    IsActive = e.IsActive == 1 ? true : false,
                    
                };
                ret.Add(e1);
            }
            return ret;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int money=0, phone=0;
            if (txtName.Text != String.Empty && txtAddress.Text != String.Empty && txtEmail.Text != String.Empty && txtPhone.Text != String.Empty && txtPassword.Text != String.Empty && txtMoney.Text != String.Empty) 
            {
                if (Int32.TryParse(txtPhone.Text, out phone) && Int32.TryParse(txtMoney.Text, out money)) {
                    EmployeeDTO employeeDTO = new EmployeeDTO()
                    {
                        Name = txtName.Text,
                        Address = txtAddress.Text,
                        Phone = phone,
                        MoneyPerHouse = money,
                        Email = txtEmail.Text,
                        Role = txtRole.Text,
                        Password = txtPassword.Text,
                        IsActive = 1,
                        HoursPerWeek = 0
                    };
                    Employee employee = service.Create(employeeDTO);

                    foreach (Technology t in technologys)
                    {
                        EmployeeTechnologyDTO technologyDTO = new EmployeeTechnologyDTO()
                        {
                            EmployeeId = employee.Id,
                            TechnologyId = t.Id,
                            LevelOfExperience = cmbLvl.Text,
                        };
                        technologyService.Create(technologyDTO);
                    }
                    
                }
            }
        }

        private void RemoveEmplyee_Click(object sender, RoutedEventArgs e)
        {
            if (listEmployee.SelectedIndex >= 0) {
                EmployeeDataGreadDTO remove = (EmployeeDataGreadDTO)listEmployee.SelectedItem;
                service.DeleteByMale(remove.Email);
            }
        }

        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            TimeWindow w = new TimeWindow();
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

        private void chk_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            Technology tech = (Technology)box.DataContext;
            technologys.Add(tech);
        }

        private void chk_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            Technology tech = (Technology)box.DataContext;
            technologys.Remove(tech);
        }
    }
}

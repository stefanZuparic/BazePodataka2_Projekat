using AutoMapper;
using System;
using System.Collections;
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
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        TimeSheetEntryDbContext context;

        IMapper mapper;

        ProjectService service;
        ClientService clientService;
        EmployeeService employeeService;
        TechnologyService technologyService;
        TimeSheetEntryService tS;

        List<ProjectDTO> projects;
        List<ClientDTO> clients;

        List<Employee> employeis;
        List<EmployeeDTO> leaders;

        public ProjectWindow()
        {
            var mapperconfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            mapper = mapperconfig.CreateMapper();

            context = new TimeSheetEntryDbContext();

            service = new ProjectService(mapper, context);
            clientService = new ClientService(mapper, context);
            employeeService = new EmployeeService(mapper, context);
            technologyService = new TechnologyService(mapper,context);
            tS = new TimeSheetEntryService(mapper,context);

            projects = service.GetAll();
            employeis = employeeService.GetAllEmployee();
            leaders = new List<EmployeeDTO>();

            InitializeComponent();

            if (MainWindow.logedEmploye.Role != "Admin")
            {
                listProjects.Columns[6].Visibility = Visibility.Hidden;
            }

            listProjects.ItemsSource =MapForGrid();
            cmbLiders.ItemsSource = employeeService.GetAll();
            cmbClient.ItemsSource = GetAllClientName();
        }

        private List<ProjectGreadDTO> MapForGrid() {

            List<ProjectGreadDTO> ret = new List<ProjectGreadDTO>();

            foreach (ProjectDTO dto in projects) {
                ProjectGreadDTO gdto = new ProjectGreadDTO() {
                    Name = dto.Name,
                    Description = dto.Description,
                    IsActive =  dto.IsActive,
                    Clinet = dto.Clinet,
                    ClinetId = dto.ClinetId,
                    Id = dto.Id,
                    LeadershipName = new List<string>(),
                    UkupnoSatiNaProjektu = IzracunajUkuonoSati(dto.Id)
                };

                foreach (Leadership ldto in dto.Leadership) {
                    gdto.LeadershipName.Add(ldto.Employee.Name);
                }
                ret.Add(gdto);
            }

            return ret;
        }

        public float IzracunajUkuonoSati(int id) {
            List<TimeSheetEntryDTO> pom = tS.GetAllEntryForProjectId(id);
            float ret = 0;

            foreach (TimeSheetEntryDTO dto in pom) {
                if (dto.OwertimeType == "CESUAL")
                {
                    ret += (float)(dto.Hours);
                }
                else if (dto.OwertimeType == "OWERTIME")
                {
                    ret += (float)(dto.Hours);
                }
                else 
                {
                    ret += (float)(dto.Hours);
                }
            }

            return ret;
        }

        private IEnumerable GetAllClientName()
        {
            List<string> ret = new List<string>();
            clients = clientService.GetAll();

            foreach (ClientDTO c in clients) {
                ret.Add(c.Name);
            }

            return ret;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != String.Empty && cmbClient.SelectedIndex != -1)
            {
                ProjectDTO projectDTO = new ProjectDTO()
                {
                    Name = txtName.Text,
                    Description = txtDec.Text,
                    Clinet = clientService.GetByIdClient(clients[cmbClient.SelectedIndex].Id),
                    ClinetId = clients[cmbClient.SelectedIndex].Id,
                    TimeSheetEntry = new List<TimeSheetEntry>(),
                    IsActive = "YES"
                };
                Project project = service.Create(projectDTO);

                foreach (EmployeeDTO dto in leaders) {
                    LeadershipDTO l = new LeadershipDTO()
                    {
                        EmployeeId = dto.Id,
                        ProjectId = project.Id,
                    };
                    technologyService.CreateLeaders(l);
                }

                projects = service.GetAll();
                listProjects.ItemsSource = MapForGrid();
                listProjects.Items.Refresh();
            }
        }

        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            TimeWindow w = new TimeWindow();
            w.Show();
            this.Close();
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

        private void chkLiders_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            EmployeeDTO pom = (EmployeeDTO)cb.DataContext;
            leaders.Add(pom);

        }

        private void chkLiders_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            EmployeeDTO pom = (EmployeeDTO)cb.DataContext;
            leaders.Remove(pom);
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            ProjectDTO dto = projects[listProjects.SelectedIndex];

            if (dto.IsActive == "YES")
            {
                service.UpdateActivity(false, dto.Id);
            }
            else 
            {
                service.UpdateActivity(true, dto.Id);
            }
            projects = service.GetAll();
            listProjects.ItemsSource = MapForGrid();
            listProjects.Items.Refresh();
        }
    }
}

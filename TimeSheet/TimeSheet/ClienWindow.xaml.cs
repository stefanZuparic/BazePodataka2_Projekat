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
    /// Interaction logic for ClienWindow.xaml
    /// </summary>
    public partial class ClienWindow : Window
    {
        TimeSheetEntryDbContext context;
        IMapper mapper;

        ClientService service;
        ProjectService projectService;

        List<ClientDTO> clients;
        List<ClientDataGreadDTO> clientsGread;

        public ClienWindow()
        {
            var mapperconfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            mapper = mapperconfig.CreateMapper();

            context = new TimeSheetEntryDbContext();

            service = new ClientService(mapper, context);
            projectService = new ProjectService(mapper, context);

            clients = service.GetAll();
            GetProjectForAllClients();

            clientsGread = MapClientDTOOnClientDataGreadDTO(clients);

            InitializeComponent();
            listClients.ItemsSource = clientsGread;
        }

        private List<ClientDataGreadDTO> MapClientDTOOnClientDataGreadDTO(List<ClientDTO> clients)
        {
            List<ClientDataGreadDTO> ret = new List<ClientDataGreadDTO>();

            foreach (ClientDTO c in clients) {
                ClientDataGreadDTO newC = new ClientDataGreadDTO() {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    IsActive = c.IsActive,
                    Project = new List<string>()
                };

                foreach (Project p in c.Project) {
                    newC.Project.Add(p.Name);
                }
                ret.Add(newC);
            }
            return ret;
        }

        private void GetProjectForAllClients()
        {
            foreach (ClientDTO c in clients) {
                c.Project = projectService.GetByClientId(c.Id);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != String.Empty && txtAddress.Text != String.Empty)
            {
                ClientDTO clientDTO = new ClientDTO()
                {
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    IsActive = "YES",
                    Project = new List<Project>()
                };
                service.Create(clientDTO);

                clients = service.GetAll();
                GetProjectForAllClients();

                clientsGread = MapClientDTOOnClientDataGreadDTO(clients);

                listClients.ItemsSource = clientsGread;
                listClients.Items.Refresh();
            }
        }

        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            TimeWindow w = new TimeWindow();
            w.Show();
            this.Close();
        }

        private void btnProject_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow w = new ProjectWindow();
            w.Show();
            this.Close();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow w = new EmployeeWindow();
            w.Show();
            this.Close();
        }
    }
}

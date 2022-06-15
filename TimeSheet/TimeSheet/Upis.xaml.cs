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
    /// Interaction logic for Upis.xaml
    /// </summary>
    public partial class Upis : Window
    {
        TimeSheetEntryDbContext context;

        IMapper mapper;

        TimeSheetEntryService service;
        ProjectService projectService;
        TechnologyService technologyService;

        List<ProjectDTO> projects;
        List<BranchOfficeDTO> office;
        string[] pom;
        public Upis(string date)
        {
            var mapperconfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            mapper = mapperconfig.CreateMapper();

            context = new TimeSheetEntryDbContext();

            service = new TimeSheetEntryService(mapper, context);
            projectService = new ProjectService(mapper, context);
            technologyService = new TechnologyService(mapper, context);

            projects = projectService.GetAll();
            office = technologyService.GetAllOffice();

            InitializeComponent();

            cmbBranchOfice.ItemsSource = GetOfficeName();
            cmbProject.ItemsSource = GetPrName();
            grid.ItemsSource = service.GetForDate(date);

            pom = date.Split('-');
        }

        private IEnumerable GetPrName()
        {
            List<string> ret = new List<string>();

            foreach (ProjectDTO dto in projects) {
                ret.Add(dto.Name);
            }
            return ret;
        }

        private IEnumerable GetOfficeName()
        {
            List<string> ret = new List<string>();

            foreach (BranchOfficeDTO dto in office)
            {
                ret.Add(dto.Name);
            }
            return ret;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float hours=0;
            
            if (cmbBranchOfice.SelectedIndex != -1 && cmbOwertime.SelectedIndex != -1 && cmbProject.SelectedIndex != -1 && txtH.Text != String.Empty && txtD.Text != String.Empty) {
                if (float.TryParse(txtH.Text, out hours)) {
                    TimeSheetEntryDTO dto = new TimeSheetEntryDTO()
                    {
                        ProjectId = projects[cmbProject.SelectedIndex].Id,
                        EmployeeId = 1,
                        BranchOfficeId = office[cmbBranchOfice.SelectedIndex].Id,
                        Date = new DateTime(Int32.Parse(pom[0]), Int32.Parse(pom[1]), Int32.Parse(pom[2])),
                        Description = txtD.Text,
                        Hours = hours,
                        OwertimeType = cmbOwertime.Text
                    };
                    service.Create(dto);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TimeWindow w = new TimeWindow();
            w.Show();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedIndex != -1) {
                TimeSheetEntryDTO del = (TimeSheetEntryDTO)grid.SelectedItem;
                service.DeleteById(del.Id);
            }
        }
    }
}

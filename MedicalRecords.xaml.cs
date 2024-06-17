using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using КурсоваяРабота.Context;
using КурсоваяРабота.Models;

namespace КурсоваяРабота
{
    public partial class MedicalRecords : UserControl
    {
        public ObservableCollection<Medicalrecord> MedicalRecordsCollection { get; set; }
        private User _user;

        public MedicalRecords()
        {
            InitializeComponent();

            using (var context = new PolyclinicContext())
            {
                var medicalRecordsList = context.Medicalrecords
                    .Include(m => m.Appointment)
                    .Include(m => m.Doctor).ToList();

                MedicalRecordsCollection = new ObservableCollection<Medicalrecord>(medicalRecordsList);
            }

            DataContext = this;
        }
    }
}

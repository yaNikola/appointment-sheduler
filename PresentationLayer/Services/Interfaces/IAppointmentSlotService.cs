using PresentationLayer.Models.Edit;
using PresentationLayer.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services.Interfaces
{
    public interface IAppointmentSlotService
    {
        public List<AppointmentSlotViewModel> GetAllSlotViewModels();
        public AppointmentSlotViewModel GetSlotViewModel(int eventId);
        public AppointmentSlotEditModel GetSlotEditModel(int eventId = 0);
        public AppointmentSlotViewModel SaveSlotEditModelToDb(AppointmentSlotEditModel slotEditModel);
        public AppointmentSlotEditModel CreateSlotEditModel();
    }
}

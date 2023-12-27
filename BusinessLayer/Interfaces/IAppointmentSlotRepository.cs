using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Interfaces
{
    public interface IAppointmentSlotRepository
    {
        IEnumerable<AppointmentSlot> GetAll();
        AppointmentSlot GetSlotById(int slotId);
        public List<AppointmentSlot> GetSlotByArrId(int[] arr);
        public int[] GetIdByListOfSlots(List<AppointmentSlot> slots);
        void SaveSlot(AppointmentSlot _slot);
        void DeleteSlot(AppointmentSlot _slot);

    }
}

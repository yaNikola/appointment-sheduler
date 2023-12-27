using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class AppointmentSlotRepository : IAppointmentSlotRepository
    {
        private SchedulerDbContext context;

        public AppointmentSlotRepository(SchedulerDbContext context)
        {
            this.context = context;
        }

        public void DeleteSlot(AppointmentSlot _slot)
        {
            context.Appointments.Remove(_slot);
            context.SaveChanges();
        }

        public IEnumerable<AppointmentSlot> GetAll()
        {
            return context.Appointments.AsNoTracking().ToList();
        }

        public AppointmentSlot GetSlotById(int slotId)
        {
            return context.Appointments.AsNoTracking().FirstOrDefault<AppointmentSlot>(x =>
            x.Id == slotId);
        }

        public List<AppointmentSlot> GetSlotByArrId(int[] arr)
        {
            var _slots = new List<AppointmentSlot>();
            foreach (var item in arr)
            {
                _slots.Add(GetSlotById(item));
            }

            return _slots;
        }

        public int[] GetIdByListOfSlots(List<AppointmentSlot> slots)
        {
            var idArr = new int[slots.Count];
            for (int i = 0; i < slots.Count; i++)
            {
                idArr[i] = slots[i].Id;
            }

            return idArr;
        }

        public void SaveSlot(AppointmentSlot _slot)
        {
            if (_slot.Id == 0)
            {
                context.Appointments.Add(_slot);
            }
            else
            {
                context.Entry(_slot).State = EntityState.Modified;
            }

            context.SaveChanges();
        }
    }
}

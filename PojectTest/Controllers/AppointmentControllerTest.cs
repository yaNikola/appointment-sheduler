using BusinessLayer.Implementations;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojectTest.Controllers
{
    public class AppointmentControllerTest : TestCommandBase
    {
        [Fact]
        public async Task GetAppointments_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var slotAct = new AppointmentSlot
            {
                Id = 1,
                Start = new DateTime(2023, 12, 13),
                End = new DateTime(2023, 12, 14),
                Description = "this description",
                OrganizerName = "me",
                ParticipantName = "me",
                Name = "Slot1",
                Status = "free"
            };

            var listAct = new List<AppointmentSlot> { slotAct };

            var listAssert = slotRepo.GetAll();

            /* Assert.Equal<AppointmentSlot>(listAct, listAssert);*/

        }

        [Fact]
        public async Task PutAppointmentSlot_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var slotAct = new AppointmentSlot
            {
                Id = 1,
                Start = new DateTime(2023, 12, 13),
                End = new DateTime(2023, 12, 14),
                Description = "this description",
                OrganizerName = "me",
                ParticipantName = "me",
                Name = "Slot1",
                Status = "free"
            };

            var listAct = new List<AppointmentSlot> { slotAct };

            var listAssert = slotRepo.GetAll();

            /* Assert.Equal<AppointmentSlot>(listAct, listAssert);*/

        }

        [Fact]
        public async Task PutAppointmentSlotRequest_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var slotAct = new AppointmentSlot
            {
                Id = 1,
                Start = new DateTime(2023, 12, 13),
                End = new DateTime(2023, 12, 14),
                Description = "this description",
                OrganizerName = "me",
                ParticipantName = "me",
                Name = "Slot1",
                Status = "free"
            };

            var listAct = new List<AppointmentSlot> { slotAct };

            var listAssert = slotRepo.GetAll();

            /* Assert.Equal<AppointmentSlot>(listAct, listAssert);*/

        }

        [Fact]
        public async Task PostAppointmentSlot_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var slotAct = new AppointmentSlot
            {
                Id = 1,
                Start = new DateTime(2023, 12, 13),
                End = new DateTime(2023, 12, 14),
                Description = "this description",
                OrganizerName = "me",
                ParticipantName = "me",
                Name = "Slot1",
                Status = "free"
            };

            var listAct = new List<AppointmentSlot> { slotAct };

            var listAssert = slotRepo.GetAll();

            /* Assert.Equal<AppointmentSlot>(listAct, listAssert);*/

        }
    }
}

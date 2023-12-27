using BusinessLayer;
using BusinessLayer.Implementations;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojectTest.Slots.Commands
{
    public class CreateSlotCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetAllSlots_Success()
        {
            //секція підготовки
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

            //секція дії
            var listAssert = slotRepo.GetAll();

            //секція перевірки
            Assert.Equal<AppointmentSlot>(listAct, listAssert);

        }

        [Fact]
        public async Task DeleteSlot_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);
            AppointmentSlot act = null;

            var slot = slotRepo.GetSlotById(1);
            slotRepo.DeleteSlot(slot);

            var assert = slotRepo.GetSlotById(1);

            Assert.Equal(act, assert);
        }

        [Fact]
        public async Task GetSlotById_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var act = new AppointmentSlot
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


            var assert = slotRepo.GetSlotById(1);

            Assert.Equal<AppointmentSlot>(act, assert);
        }

        [Fact]
        public async Task GetIdByListOfSlots_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var slot = new AppointmentSlot
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

            var list = new List<AppointmentSlot>();
            list.Add(slot);

            int[] act = { 1 };

            var assert = slotRepo.GetIdByListOfSlots(list);

            Assert.Equal(act, assert);
        }

        [Fact]
        public async Task SaveSlot_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var act = new AppointmentSlot
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


            var assert = slotRepo.GetSlotById(1);

            Assert.Equal<AppointmentSlot>(act, assert);
        }

        [Fact]
        public async Task GetUserById_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var act = new AppointmentSlot
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


            var assert = slotRepo.GetSlotById(1);

            Assert.Equal<AppointmentSlot>(act, assert);
        }

        [Fact]
        public async Task GetUserByLogin_Success()
        {
            var slotRepo = new AppointmentSlotRepository(Context);

            var act = new AppointmentSlot
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


            var assert = slotRepo.GetSlotById(1);

            Assert.Equal<AppointmentSlot>(act, assert);
        }
    }
}

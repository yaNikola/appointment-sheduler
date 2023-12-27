using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojectTest
{
    public class ContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();
        public static SchedulerDbContext Create()
        {
            var optionns = new DbContextOptionsBuilder<SchedulerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new SchedulerDbContext(optionns);
            context.Database.EnsureCreated();
            context.Appointments.AddRange(
                new AppointmentSlot
                {
                    Id = 1,
                    Start = new DateTime(2023, 12, 13),
                    End = new DateTime(2023, 12, 14),
                    Description = "this description",
                    OrganizerName = "me",
                    ParticipantName = "me",
                    Name = "Slot1",
                    Status = "free"
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(SchedulerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

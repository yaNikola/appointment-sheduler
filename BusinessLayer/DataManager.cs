using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DataManager
    {
        private IAppointmentSlotRepository _appointmentRepository;
        private IUserRepository _userRepository;

        public DataManager(IAppointmentSlotRepository appointmentRepository, IUserRepository userRepository)
        {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
        }

        public IAppointmentSlotRepository AppointmentRepository { get { return _appointmentRepository; } }
        public IUserRepository UserRepository { get { return _userRepository; } }
    }
}

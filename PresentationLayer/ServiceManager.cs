using BusinessLayer;
using MeetingPlanner.Services.Implementations;
using PresentationLayer.Services.Interfaces;
using PresentationLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class ServiceManager
    {   
        private DataManager _dataManager;
        private IUserService _userService;
        private IAppointmentSlotService _eventService;
        private IAccountService _accountService;

        public ServiceManager(DataManager dataManager, IUserService userService, IAppointmentSlotService eventService,
            IAccountService accountService)
        {
            _dataManager = dataManager;
            _userService = userService;
            _eventService = eventService;
            _accountService = accountService;
        }

        public IUserService UserService { get { return _userService; } }
        public IAppointmentSlotService EventService { get { return _eventService; } }
        public IAccountService AccountService {  get { return _accountService; } }
    }
}

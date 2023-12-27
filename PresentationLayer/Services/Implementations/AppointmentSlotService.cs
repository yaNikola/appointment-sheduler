using BusinessLayer;
using DataLayer.Entities;
using PresentationLayer.Models.Edit;
using PresentationLayer.Models.View;
using PresentationLayer.Services.Interfaces;

namespace PresentationLayer.Services.Implementations
{
    public class AppointmentSlotService : IAppointmentSlotService
    {
        private DataManager _dataManager;
        public AppointmentSlotService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<AppointmentSlotViewModel> GetAllSlotViewModels()
        {
            var _slots = _dataManager.AppointmentRepository.GetAll();
            var _models = new List<AppointmentSlotViewModel>();

            foreach (var item in _slots)
            {
                _models.Add(GetSlotViewModel(item.Id));
            }

            return _models;
        }

        public AppointmentSlotViewModel GetSlotViewModel(int slotId)
        {
            var _slot = _dataManager.AppointmentRepository.GetSlotById(slotId);

            //створили модельку
            var slotViewModel = new AppointmentSlotViewModel()
            {
                Start = _slot.Start,
                End = _slot.End,
                Name = _slot.Name,
                Description = _slot.Description,
                OrganizerName = _slot.OrganizerName,
                ParticipantName = _slot.ParticipantName,
                Status = _slot.Status
            };

            return slotViewModel;
        }

        public AppointmentSlotEditModel GetSlotEditModel(int slotId = 0)
        {
            var _event = _dataManager.AppointmentRepository.GetSlotById(slotId);


            var _eventEditModel = new AppointmentSlotEditModel()
            {
                Id = _event.Id,
                Start = _event.Start,
                End = _event.End,
                Description = _event.Description,
                OrganizerName = _event.OrganizerName,
                ParticipantName = _event.ParticipantName,
                Name = _event.Name,
                Status = _event.Status
            };
            return _eventEditModel;
        }

        public AppointmentSlotViewModel SaveSlotEditModelToDb(AppointmentSlotEditModel slotEditModel)
        {
            AppointmentSlot _slotDbModel;
            if (slotEditModel.Id != 0)
            {
                _slotDbModel = _dataManager.AppointmentRepository.GetSlotById(slotEditModel.Id);
            }
            else
            {
                _slotDbModel = new AppointmentSlot();
            }

            _slotDbModel.Name = slotEditModel.Name;
            _slotDbModel.Description = slotEditModel.Description;
            _slotDbModel.OrganizerName = slotEditModel.OrganizerName;
            _slotDbModel.ParticipantName = slotEditModel.ParticipantName;
            _slotDbModel.Name = slotEditModel.Name;
            _slotDbModel.PatientId = slotEditModel.PatientId;
            _slotDbModel.Status = slotEditModel.Status;

            _dataManager.AppointmentRepository.SaveSlot(_slotDbModel);

            return GetSlotViewModel(_slotDbModel.Id);
        }

        public AppointmentSlotEditModel CreateSlotEditModel()
        {
            return new AppointmentSlotEditModel();
        }
    }
}

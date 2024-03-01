using AutoMapper;
using TechTrack.Application.Dtos.Equipment;
using TechTrack.Application.Interfaces;
using TechTrack.Domain.Interfaces;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentDto>> GetAllEquipmentsAsync()
        {
            var equipments = await _equipmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EquipmentDto>>(equipments);
        }

        public async Task<EquipmentDto> GetEquipmentByIdAsync(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            return _mapper.Map<EquipmentDto>(equipment);
        }

        public async Task<EquipmentDto> CreateEquipmentAsync(EquipmentForCreationDto equipmentDto)
        {
            var equipment = _mapper.Map<Equipment>(equipmentDto);
            await _equipmentRepository.AddAsync(equipment);
            return _mapper.Map<EquipmentDto>(equipment);
        }

        public async Task UpdateEquipmentAsync(int id, EquipmentForUpdateDto equipmentDto)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment != null)
            {
                _mapper.Map(equipmentDto, equipment);
                await _equipmentRepository.UpdateAsync(equipment);
            }
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            await _equipmentRepository.DeleteAsync(id);
        }
    }
}

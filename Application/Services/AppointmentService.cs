using Application.DTO.Appointment;
using Application.DTO.AppointmentDetails;
using Application.Interfaces.IDbContexts;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain;

namespace Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IClientRepository _clientRepository;
    
    public AppointmentService(IAppointmentRepository appointmentRepository, IClientRepository clientRepository)
    {
        _appointmentRepository = appointmentRepository;
        _clientRepository = clientRepository;
    }
    public async Task<IEnumerable<ResponseAppointmentDTO>> GetAllAsync()
    {
        var appointments = await _appointmentRepository.GetAllAsync();

        var getAllAppointments = appointments.Select(x => new ResponseAppointmentDTO
        {
            Name = x.Name,
            AppointmentDetails = new ResponseAppointmentDetailsDTO
            {
                AppointmentAt = x.AppointmentDetails.AppointmentAt,
                Description = x.AppointmentDetails.Description,
                Price = x.AppointmentDetails.Price
            }
        }).ToList();
        
        return getAllAppointments;
    }

    public async Task<ResponseAppointmentDTO> GetByIdAsync(int id)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(id);

        if (appointment is not null)
        {
            var getAppointment = new ResponseAppointmentDTO
            {
                ClientId = appointment.ClientId,
                Name = appointment.Name,
                AppointmentDetails = new ResponseAppointmentDetailsDTO
                {
                    AppointmentAt = appointment.AppointmentDetails.AppointmentAt,
                    Description = appointment.AppointmentDetails.Description,
                    Price = appointment.AppointmentDetails.Price
                }
            };
            return getAppointment;

        }
        else
        {
            return null;
        }
    }

    public async Task CreateAsync(CreateAppointmentDTO appointmentDto)
    {
        var newAppointment = new Appointment
        {
            ClientId = appointmentDto.ClientId,
            Name =  appointmentDto.Name,
            AppointmentDetails = new AppointmentDetails
            {
                AppointmentAt = DateTime.UtcNow,
                Description = appointmentDto.AppointmentDetails.Description,
                Price = appointmentDto.AppointmentDetails.Price
            }
        };
        await _appointmentRepository.AddAsync(newAppointment);
        await _appointmentRepository.SaveInfo();
    }

    public async Task UpdateAsync(int id, UpdateAppointmentDTO appointmentDto)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(id);

        if (appointment is not null)
        {
            appointment.Name = appointmentDto.Name;
            appointment.AppointmentDetails.Description = appointmentDto.AppointmentDetails.Description;
            appointment.AppointmentDetails.Price = appointmentDto.AppointmentDetails.Price;
            appointment.AppointmentDetails.AppointmentAt = DateTime.UtcNow;

            await _appointmentRepository.UpdateAsync(appointment);
            await _appointmentRepository.SaveInfo();
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _appointmentRepository.DeleteByIdAsync(id);
        await _appointmentRepository.SaveInfo();
    }
}
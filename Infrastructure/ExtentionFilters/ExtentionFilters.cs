
using Application.Filters;
using Domain;

namespace Infrastructure.ExtentionFilters;

public static class ExtentionFilters
{
    public static IQueryable<Client> ApplyFilters(this IQueryable<Client> query, ClientFilter filter)
    {
        if(!string.IsNullOrEmpty(filter.Name))
            query = query.Where(x => x.Name == filter.Name);
        
        if(filter.FromAge is not null)
            query = query.Where(x => x.Age >= filter.FromAge);
        
        if(filter.ToAge is not null)
            query = query.Where(x => x.Age <= filter.ToAge);
        
        return query;
    }

    public static IQueryable<Appointment> ApplyFilters(this IQueryable<Appointment> query, AppointmentFilter filter)
    {
        if (filter.FromDate is not null)
            query = query.Where(x => x.AppointmentDetails.AppointmentAt >= filter.FromDate);
        
        if(filter.ToDate is not null)
            query = query.Where(x => x.AppointmentDetails.AppointmentAt <= filter.ToDate);
        
        if (filter.MinPrice is not null)
            query = query.Where(x => x.AppointmentDetails.Price >= filter.MinPrice);
        
        if(filter.MaxPrice is not null)
            query = query.Where(x => x.AppointmentDetails.Price <= filter.MaxPrice);
        
        return query;
    }
}
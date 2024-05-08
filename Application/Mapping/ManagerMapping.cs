using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class ManagerMapping
    {
        public static ManagerDto AsDto(this Manager manager)
        {
            return new ManagerDto(manager.Id, manager.Name, manager.Subordinates.Select(s => s.AsDto()).ToArray());
        }
    }
}

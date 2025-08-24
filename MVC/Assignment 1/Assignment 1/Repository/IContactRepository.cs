using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.Models;

namespace Assignment_1.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task CreateAsync(Contact contact);
        Task DeleteAsync(long Id);
    }
}

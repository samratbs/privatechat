using PrivateChat.Domains;
using PrivateChat.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Infrastructure.Repository
{
    public interface IChatRepository
    {
        Task SaveMessageToDb(Messages message);
        Task<List<Messages>> GetAllMessages();
    }
}

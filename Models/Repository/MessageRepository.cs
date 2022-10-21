using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models.Repository.Interfaces;

namespace webapp_travel_agency.Models.Repository
{
    public class MessageRepository : IMessageRepo
    {
        private TravelAgencyContext _ctx;
        public MessageRepository(TravelAgencyContext _context)
        {
            _ctx = _context;
        }
        public List<Message> GetList(string includes = "")
        {
            IQueryable<Message> messages = _ctx.Messages;
            if (includes.Trim() != "")
            {
                string[] subIncludes = includes.Split(',');
                foreach (string sub in subIncludes)
                {
                    messages = messages.Include(sub.Trim());
                }
            }
            return messages.ToList();
        }

        public void AddMessage(Message message)
        {
            _ctx.Messages.Add(message);
            this.Save();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}

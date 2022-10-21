namespace webapp_travel_agency.Models.Repository.Interfaces
{
    public interface IMessageRepo
    {
        public List<Message> GetList(string includes = "");
        public void AddMessage(Message message);
        public void Save();
    }
}

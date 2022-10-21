namespace webapp_travel_agency.Models.Repository.Interfaces
{
    public interface IMessageRepo
    {
        public List<Message> GetList(string includes = "");
    }
}

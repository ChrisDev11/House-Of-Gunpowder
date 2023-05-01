namespace HouseofGunpowder.Repositories.Interfaces {
    public interface IEmail {
        bool Send(string email, string subject, string message);
    }
}

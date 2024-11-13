namespace gestionDetteWeb2.Unicite
{
    public interface IClientValidator
    {
        bool IsUniqueTelephone(string telephone);
        bool IsUniqueSurname(string surname);
    }
}

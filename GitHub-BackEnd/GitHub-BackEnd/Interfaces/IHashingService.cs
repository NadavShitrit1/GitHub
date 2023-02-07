namespace GitHub_BackEnd.Interfaces
{
    public interface IHashingService
    {
        public void HashPassword(string password, out byte[] hash, out byte[] salt);
        public bool CheckHashEquality(string password, byte[] userHash, byte[] salt);
    }
}

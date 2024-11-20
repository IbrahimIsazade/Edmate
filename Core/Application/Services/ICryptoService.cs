namespace Application.Services
{
    public interface ICryptoService
    {
        string Encrypt(string value, bool appliedUrlEncode = false);

        string Sha1Hash(string value);
        string Decrypt(string cipherText);
    }
}

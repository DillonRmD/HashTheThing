using System.Security.Cryptography;
using System.Text;

public class Hash
{
    
    public string HashedContents {get; set;}

    public Hash()
    {
    }
    public Hash(string contents)
    {
        HashStr(contents);
    }

    public string HashStr(string contents)
    {
        string salt = GenerateSalt();

        StringBuilder sb = new StringBuilder();
        contents = salt + contents;
        foreach (byte b in GetHashInBytes(contents))
        {
            sb.Append(b.ToString("X2"));
        }

        HashedContents = sb.ToString();
        return HashedContents;
    }

    private static byte[] GetHashInBytes(string contents)
    {
        HashAlgorithm algorithm = SHA256.Create();
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(contents));
    }

    private string GenerateSalt()
    {
        byte[] buffer = new byte[255];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(buffer);
        }

        StringBuilder sb = new StringBuilder();
        foreach (byte b in buffer)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }
}
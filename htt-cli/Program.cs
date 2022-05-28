public class Program
{
    public static void Main(string[] args)
    {
        string strToHash = "test";
        Console.WriteLine(strToHash);

        Hash hash = new Hash(strToHash);
        Console.WriteLine(hash.HashedContents);

        hash.HashStr(strToHash);
        Console.WriteLine(hash.HashedContents);
    }
}
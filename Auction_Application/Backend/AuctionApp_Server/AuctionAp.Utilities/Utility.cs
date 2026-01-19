using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace AuctionApp.Utilities;

/// <summary>
/// This class contain the Utility methods used in the application
/// </summary>
public sealed class Utility
{
    private readonly IConfiguration _configuration;

    public Utility(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Encrypt plain text to cipher text
    /// </summary>
    /// <param name="plainText"></param>
    /// <param name="key"></param>
    /// <returns>return the cipher text</returns>
    public string EncryptData(string plainText)
    {
        var key = _configuration.GetSection("encryptionDecryptionKey").Value;

        byte[] iv = new byte[16];
        byte[] array;
        string cipherText = string.Empty;

        var salt = Encoding.UTF8.GetBytes("random-salt");

        // Key Generation
        Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(key, salt, 100000, HashAlgorithmName.SHA512);

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyDerivation.GetBytes(32);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
            streamWriter.Write(plainText);
            array = memoryStream.ToArray();
        }

        cipherText = Convert.ToBase64String(array);

        return cipherText;
    }

    /// <summary>
    /// Decrypt cipher text to plain text
    /// </summary>
    /// <param name="cipherText"></param>
    /// <param name="key"></param>
    /// <returns>return the plain text</returns>
    public string DecryptData(string cipherText)
    {
        var key = _configuration.GetSection("encryptionDecryptionKey").Value;

        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(cipherText);
        string plainText = string.Empty;

        var salt = Encoding.UTF8.GetBytes("random-salt");

        // Key Generation
        Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(key, salt, 100000, HashAlgorithmName.SHA512);

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyDerivation.GetBytes(32);
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new MemoryStream(buffer);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(cryptoStream);
            plainText = streamReader.ReadToEnd();
        }

        return plainText;
    }
}

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NencerHis.Helpers
{
    public static class PasswordHasher
    {
        /// <summary>
        /// Tạo key mã hoá dựa vào tên máy tính
        /// </summary>
        /// <returns>Trả về key</returns>
        public static string CreateKeyFromComputerName()
        {
            string computerName = Environment.MachineName;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Băm tên máy tính
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(computerName));

                // Cắt hoặc xử lý mảng byte để phù hợp với kích thước khóa cần thiết
                // Ví dụ: cắt lấy 16 byte đầu tiên cho khóa AES 128-bit
                byte[] keyBytes = new byte[16];
                Array.Copy(bytes, keyBytes, 16);

                // Chuyển đổi byte thành chuỗi để sử dụng như một khóa
                string key = BitConverter.ToString(keyBytes).Replace("-", "").ToLower();

                return key;
            }
        }

        /// <summary>
        /// Hàm Mã Hóa
        /// </summary>
        /// <param name="text">Text bình thường</param>
        /// <returns>Text đã mã hoá</returns>
        public static string EncryptString(string text)
        {
            var keyString = PasswordHasher.CreateKeyFromComputerName();

            byte[] key = Encoding.UTF8.GetBytes(keyString);

            using (Aes aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        byte[] iv = aesAlg.IV;
                        byte[] decryptedContent = msEncrypt.ToArray();
                        byte[] result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        /// <summary>
        /// Hàm giải mã
        /// </summary>
        /// <param name="cipherText">văn bản mật mã</param>
        /// <returns>Text đã giải mã</returns>
        public static string DecryptString(string cipherText)
        {
            var keyString = PasswordHasher.CreateKeyFromComputerName();

            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            byte[] key = Encoding.UTF8.GetBytes(keyString);

            using (Aes aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}

using System.IO;

namespace NencerHis.Helpers
{
    public static class AppSettingManager
    {
        /// <summary>
        /// Lưu tài khoản và mật khẩu
        /// </summary>
        /// <param name="username">Tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        public static void SaveCredentials(string username, string password)
        {
            SaveAccountInDocument(username, password);
        }

        /// <summary>
        /// Lưu tài khoản và mật khẩu ở document
        /// </summary>
        /// <param name="username">Tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        private static void SaveAccountInDocument(string username, string password)
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string documentsPathDoc = documentsPath + "\\Nencer LLC";

                // Kiểm tra xem thư mục đã tồn tại chưa
                if (!Directory.Exists(documentsPathDoc))
                {
                    // Tạo thư mục
                    Directory.CreateDirectory(documentsPathDoc);
                }

                var encrypt = PasswordHasher.EncryptString(password);

                string filePath = Path.Combine(documentsPathDoc, "tmp.txt");
                string contentToWrite = $"{username}:{encrypt}";

                File.WriteAllText(filePath, contentToWrite);
            }
            catch (Exception e)
            {
                LogHelper.Exception("Lỗi lưu tài khoản và mật khẩu: " + e.Message, e);
            }
        }

        /// <summary>
        /// Lấy tài khoản và mật khẩu từ document
        /// </summary>
        /// <returns>Trả về 2 item, Item1 = Tài khoản, Item2 = Mật khẩu</returns>
        private static (string? Username, string? Password) ReadAccountInDocument()
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string documentsPathDoc = documentsPath + "\\Nencer LLC\\tmp.txt";

                string content = File.ReadAllText(documentsPathDoc);

                if (!string.IsNullOrEmpty(content))
                {
                    string[] parts = content.Split(':');
                    if (parts.Length == 2)
                    {
                        var decrypt = PasswordHasher.DecryptString(parts[1]);
                        return (parts[0], decrypt);
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.Exception("Lỗi lấy tài khoản và mật khẩu từ document: " + e.Message, e);
                return (null, null);
            }

            return (null, null);
        }

        /// <summary>
        /// Lấy tài khoản và mật khẩu
        /// </summary>
        /// <returns>Trả về 2 item, Item1 = Tài khoản, Item2 = Mật khẩu</returns>
        public static (string? Username, string? Password) GetSavedCredentials()
        {
            return ReadAccountInDocument();
        }
    }
}

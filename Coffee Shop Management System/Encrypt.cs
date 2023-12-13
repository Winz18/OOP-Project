using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Shop_Management_System
{
    class Encrypt
    {
        public string Hash_Password(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Chuyển đổi chuỗi thành mảng byte
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);

                // Tạo hash SHA-256
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Chuyển đổi mảng byte thành chuỗi hex để hiển thị
                string hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hashString;
            }
        }
        public bool VerifyPassword(string inputPassword, byte[] hashedPasswordBytes)
        {
            string hashedInputPassword = Hash_Password(inputPassword);
            string hashedPassword = BitConverter.ToString(hashedPasswordBytes).Replace("-", string.Empty);
            if (hashedInputPassword == hashedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
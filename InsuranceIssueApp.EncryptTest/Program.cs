using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceIssueApp.Common;
using System.Security.Cryptography;

namespace InsuranceIssueApp.EncryptTest
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            Console.WriteLine(CryptoEncryption.EncodePassword("Test123"));
            Console.WriteLine(CryptoEncryption.DecodePassword(CryptoEncryption.EncodePassword("Test123")));

            Console.ReadKey();
        }
    }
}

/******************************************************************************
 * Pascal Audet
 * Charles-Isaac Côté
 * Jérôme Labrie
 * 18 octobre 2016
 * Communication par ordinateur
 * LAB 7
 * Programme qui permet l'apprentissage sur la manipulation des codes à barre
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;


namespace LectBarreCode
{
    class DatabaseEncryption
    {
        private const int LongueurClef = 256; //Do NOT change

        private const int IterationDerive = 1000;
        private static string GenererHashSale(string MotDePasse)
        {

            HashAlgorithm HashingAlgo = new SHA256Managed();
            byte[] ByteArraySalt = Generer256bitRandom();
            byte[] ByteArrayTexte = Encoding.ASCII.GetBytes(MotDePasse);
            byte[] ByteArrayTexteAvecSel = new byte[ByteArrayTexte.Length + ByteArraySalt.Length];
            for (int i = 0; i < ByteArrayTexte.Length; i++)
            {
                ByteArrayTexteAvecSel[i] = ByteArrayTexte[i];
            }
            for (int i = 0; i < ByteArraySalt.Length; i++)
            {
                ByteArrayTexteAvecSel[i + ByteArrayTexte.Length] = ByteArraySalt[i];
            }
           
            return Convert.ToBase64String(HashingAlgo.ComputeHash(ByteArrayTexteAvecSel)) + Convert.ToBase64String(ByteArraySalt);
        }


        private static bool CheckPasswordHash(string CryptedStringWHash, string MotDePasse)
        {
            HashAlgorithm HashingAlgo = new SHA256Managed();
            byte[] ByteArrayTexte = Encoding.ASCII.GetBytes(MotDePasse);
            byte[] ByteArraySalt = Convert.FromBase64String(CryptedStringWHash.Substring(CryptedStringWHash.Length - 4 * (int)Math.Ceiling(LongueurClef / 8 / 3.0), 4 * (int)Math.Ceiling(LongueurClef / 8 / 3.0)));
            string HashedMotDePasseComparaison = CryptedStringWHash.Substring(CryptedStringWHash.Length - 2 * 4 * (int)Math.Ceiling(LongueurClef / 8 / 3.0), 4 * (int)Math.Ceiling(LongueurClef / 8 / 3.0));
            byte[] MotDePasseAHasher = new byte[ByteArrayTexte.Length + ByteArraySalt.Length];

            for (int i = 0; i < ByteArrayTexte.Length; i++)
            {
                MotDePasseAHasher[i] = ByteArrayTexte[i];
            }
            for (int i = 0; i < ByteArraySalt.Length; i++)
            {
                MotDePasseAHasher[i + ByteArrayTexte.Length] = ByteArraySalt[i];
            }
            byte[] debugb = HashingAlgo.ComputeHash(MotDePasseAHasher);
            string debug = Convert.ToBase64String(HashingAlgo.ComputeHash(MotDePasseAHasher));
            int debug3 = debug.Length;
            if (Convert.ToBase64String(HashingAlgo.ComputeHash(MotDePasseAHasher)) == HashedMotDePasseComparaison)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string Encryter(string TexteNonCrypte, string MotDePasse)
        {

            byte[] ByteSalt = Generer256bitRandom();
            byte[] ArrayByte = Generer256bitRandom();
            byte[] TexteNonCrypteByte = Encoding.ASCII.GetBytes(TexteNonCrypte);
            string MotDePasseHashe = GenererHashSale(MotDePasse);
            using (Rfc2898DeriveBytes MDP = new Rfc2898DeriveBytes(MotDePasse, ByteSalt, IterationDerive))
            {
                byte[] ClefByte = MDP.GetBytes(LongueurClef / 8);
                using (RijndaelManaged ClefSymmetrique = new RijndaelManaged())
                {
                    ClefSymmetrique.BlockSize = LongueurClef;
                    ClefSymmetrique.Mode = CipherMode.CBC;
                    ClefSymmetrique.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform Encrypteur = ClefSymmetrique.CreateEncryptor(ClefByte, ArrayByte))
                    {
                        using (MemoryStream StreamMemoire = new MemoryStream())
                        {
                            using (CryptoStream StreamCrypte = new CryptoStream(StreamMemoire, Encrypteur, CryptoStreamMode.Write))
                            {
                                StreamCrypte.Write(TexteNonCrypteByte, 0, TexteNonCrypteByte.Length);
                                StreamCrypte.FlushFinalBlock();
                                byte[] TexteCrypteByte = ByteSalt;
                                TexteCrypteByte = TexteCrypteByte.Concat(ArrayByte).ToArray();
                                TexteCrypteByte = TexteCrypteByte.Concat(StreamMemoire.ToArray()).ToArray();
                                StreamMemoire.Close();
                                StreamCrypte.Close();
                                return Convert.ToBase64String(TexteCrypteByte) + MotDePasseHashe;
                            }
                        }
                    }
                }
            }
        }
        public static string Decrypter(string TexteCrypte, string MotDePasse)
        {
            if (CheckPasswordHash(TexteCrypte, MotDePasse))
            {
                string test = TexteCrypte.Substring(0, TexteCrypte.Length - 64);
                byte[] ByteArrayDeByteSaleEtEncrypte = Convert.FromBase64String(TexteCrypte.Substring(0, TexteCrypte.Length - 4 * (int)Math.Ceiling(LongueurClef / 8 / 3.0) - 4 * (int)Math.Ceiling(LongueurClef / 8 / 3.0)));
                byte[] ByteArrayDeSel = ByteArrayDeByteSaleEtEncrypte.Take(LongueurClef / 8).ToArray();
                byte[] ByteCrypte = ByteArrayDeByteSaleEtEncrypte.Skip(LongueurClef / 8).Take(LongueurClef / 8).ToArray();
                byte[] ByteTexteCrypte = ByteArrayDeByteSaleEtEncrypte.Skip((LongueurClef / 8) * 2).Take(ByteArrayDeByteSaleEtEncrypte.Length - ((LongueurClef / 8) * 2)).ToArray();
                using (Rfc2898DeriveBytes MDP = new Rfc2898DeriveBytes(MotDePasse, ByteArrayDeSel, IterationDerive))
                {
                    byte[] ClefByte = MDP.GetBytes(LongueurClef / 8);
                    using (RijndaelManaged ClefSymmetrique = new RijndaelManaged())
                    {
                        ClefSymmetrique.BlockSize = LongueurClef;
                        ClefSymmetrique.Mode = CipherMode.CBC;
                        ClefSymmetrique.Padding = PaddingMode.PKCS7;
                        using (ICryptoTransform Decryption = ClefSymmetrique.CreateDecryptor(ClefByte, ByteCrypte))
                        {
                            using (MemoryStream StreamMemoire = new MemoryStream(ByteTexteCrypte))
                            {
                                using (CryptoStream StreamCrypte = new CryptoStream(StreamMemoire, Decryption, CryptoStreamMode.Read))
                                {
                                    byte[] ByteTexteDecrypte = new byte[ByteTexteCrypte.Length];
                                    int NbrByteDecrypte = StreamCrypte.Read(ByteTexteDecrypte, 0, ByteTexteDecrypte.Length);
                                    StreamMemoire.Close();
                                    StreamCrypte.Close();
                                    return Encoding.ASCII.GetString(ByteTexteDecrypte, 0, NbrByteDecrypte);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return null;
            }
        }


        private static byte[]  Generer256bitRandom()
        {
            byte[] ByteRandom = new byte[LongueurClef / 8];
            using (RNGCryptoServiceProvider RNGCSP = new RNGCryptoServiceProvider())
            {
                RNGCSP.GetBytes(ByteRandom);
            }
            return ByteRandom;
        }
    }
}

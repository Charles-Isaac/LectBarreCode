/******************************************************************************
 * Pascal Audet
 * Charles-Isaac Côté
 * Jérôme Labrie
 * 18 octobre 2016
 * Communication par ordinateur
 * LAB 7
 * Programme qui permet l'apprentissage sur la manipulation des codes à barre
 *****************************************************************************/

#define Encryption  //Commenter cette ligne pour desactiver l'encryption de la base de donné - utile pour le debugage

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Globalization;


namespace LectBarreCode
{
    public partial class frmFacture : Form
    {
        //string Trame = "";
        int m_Abandon;
        string m_MotDePasse;

        public frmFacture()
        {
            InitializeComponent();
#if !Encryption
            txtMotDePasse.Visible = false;
            btnLire.Visible = false;
#endif
            m_Abandon = 0;
            m_MotDePasse = "";
            PortDisponible();
        }

        //méthode pour remplir le comboboxPort avec une liste des ports serie disponible
        private void PortDisponible()
        {
            int Indice = 0;
            string[] Port = SerialPort.GetPortNames();

            while (Indice < Port.Length)
            {
                cbPort.Items.Add(Port[Indice]);
                Indice = Indice + 1;
            }
        }

        private void cbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            spComm.Close();
            spComm.PortName = cbPort.SelectedItem.ToString();
            OuvrirPort();
        }
        private void rbParite_CheckedChanged(object sender, EventArgs e)
        {
            spComm.Close();
            if (rbPair.Checked == true)
            {
                spComm.Parity = Parity.Even;
            }
            else
            {
                if (rbImpair.Checked == true)
                {
                    spComm.Parity = Parity.Odd;
                }
                else
                {
                    spComm.Parity = Parity.None;
                }
            }
            OuvrirPort();
        }

        private void rbBitDonnees_CheckedChanged_1(object sender, EventArgs e)
        {
            spComm.Close();
            if (rbSeptBit.Checked == true)
            {
                spComm.DataBits = 7;
            }
            else
            {
                if (rbHuitBit.Checked == true)
                {
                    spComm.DataBits = 8;
                }
            }
            OuvrirPort();
        }

        private void rbBitArret_CheckedChanged(object sender, EventArgs e)
        {
            spComm.Close();
            if (rbUnBit.Checked == true)
            {
                spComm.StopBits = StopBits.One;
            }
            else
            {
                if (rbDeuxBit.Checked == true)
                {
                    spComm.StopBits = StopBits.Two;
                }
            }
            OuvrirPort();
        }

        private void OuvrirPort()
        {
            try
            {
                spComm.Open();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Erreur port");
            }
        }

        private void btnLire_Click(object sender, EventArgs e)
        {
            m_MotDePasse = txtMotDePasse.Text;
        }

        private void spComm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string Trame = ((SerialPort)sender).ReadTo(((char)03).ToString()) + (char)03;
            Invoke(new Action(() =>
            {
#if Encryption
                Ecriture(Trame, "reception.txt", FileMode.Create, true);
                string Texte = Lecture("reception.txt", true);
#else
                Ecriture(Trame, "reception.txt", FileMode.Create);
                string Texte = Lecture("reception.txt");
#endif
                ResultatTrame RTrame = new ResultatTrame(Texte);
                if (RTrame.Valide)
                {
                    spComm.Write(((char)06).ToString()); //Envoie un ACK
                    m_Abandon = 0; //s'assure que le compteur de trame invalide recue est a 0

                    //Le code pour la verification de la date est ici:

                    bool DateValide = true;
                    if (RTrame.Heure < 8 || RTrame.Heure > 17)
                    {
                        DateValide = false;
                    }
                    else
                    {
                        if ((RTrame.Mois == 1 && RTrame.Jour == 1) || (RTrame.Mois == 10 && RTrame.Jour == 14) || (RTrame.Mois == 12 && RTrame.Jour == 25))
                        {
                            DateValide = false;
                        }
                    }

                    if (DateValide)
                    {

                        int Quantite;
                        decimal Prix;
                        if (InventaireUpdate(RTrame.Data, out Quantite, out Prix))
                        {
                            txtCheckSum.Text = RTrame.CheckSum;
                            txtDate.Text = RTrame.DateHeure;
                            txtNomArt.Text = RTrame.Data; //Changer pour des vrai nom
                            txtPrixArt.Text = Prix.ToString("C");
                            txtQuantitéRest.Text = Quantite.ToString();
                            txtTaxe.Text = Math.Round((Prix * 0.14975M), 2, MidpointRounding.AwayFromZero).ToString("C");
                            txtTotal.Text = Math.Round((Prix * 1.14975M), 2, MidpointRounding.AwayFromZero).ToString("C");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Merci pour votre travail hors des heures rémunérées");
                    }
                }
                else
                {
                    //code NAK goes here
                    m_Abandon++; //incremente la variable qui compte le nombre de trame invalide recue
#if Encryption
                    Ecriture(Texte + '\n', "ArchiveErreur.txt", FileMode.Append, false);
#else
                    Ecriture(Texte + '\n', "ArchiveErreur.txt", FileMode.Append);
#endif
                    if (m_Abandon > 10) //Verifie combien de fois la trame recue est invalide
                    {
                        spComm.Write(((char)24).ToString());//Envoie un Cancel
                        m_Abandon = 0;  
                    }
                    else
                    {
                        spComm.Write(((char)21).ToString());//Garde espoire que le lecteur de barre code vas dire quelque chose qui va faire du sens et lui demande de repeter (envoie un NAK)
                    }
                }
            }));
        }

        private bool InventaireUpdate(string Item, out int Quantite, out decimal Prix)
        {
            Quantite = -1;
            Prix = 0.0M;
            string StrQuantiteInv;
            string StrPrixInv;
            int QuantiteInv;
#if Encryption
            string StrInventaire = Lecture("Inventaire.txt", false); //Lis l'inventaire au complet et ne la decrypte pas
            
#else
            string StrInventaire = Lecture("Inventaire.txt"); //Lis l'inventaire au complet et ne la decrypte pas
#endif
            string[] Inventaire = StrInventaire.Split('\n');
            int i = Array.FindIndex(Inventaire, element => element.StartsWith(Item, StringComparison.Ordinal));//position (index) de l'item en inventaire (evite de devoir decrypter chaque lignes de l'inventaire pour trouver le bon item)
            if (i > 0 && i <= Int32.Parse(Inventaire[0]))   //Verifie que l'item est enregistre en inventaire
            {
                //Ecriture(DatabaseEncryption.Encryter((Int32.Parse(DatabaseEncryption.Decrypter(Lecture("inventaire.txt", false).Split('\n')[Int32.Parse(Lecture("inventaire.txt", false).Split('\n')[Array.FindIndex(Lecture("inventaire.txt", false).Split('\n'), element => element.StartsWith(Item, StringComparison.Ordinal))].Split('-').Last())], m_MotDePasse)) - 1).ToString(), m_MotDePasse), "Inventaire.txt", FileMode.Append, false);
#if Encryption
                StrQuantiteInv = DatabaseEncryption.Decrypter(Inventaire[Int32.Parse(Inventaire[i].Split('-').Last())], m_MotDePasse);
                if (StrQuantiteInv == null)
                {
                    MessageBox.Show("Mauvais mot de passe"); //Message d'erreur generique
                    return false;
                }
                StrPrixInv = DatabaseEncryption.Decrypter(Inventaire[Int32.Parse(Inventaire[i].Split('-').Last()) + Int32.Parse(Inventaire[0])], m_MotDePasse);
#else
                StrQuantiteInv = Inventaire[Int32.Parse(Inventaire[i].Split('-').Last())];
                StrPrixInv = Inventaire[Int32.Parse(Inventaire[i].Split('-').Last()) + Int32.Parse(Inventaire[0])];
#endif


                if (!Int32.TryParse(StrQuantiteInv, out QuantiteInv))
                {
                    MessageBox.Show("Erreur lors de la recuperation de la quantite en inventaire"); //Message d'erreur generique
                    return false;
                }
                if (!Decimal.TryParse(StrPrixInv, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out Prix))
                {
                    MessageBox.Show("Erreur lors de la recuperation du prix en inventaire"); //Message d'erreur generique
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Item introuvable dans l'inventaire"); //Message d'erreur generique
                return false;
            }
            QuantiteInv--;
            if (QuantiteInv < 0)
            {
                MessageBox.Show("Inventaire insuffisant");
                return false;
            }
            Quantite = QuantiteInv;
#if Encryption
            Inventaire[Int32.Parse(Inventaire[i].Split('-').Last())] = DatabaseEncryption.Encryter(QuantiteInv.ToString(), m_MotDePasse);
#else
            Inventaire[Int32.Parse(Inventaire[i].Split('-').Last())] = QuantiteInv.ToString();
#endif

            StrInventaire = String.Join("\n", Inventaire);
#if Encryption
            Ecriture(StrInventaire, "Inventaire.txt", FileMode.Create, false);
#else
            Ecriture(StrInventaire, "Inventaire.txt", FileMode.Create);
#endif
            return true;
        }
#if Encryption
        private void Ecriture(string Texte, string Chemin, FileMode filemode, bool Encryption)
        {
            try
            {
                FileStream fs = new FileStream(Chemin, filemode, FileAccess.Write, FileShare.Read);
                if (Encryption)
                {
                    Texte = DatabaseEncryption.Encryter(Texte, m_MotDePasse);
                }
                fs.Write(Encoding.ASCII.GetBytes(Texte), 0, Encoding.ASCII.GetBytes(Texte).Length);

                fs.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Data.ToString());
            }
        }
#else
        private void Ecriture(string Texte, string Chemin, FileMode filemode)
        {
            try
            {
                FileStream fs = new FileStream(Chemin, filemode, FileAccess.Write, FileShare.Read);
                
                fs.Write(Encoding.ASCII.GetBytes(Texte), 0, Encoding.ASCII.GetBytes(Texte).Length);

                fs.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Data.ToString());
            }
        }
#endif
#if Encryption

        private string Lecture(string Chemin, bool Encryption)
        {
            try
            {
                FileStream fs = new FileStream(Chemin, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                string Texte = System.Text.Encoding.ASCII.GetString(buffer);

                if (Encryption)
                {
                    Texte = DatabaseEncryption.Decrypter(Texte, m_MotDePasse);
                }

                fs.Dispose();
                return Texte;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Data.ToString());
                return "";
            }
        }
#else
        private string Lecture(string Chemin)
        {
            try
            {
                FileStream fs = new FileStream(Chemin, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                string Texte = System.Text.Encoding.ASCII.GetString(buffer);
                fs.Dispose();
                return Texte;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Data.ToString());
                return "";
            }
        }
#endif

        private void btnCreerInventaire_Click(object sender, EventArgs e)
        {



            string StrNouvInventaire = "4\n"; //Nombre d'item dans l'inventaire
            StrNouvInventaire += "1-5\n";     //Emplacement de l'item "1" == 5
            StrNouvInventaire += "2-6\n";     //Emplacement de l'item "2" == 6
            StrNouvInventaire += "34-7\n";    //Emplacement de l'item "34" == 7
            StrNouvInventaire += "Z9-8\n";    //Emplacement de l'item "Z9" == 8
#if Encryption
            m_MotDePasse = txtMotDePasse.Text;
            StrNouvInventaire += DatabaseEncryption.Encryter("03", m_MotDePasse) + "\n";
            StrNouvInventaire += DatabaseEncryption.Encryter("43", m_MotDePasse) + "\n";
            StrNouvInventaire += DatabaseEncryption.Encryter("12", m_MotDePasse) + "\n";
            StrNouvInventaire += DatabaseEncryption.Encryter("30", m_MotDePasse) + "\n";

            //15.42 8.94 21.70 12.24
            StrNouvInventaire += DatabaseEncryption.Encryter("15.42", m_MotDePasse) + "\n";
            StrNouvInventaire += DatabaseEncryption.Encryter("8.94", m_MotDePasse) + "\n";
            StrNouvInventaire += DatabaseEncryption.Encryter("21.70", m_MotDePasse) + "\n";
            StrNouvInventaire += DatabaseEncryption.Encryter("12.24", m_MotDePasse) + "\n";

            Ecriture(StrNouvInventaire, "Inventaire.txt", FileMode.Create, false);
#else
            StrNouvInventaire += "03\n";
            StrNouvInventaire += "43\n";
            StrNouvInventaire += "12\n";
            StrNouvInventaire += "30\n";

            //15.42 8.94 21.70 12.24
            StrNouvInventaire += "15.42\n";
            StrNouvInventaire += "8.94\n";
            StrNouvInventaire += "21.70\n";
            StrNouvInventaire += "12.24\n";

            Ecriture(StrNouvInventaire, "Inventaire.txt", FileMode.Create);
#endif

            /*int Quantite;
            decimal prix;
            InventaireUpdate("Z9", out Quantite, out prix);*/ //simple petit test

        }
    }
}

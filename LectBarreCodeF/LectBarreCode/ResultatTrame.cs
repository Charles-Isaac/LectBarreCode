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

namespace LectBarreCode
{
    class ResultatTrame
    {
        private string m_Trame;
        private bool m_Valide;
        private byte m_NoRecord;
        private byte m_NoApp;
        private byte m_Jour;
        private byte m_Mois;
        private byte m_Annee;
        private byte m_Seconde;
        private byte m_Minute;
        private byte m_Heure;
        private string m_IDMachine;
        private byte m_NoEcran;
        private string m_Data;
        private string m_CheckSum;

        public ResultatTrame(string Texte)
        {
            this.Trame = Texte;

            byte[] bTrame = Encoding.ASCII.GetBytes(Texte);
            if (bTrame[0] == 02)
            {
                
                int CKTotal = 0;
                for (int j = 0; j < bTrame.Length - 3; j++)
                {
                    CKTotal += bTrame[j];
                }
                string TotalCheck = CKTotal.ToString("X2");
                TotalCheck = "" + TotalCheck[TotalCheck.Length - 2] + TotalCheck[TotalCheck.Length - 1];

                string CheckSum;
                CheckSum = "" + Texte[Texte.Length - 3] + Texte[Texte.Length - 2];
                if (CheckSum == TotalCheck)
                {
                    int i = 15;
                    while (i < bTrame.Length && bTrame[i] != ',') i++;
                    if (i != bTrame.Length)
                    {
                        this.Valide = true;
                        this.CheckSum = CheckSum;
                        this.NoRecord = bTrame[1];
                        this.NoApp = bTrame[2];
                        this.Mois = (byte)((bTrame[3] - 0x30) * 10 + (bTrame[4] - 0x30));
                        this.Jour = (byte)((bTrame[5] - 0x30) * 10 + (bTrame[6] - 0x30));
                        this.Annee = (byte)((bTrame[7] - 0x30) * 10 + (bTrame[8] - 0x30));
                        this.Heure = (byte)((bTrame[9] - 0x30) * 10 + (bTrame[10] - 0x30));
                        this.Minute = (byte)((bTrame[11] - 0x30) * 10 + (bTrame[12] - 0x30));
                        this.Seconde = (byte)((bTrame[13] - 0x30) * 10 + (bTrame[14] - 0x30));
                        this.IDMachine = Texte.Substring(15, i - 2 - 15); 
                        this.NoEcran = byte.Parse("" + Texte[i - 2] + Texte[i - 1], System.Globalization.NumberStyles.HexNumber);
                        this.Data = Texte.Substring(i + 1, Texte.Length - i - 5).Replace(" ", string.Empty);

                    }
                    else
                    {
                        this.Valide = false;
                    }
                }
                else
                {
                    this.Valide = false;
                }
            }
        }
        #region Propriete
        public string Trame
        {
            get { return m_Trame; }
            set { m_Trame = value; }
        }

        public string DateHeure
        {
            get { return string.Format("Date: {0}/{1}/{2}  Heure: {3}:{4}:{5}", m_Jour, m_Mois, m_Annee, m_Heure, m_Minute, m_Seconde); }
        }


        public bool Valide
        {
            get { return m_Valide; }
            set { m_Valide = value; }
        }

        public byte NoRecord
        {
            get { return m_NoRecord; }
            set { m_NoRecord = value; }
        }

        public byte NoApp
        {
            get { return m_NoApp; }
            set { m_NoApp = value; }
        }

        public byte Jour
        {
            get { return m_Jour; }
            set { m_Jour = value; }
        }

        public byte Mois
        {
            get { return m_Mois; }
            set { m_Mois = value; }
        }

        public byte Annee
        {
            get { return m_Annee; }
            set { m_Annee = value; }
        }

        public byte Seconde
        {
            get { return m_Seconde; }
            set { m_Seconde = value; }
        }

        public byte Minute
        {
            get { return m_Minute; }
            set { m_Minute = value; }
        }

        public byte Heure
        {
            get { return m_Heure; }
            set { m_Heure = value; }
        }

        public string IDMachine
        {
            get { return m_IDMachine; }
            set { m_IDMachine = value; }
        }

        public byte NoEcran
        {
            get { return m_NoEcran; }
            set { m_NoEcran = value; }
        }

        public string Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        public string CheckSum
        {
            get { return m_CheckSum; }
            set { m_CheckSum = value; }
        }

        #endregion
    }
}

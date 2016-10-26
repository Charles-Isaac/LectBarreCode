Generateur de grilles de sudoku resolues----------------------------------------
Url     : http://codes-sources.commentcamarche.net/source/53820-generateur-de-grilles-de-sudoku-resoluesAuteur  : robx2391Date    : 02/08/2013
Licence :
=========

Ce document intitulé « Generateur de grilles de sudoku resolues » issu de CommentCaMarche
(codes-sources.commentcamarche.net) est mis à disposition sous les termes de
la licence Creative Commons. Vous pouvez copier, modifier des copies de cette
source, dans les conditions fixées par la licence, tant que cette note
apparaît clairement.

Description :
=============

Voici ma premi&egrave;re source en C#, un simple g&eacute;n&eacute;rateur de gri
lles de sudoku r&eacute;solues.
<br />Ce programme peut &ecirc;tre une base de 
commencement pour certains qui voudraient cr&eacute;er leur propre jeu de sudoku
.
<br />L'algorithme utilis&eacute; est celui du backtracking (possibilit&eacut
e; de revenir en arri&egrave;re si il y a blocage &agrave; un certain moment dan
s l'algorithme).
<br />Algorithme :
<br />On pointe sur une case de la grille.

<br />S'il y a des solutions possibles pour la case, on en choisit une.
<br /
>Si il n'y a plus de solutions possibles pour la case, on backtrack (on pointe s
ur la case pr&eacute;c&eacute;dente pour en modifier la valeur).
<br />Apr&egra
ve;s avoir choisit la valeur pour la case, on rappel la fonction de backtracking
 en pointant sur la case suivante.
<br /><a name='source-exemple'></a><h2> Sour
ce / Exemple : </h2>
<br /><pre class='code' data-mode='basic'>
//classe Gril
le
using System;
using System.Collections.Generic;
using System.Linq;
using 
System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1

{
    class Grille
    {
    	//attributs
        private Case[,] grille;

		//constructeur
        public Grille(){
            //on initialise la grille avec un tableau 2 dimensions 9 par 9 avec des objets Case
            initGrille();
            //on remplit la grille initialisée
            remplirBacktrack(0, 'n');
         }
		//methode pour initialiser la grille
        private void initGrille(){
            //on initialise la grille avec un tableau(9,9) d'objet Case
            grille = new Case[9,9];
            for (int i = 0; i &lt; 9; i++)
            {
                for (int j = 0; j &lt; 9; j++)

                {
                    grille[i, j] = new Case();
                }
            }
        }

        //fonction RECURSIVE pour remplir la grille en utilisant l'algorithme de backtrack
        private void remplirBacktrack(int position, char param){
            //on verifie si on n'est pas au bout de la grille :
            if (position &gt;= 81) return;
            int ligne, col, nb;
            bool checkCol, checkRow, checkSquare, checkTab, tabFull;
            bool p = false;
            bool[] tabValeurCase = new bool[9];

            Random rnd = new Random();
            //on recupere le numero de ligne et de colonne
            //en fonction de la position :
            ligne = position / 9;
            col = position % 9;

            nb = 0;
   
         //on recupere le tableau des chiffres pour la case courante :
            grille[col, ligne].getTabValeurs(tabValeurCase);

            if (param == 'b')
            //backtrack
            {
            	//on recupere la valeur de la case pointee
                nb = grille[col, ligne].getValeur();
  
              //on rend cette valeur interdite dans le tableau de valeurs de la case
                grille[col, ligne].setVrai(nb);
                //on met a jour le tableau de la case dans cette fonction
                grille[col, ligne].getTabValeurs(tabValeurCase);
            }
            //boucle tant que l'on n'a pas trouvé un chiffre convenable pour la case
            while (p == false)
            {
                tabFull = true;
                //On verifie s'il reste des solutions possibles pour la case, dans son tableau :
     
           
                for (int i = 0; i &lt; 9; i++)
                {

                    if (tabValeurCase[i] == false) tabFull = false;
                }
                //si le tableau de valeurs utilisees de la case n'est pas plein :
                if (!tabFull)
                {
                    checkTab = false;
                    // on choisit un chiffre disponible dans la liste de valeurs de la case :
                    while (!(checkTab))
    
                {
                        nb = rnd.Next(1, 10);
              
          if (tabValeurCase[nb - 1] == true) checkTab = false;
                
        else checkTab = true;
                    }
                    //on verifie si le nombre choisit n'est pas dans la colonne, dans la ligne ou dans le carre
                    checkRow = notInRow(nb, ligne, col);
                    checkCol = notInColumn(nb, ligne, col);
                    checkSquare = notInSquare(nb, ligne, col);
                    p = checkTab &amp;&amp; checkRow &amp;&amp; checkCol &amp;&amp; checkSquare;
                    if (!p)
   
                 //si le nombre est deja dans la ligne/carre/colonne, 
        
            //on le met a &quot;true&quot; dans le tableau de valeurs de la case

                    {
                        grille[col, ligne].setVrai(nb);

                        grille[col, ligne].getTabValeurs(tabValeurCase);
                    }
                    else 
                    //si le chiffre choisit convient,
                    //on set la valeur de la case avec ce chiffre
                    { 
                        grille[col, ligne].setValeur(nb); 
                    }
                }
                //s'il est plein, backtrack (recul d'une case) :
                else
                {	

                	//on reinitialise le tableau de valeurs de la case
                    grille[col, ligne].resetTab();
                    //on met la valeur de la case a 0
                    grille[col, ligne].setValeur(0);
        
            //on appel la fonction en reculant de 1 case
                    remplirBacktrack(position - 1, 'b');
                    return;
                }
            }
            //cas ou la progression est normale
            
//on appel la fonction en avancant d'une case :
            remplirBacktrack(position + 1, 'n');
            return;
        }

		//fonction pour verifier si 'value' n'est pas deja present dans la ligne
        private bool notInRow(int value, int indR, int indC)
        {
            bool p=true;
            for(int i=0;i&lt;9;i++){
                if(grille[i,indR].getValeur()==value) p=false;
               }
            return p;
        }
        
        
//fonction pour verifier si 'value' n'est pas deja present dans la colonne
    
    private bool notInColumn(int value, int indR, int indC){
            bool p=true;
            for(int i=0;i&lt;9;i++){
                if (grille[indC, i].getValeur() == value) p = false;
               }
            return p;
   
     }
		
		////fonction pour verifier si 'value' n'est pas deja present dans le carré
        private bool notInSquare(int value, int indR, int indC){
    
           int divC,divR;
               bool p = true;
               divC = indC/3;
               divR = indR/3;
               for(int i = divC*3;i&lt;divC*3+3;i++){
                   for(int j = divR*3;j&lt;divR*3+3;j++){
      
                 if (grille[i, j].getValeur() == value) p = false;
                   }
               }
               return p;
        }

        public int getValCase(int ligne, int col)
        {
            return grille[col, ligne].getValeur();
        }
    }
}

//classe Case
using System;
using 
System.Collections.Generic;
using System.Linq;
using System.Text;

namespace
 WindowsFormsApplication1
{
	
    class Case
    {
    	//attributs
      
  private bool[] tabValeurs;
        private int valeur;
		
		//constructeur

        public Case(){
            initCase();
        }
		
		//methode pour initialiser le tableau de valeurs de la case (a false)
		//et sa valeur a 0

        private void initCase()
        {
            tabValeurs = new bool[9];
            for (int i = 0; i &lt; 9; i++)
            {
                tabValeurs[i] = false;
            }
            valeur = 0;
        }
		
		//methode pour reinitialiser le tableau de valeurs de la case
        public void resetTab()
        {
            for (int i = 0; i &lt; 9; i++)
            {
                tabValeurs[i] = false;
            }
        }
		
		//methode pour enlever un chiffre des valeurs possibles de la case
        public void setVrai(int indice)
        {
            tabValeurs[indice - 1] = true;
        }
		
		//methode pour modifier la valeur de la case
        public void setValeur(int value)
        {
            valeur = value;
        }
		

		//methode pour obtenir la valeur de la case
        public int getValeur()
        {
            return valeur;
        }
		
		//methode pour recopier (passage par reference) le tableau de valeur de la case
		//dans un tableau passé en argument
        public void getTabValeurs(bool[] tabValCase)
        {
            for (int i = 0; i &lt; 9; i++)
            {
                tabValCase[i] = tabValeurs[i];
            }
            
        }
    }
}
</p
re>
<br /><a name='conclusion'></a><h2> Conclusion : </h2>
<br />Ce programme
 n'est bien sur pas une fin en soit, juste une simple illustration de l'algorith
me de backtracking pour la generation de grilles de sudoku.

using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
    public GameObject my_pion; // Contient le pion
    public float case_size = 0.40f; // Taille d'une case

    private Rigidbody2D my_rig; // Notre RigidBody
    private Vector2 position; // Position temporaire

    private int[,] tab = new int[19, 19];
    private int p_x;
    private int p_y;
    
    float recalc(float pos) // Calcul et arrondis en fonctions de la position de base du curseur
    {
        float npos = pos;
        if (npos % case_size >= case_size/2)
            npos += case_size - (npos % case_size);
        else if (npos > 0)
            npos -= (npos % case_size);
        else if (npos % case_size <= -case_size/2)
            npos -= case_size + (npos % case_size);
        else
            npos -= (npos % case_size);
        if (npos >= case_size * 9)
            npos = case_size * 9;
        else if (npos <= -case_size * 9)
            npos = -case_size * 9;
        return npos;
    }

    int where_in_tab(float pos) // retourne la case correspondante a une coordonnée x ou y
    {
        float place = pos / case_size;
        if (place > 0)
            place += 9;
        else if (place < 0)
            place = 9 + place;
        else
            place = 9;
        return (int)place;
    }

    int calc_pos(int player) // Verifie l'absence de jeton dans le tableau puis en ajoute un si possible ou retourne le jeton actuelle
	{
        int j;
        int i;

        j = where_in_tab(position.y);
        i = where_in_tab(position.x);
        if (tab[j, i] == 0)
        {
            tab[j, i] = player;
            Debug.Log("Joué en ["+j+"] ["+i+"]");
            return (0);
        }
        return (tab[j,i]);

    }

    int verif_line()
    {
        int i = 0, j;
        int stack = 0;
        int flag = 0;
        while (i < 19)
        {
            j = 0;
            while (j < 19)
            {
                if (tab[i,j] != 0)
                {
                    if (tab[i, j] == flag)
                    {
                        stack++;
                        if (stack == 5)
                            return (tab[i, j]);
                    }
                    else
                    {
                        stack = 1;
                        flag = tab[i, j];
                    }
                }
                else
                {
                    stack = 0;
                    flag = 0;
                }
                j++;
            }
            i++;
        }
        return (0);
    }

    int verif_col()
    {
        int i, j=0;
        int stack = 0;
        int flag = 0;
        while (j < 19)
        {
            i = 0;
            while (i < 19)
            {
                if (tab[i, j] != 0)
                {
                    if (tab[i, j] == flag)
                    {
                        stack++;
                        if (stack == 5)
                            return (tab[i, j]);
                    }
                    else
                    {
                        stack = 1;
                        flag = tab[i, j];
                    }
                }
                else
                {
                    stack = 0;
                    flag = 0;
                }
                i++;
            }
            j++;
        }
        return (0);
    }

    int verif_diag1()
    {
        int i_s = 4, j_s = 0;
        int flag = 0, stack = 0;
        int i, j;
        while (j_s < 19)
        {
            i = i_s;
            j = j_s;
            while (i >= 0 && j <= 18)
            {
                if (tab[i, j] != 0)
                {
                    if (tab[i, j] == flag)
                    {
                        stack++;
                        if (stack == 5)
                            return (tab[i, j]);
                    }
                    else
                    {
                        stack = 1;
                        flag = tab[i, j];
                    }
                }
                else
                {
                    stack = 0;
                    flag = 0;
                }
                i--;
                j++;
            }
            stack = 0;
            flag = 0;
            if (i_s < 18)
                i_s++;
            else
                j_s++;
        }
        return (0);
    }

    int verif_diag2()
    {
        int i_s = 4, j_s = 18;
        int flag = 0, stack = 0;
        int i, j;
        while (j_s > 0)
        {
            i = i_s;
            j = j_s;
            while (i >= 0 && j >= 0)
            {
                if (tab[i, j] != 0)
                {
                    if (tab[i, j] == flag)
                    {
                        stack++;
                        if (stack == 5)
                            return (tab[i, j]);
                    }
                    else
                    {
                        stack = 1;
                        flag = tab[i, j];
                    }
                }
                else
                {
                    stack = 0;
                    flag = 0;
                }
                i--;
                j--;
            }
            stack = 0;
            flag = 0;
            if (i_s < 18)
                i_s++;
            else
                j_s--;
        }
        return (0);
    }

    int verif_win()
    {
        int res;
        if ((res = verif_line()) != 0
            || (res = verif_col()) != 0
            || (res = verif_diag1()) != 0
            || (res = verif_diag2()) != 0)
        {
            Debug.Log("Le joueur " + res + " a gagné");
            return (res);
        }
        return (0);
    }

	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (my_rig == null)
			my_rig = GetComponent<Rigidbody2D>();
        position = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        position.x = recalc(position.x);
        position.y = recalc(position.y);
        my_rig.position = position;
        if (Input.GetMouseButtonDown(0) && calc_pos(1) == 0) // En cas de clic gauche
        {
            Instantiate(my_pion, my_rig.position, new Quaternion()); // Creation d'un pion
            verif_win();
        }
    }
}

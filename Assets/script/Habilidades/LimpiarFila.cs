using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimpiarFila : MonoBehaviour
{
    public mazo deck;
    int m, r, a = 0;
    bool activate = false;

    
    public void Activar()
    {
        if(GetComponent<cartas>().faccion == "monster")
        {
            deck = GameObject.Find("mazo 1").GetComponent<mazo>();
        }
        if (GetComponent<cartas>().faccion == "machine")
        {
            deck = GameObject.Find("mazo 2").GetComponent<mazo>();
        }
        if (!activate)
        {
            activate = true;
            for(int i = 0; i < 5; i++)
            {
                if (deck.CortoAlcance[i].texture != null)
                {
                    m++;
                }
                if (deck.MedioAlcance[i].texture != null)
                {
                    r++;
                }
                if (deck.LargoAlcance[i].texture != null)
                {
                    a++;
                }
            }
            if(a < m && a < r)
            {
                for(int i = 0; i < 5; i++)
                {
                    deck.LargoAlcance[i].texture = null;
                    deck.largo[i] = false;
                }
            }
            if (a > m && m < r)
            {
                for (int i = 0; i < 5; i++)
                {
                    deck.CortoAlcance[i].texture = null;
                    deck.Corto[i] = false;
                }
            }
            if (r < a && r < m)
            {
                for (int i = 0; i < 5; i++)
                {
                    deck.MedioAlcance[i].texture = null;
                    deck.medio[i] = false;
                }
            }
        }
    }

}

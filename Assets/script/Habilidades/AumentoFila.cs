using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoFila : MonoBehaviour
{
    public mazo deck;
    bool activate = false;
    int i = 0;
    
    public void Activar()
    {
        if (!activate)
        {
            if (GetComponent<cartas>().faccion == "monster")
            {
                deck = GameObject.Find("mazo 1").GetComponent<mazo>();
            }
            if (GetComponent<cartas>().faccion == "machine")
            {
                deck = GameObject.Find("mazo 2").GetComponent<mazo>();
            }

            activate = true;
            for(int i = 0; i < 5; i++)
            {
                if (deck.Corto[i])
                {
                    i++;
                }
            }
            if (GetComponent<cartas>().faccion == "monster")
            {
                GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().poder1 += (i * 5);
            }
            if (GetComponent<cartas>().faccion == "machine")
            {
                GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().poder2 += (i * 5);
            }
        }
    }
}

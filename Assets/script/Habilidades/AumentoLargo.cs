using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoLargo : MonoBehaviour
{
    public mazo deck;
    bool activate = false;
    int i = 0;
   
    public void Activar()
    {
        if (GetComponent<cartas>().faccion == "monster")
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
            for (int i = 0; i < 5; i++)
            {
                if (deck.largo[i])
                {
                    i++;
                }
            }
            if (GetComponent<cartas>().faccion == "monster")
            {
                GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().poder1 += i;
            }
            if (GetComponent<cartas>().faccion == "machine")
            {
                GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().poder2 += i;
            }
        }
    }
}


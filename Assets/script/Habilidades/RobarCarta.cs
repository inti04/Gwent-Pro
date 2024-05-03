using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobarCarta : MonoBehaviour
{
    public GameManager GameManager;
    

    public void Activar()
    {
        GameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        if (GetComponent<cartas>().faccion == "machine")
        {
            GameManager.mazo2.RobarCarta(1);
        }
        else
        {
            GameManager.mazo1.RobarCarta(1);
            GameManager.mazo1.PosicionarCartas();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botones : MonoBehaviour
{
    public int PosicionCarta;
    public mazo deck;
    public GameObject Panel;
    public GameManager GameManager;


    public void Activar_Invocacion()
    {
        if (deck.player == GameManager.turno && !GameManager.jugada)
        {
            Panel.GetComponent<Panel_Invocacion>().carta = PosicionCarta;
            Panel.GetComponent<Panel_Invocacion>().mazos = deck;
            Panel.transform.localScale = Vector3.one;
        }
        

    }

}

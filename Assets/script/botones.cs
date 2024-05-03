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
            if(!GameManager.inicio1 && GameManager.turno == 1 || !GameManager.inicio2 && GameManager.turno == 2)
            {
                Panel.GetComponent<Panel_Invocacion>().carta = PosicionCarta;
                Panel.GetComponent<Panel_Invocacion>().mazos = deck;
                Panel.transform.localScale = Vector3.one;
            }
            
        }
        if (GameManager.inicio1 && GameManager.turno == 1)
        {
            deck.hand.RemoveAt(PosicionCarta);
            deck.RobarCarta(1);
            GameManager.cont++;
            deck.PosicionarCartas();
            if(GameManager.cont == 2)
            {
                GameManager.cont = 0;
                GameManager.inicio1 = false;
                GameManager.buton.SetActive(false);
            }
        }
        if (GameManager.inicio2 && GameManager.turno == 2)
        {
            deck.hand.RemoveAt(PosicionCarta);
            deck.RobarCarta(1);
            deck.PosicionarCartas();
            GameManager.cont++;
            if (GameManager.cont == 2)
            {
                GameManager.cont = 0;
                GameManager.inicio2= false;
                GameManager.buton.SetActive(false);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminaCartaMenosPoder : MonoBehaviour
{
    public GameManager GameManager;
    
    public void Activar()
    {
        GameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        int poder = 100;
        int pos = 0;
        mazo mazo = new mazo();
        int atk = 0;
        for(int i = 0; i < 5; i++)
        {
            if(GameManager.mazo1.CortoAlcance[i].texture != null)
            {
                if (poder > GameManager.mazo1.CortoAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder)
                {
                    pos = i;
                    poder = GameManager.mazo1.CortoAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder;
                    mazo = GameManager.mazo1;
                    atk = 1;
                }
            }         
            if(GameManager.mazo1.MedioAlcance[i].texture != null)
            {
                if (poder > GameManager.mazo1.MedioAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder)
                {
                    pos = i;
                    poder = GameManager.mazo1.MedioAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder;
                    mazo = GameManager.mazo1;
                    atk = 2;
                }
            }
            if(GameManager.mazo1.LargoAlcance[i].texture != null)
            {
                if (poder > GameManager.mazo1.LargoAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder)
                {                            
                    pos = i;                  
                    poder = GameManager.mazo1.LargoAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder;
                    mazo = GameManager.mazo1;
                    atk = 3;
                }                             
            }
            if (GameManager.mazo2.CortoAlcance[i].texture != null)
            {
                if (poder > GameManager.mazo2.CortoAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder)
                {
                    pos = i;
                    poder = GameManager.mazo2.CortoAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder;
                    mazo = GameManager.mazo1;
                    atk = 1;
                }
            }
            if (GameManager.mazo2.MedioAlcance[i].texture != null)
            {
                if (poder > GameManager.mazo2.MedioAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder)
                {
                    pos = i;
                    poder = GameManager.mazo2.MedioAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder;
                    mazo = GameManager.mazo1;
                    atk = 2;
                }
            }
            if (GameManager.mazo2.LargoAlcance[i].texture != null)
            {
                if (poder > GameManager.mazo2.LargoAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder)
                {
                    pos = i;
                    poder = GameManager.mazo2.LargoAlcance[i].GetComponent<cartalure>().carta.GetComponent<cartaunidad>().poder;
                    mazo = GameManager.mazo1;
                    atk = 3;
                }
            }

        }

        if(atk != 0)
            {
            if (atk == 1)
            {
                mazo.CortoAlcance[pos].texture = null;
                mazo.CortoAlcance[pos].GetComponent<cartalure>().carta = null;
                mazo.Corto[pos] = false;
            }
            if (atk == 2)
            {
                mazo.MedioAlcance[pos].texture = null;
                mazo.MedioAlcance[pos].GetComponent<cartalure>().carta = null;
                mazo.medio[pos] = false;
            }
            if (atk == 3)
            {
                mazo.LargoAlcance[pos].texture = null;
                mazo.LargoAlcance[pos].GetComponent<cartalure>().carta = null;
                mazo.largo[pos] = false;
            }
            if(mazo.player == 1)
            {
                GameManager.poder1 -= poder;
            }
            if (mazo.player == 2)
            {
                GameManager.poder2 -= poder;
            }
        }
        
    }
}

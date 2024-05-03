using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cartalure : MonoBehaviour
{
    public mazo mazo;
    public GameObject carta;
    public void cambio()
    {
        //Funcion para guardar gameobject para el cambio con el lure
        if(mazo.Lure != null)
        {
            Texture texture = GetComponent<RawImage>().texture;
            GetComponent<RawImage>().texture = mazo.Lure.GetComponent<SpriteRenderer>().sprite.texture;
            mazo.pics[mazo.poslure].texture = texture;
            mazo.hand[mazo.poslure] = carta;
            if(mazo.player == 1)
            {
                GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().poder1 -= carta.GetComponent<cartaunidad>().poder;
            }
            if (mazo.player == 2)
            {
                GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().poder2 -= carta.GetComponent<cartaunidad>().poder;
            }
        }
    }
}

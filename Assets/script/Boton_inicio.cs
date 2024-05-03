using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_inicio : MonoBehaviour
{
    public GameManager GameManager;
    public int num;
    public void desactivate1()
    {
        if(num == 0)
        {
            GameManager.inicio1 = false;
        }
        else
        {
            GameManager.inicio2 = false;
        }
        GameManager.cont = 0;
        gameObject.SetActive(false);
    }
}

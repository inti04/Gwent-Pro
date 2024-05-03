using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clima : MonoBehaviour
{
    private GameManager manager;
    public string afecta;
    public int power1,power2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(!manager.hecho)
        {
            Conteo();
        }
        
    }
    private void Conteo()
    {
        if (GetComponent<RawImage>().texture != null)
        {
            //funcion para quitar y poner poder en el campo
            manager.poder1 -= power1;
            manager.poder2 -= power2;
            power1 = 0;
            power2 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (afecta == "corto")
                {
                    if (manager.mazo1.Corto[i])
                    {
                        power1 -= 1;
                    }
                    if (manager.mazo2.Corto[i])
                    {
                        power2 -= 1;
                    }
                }

                if (afecta == "medio")
                {
                    if (manager.mazo1.medio[i])
                    {
                        power1 -= 1;
                    }
                    if (manager.mazo2.medio[i])
                    {
                        power2 -= 1;
                    }
                }

                if (afecta == "largo")
                {
                    if (manager.mazo1.largo[i])
                    {
                        power1-= 1;
                    }
                    if (manager.mazo2.largo[i])
                    {
                        power2 -= 1;
                    }
                }
            }
            manager.poder1 += power1;
            manager.poder2 += power2;
            manager.hecho = true;
        }       
    }

    public void Eliminar()
    {
        manager.poder1 -= power1;
        manager.poder2 -= power2;
    }
}

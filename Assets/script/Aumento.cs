using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aumento : MonoBehaviour
{
    private GameManager manager;
    public string afecta;
    public int power,deck = 0;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!manager.hecho2)
        {
            Conteo1();
        }

        if (!manager.hecho3)
        {
            Conteo2();
        }
    }
    //Funcion para sumar y restar
    private void Conteo2()
    {
        if (deck == 2)
        {
            manager.poder2 -= power;
        }
        power = 0;
        for (int i = 0; i < 5; i++)
        {
            if (afecta == "corto" && deck == 2)
            {
                if (manager.mazo2.Corto[i])
                {
                    power += 1;
                }

            }

            if (afecta == "medio" && deck == 2)
            {
                if (manager.mazo2.medio[i])
                {
                    power += 1;
                }

            }

            if (afecta == "largo" && deck == 2)
            {
                if (manager.mazo2.largo[i])
                {
                    power += 1;
                }

            }
        }
        if (deck == 2)
        {
            manager.poder2 += power;
        }
        manager.hecho3 = true;
    }
    private void Conteo1()
    {
        if (GetComponent<RawImage>().texture != null)
        {
            if (deck == 1)
            {
                manager.poder1 -= power;
            }
            
            power = 0;
            for (int i = 0; i < 5; i++)
            {
                if (afecta == "corto" && deck == 1)
                {
                    if (manager.mazo1.Corto[i])
                    {
                        power += 1;
                    }
                    
                }

                if (afecta == "medio" && deck == 1)
                {
                    if (manager.mazo1.medio[i])
                    {
                        power += 1;
                    }
                    
                }

                if (afecta == "largo" && deck == 1)
                {
                    if (manager.mazo1.largo[i])
                    {
                        power += 1;
                    }
                    
                }
                
            }
            if(deck == 1)
            {
                manager.poder1 += power;
            }
            
            manager.hecho2 = true;
        }
    }
}

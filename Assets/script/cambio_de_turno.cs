using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambio_de_turno : MonoBehaviour
{
    private bool camara1 = true;
    
    public GameObject Game,Panel;
    public GameManager gameManager;
    private void Start()
    {
        gameManager= GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
    }

    public void CambioDeTurno()
    {      
        if (camara1 && !gameManager.turn1)
        {
            if (!gameManager.turn2)
            {
                gameManager.turno = 2;               
                Game.transform.Rotate(new Vector3(0, 0, 180));
            }
            if (!gameManager.jugada)
            {
                gameManager.turn1 = true;
            }
        }
        else if(!gameManager.turn2)
        {
            if (!gameManager.turn1)
            {
                gameManager.turno = 1;               
                Game.transform.Rotate(new Vector3(0, 0, 180));
            }
            if (!gameManager.jugada)
            {
                gameManager.turn2 = true;
            }
        }
        if(!gameManager.turn1 || !gameManager.turn2)
        {
            camara1 = !camara1;
            gameManager.jugada = false;
            Panel.transform.localScale = Vector3.zero;
        }

    }


}

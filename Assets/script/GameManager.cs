using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public bool jugada,turn1,turn2 = false;
    public int turno = 1;
    public int poder1 = 0;
    public int poder2 = 0;
    public TextMeshProUGUI Text1, Text2,Ganador;
    public mazo mazo1, mazo2;
    public bool EndRound,End_Game,hecho,hecho2,hecho3 = false;
    public int rondas1, rondas2,cont = 0;
    public bool inicio1,inicio2 = true;
    public GameObject buton;
    private void Update()
    {
        if(!End_Game)
        {
            Poderes();
            Round_End();
        }       
        END_GAME();
    }

    //Verificar si la ronda termino y sumar puntos
    private void Round_End()
    {
        if (turn1 && turn2)
        {
            EndRound = true;
            string ganador = "Empate";
            if(poder1 > poder2)
            {
                ganador = "Jugador 1 Win";
                rondas1++;
            }
            else if(poder1 < poder2)
            {
                ganador = "Jugador2 Win";
                rondas2++;
            }
            Ganador.text = ganador;
            Ganador.enabled = true;
            turn1 = false;
            turn2 = false;
            poder1 = 0;
            poder2 = 0;
            mazo1.RobarCarta(2);
            mazo1.PosicionarCartas();
            mazo2.RobarCarta(2);
            mazo2.PosicionarCartas();
            vaciate();
            StartCoroutine(Desactiva());
        }
    }

    //Terminar juego
    private void END_GAME()
    {
        if(rondas1 == 2)
        {
            End_Game = true;
            EndRound = true;
            turn1 = true;
            turn2 = true;
            jugada = true;
            Ganador.text = "El Ganador del juego es el jugador 1";
            StopAllCoroutines();
        }
        if(rondas2 == 2)
        {
            End_Game = true;
            EndRound = true;
            turn1 = true;
            turn2 = true;
            jugada = true;
            Ganador.text = "El Ganador del juego es el jugador 2";
            StopAllCoroutines();
        }
    }

    //puntos en todo momento del juego
    private void Poderes()
    {
        if (turno == 1)
        {
            Text1.text = "";
            Text2.text = "";
            Text1.text = poder1.ToString();
            Text2.text = poder2.ToString();
        }
        if (turno == 2)
        {
            Text2.text = "";
            Text1.text = "";
            Text2.text = poder1.ToString();
            Text1.text = poder2.ToString();
        }
    }
    IEnumerator Desactiva()
    {
        yield return new WaitForSeconds(4);
        Ganador.enabled = false;
        EndRound = false;
        mazo1.RobarCarta(2);
        mazo2.RobarCarta(2);   
        StopAllCoroutines();
    }

    //vaciar el campo
    public void vaciate()
    {
        for(int i = 0; i < 5; i++)
        {
            mazo1.Cementerio.texture = mazo1.CortoAlcance[i].texture;
            mazo2.Cementerio.texture = mazo2.CortoAlcance[i].texture;
            mazo1.CortoAlcance[i].texture = null;
            mazo1.MedioAlcance[i].texture = null;
            mazo1.LargoAlcance[i].texture = null;
            mazo1.Corto[i] = false;
            mazo1.medio[i] = false;
            mazo1.largo[i] = false;
            mazo2.CortoAlcance[i].texture = null;
            mazo2.MedioAlcance[i].texture = null;
            mazo2.LargoAlcance[i].texture = null;
            mazo2.Corto[i] = false;
            mazo2.medio[i] = false;
            mazo2.largo[i] = false;
        }
        for (int i = 0; i < 3; i++)
        {
            mazo1.Aumento[i].texture = null;
            mazo1.Clima[i].texture = null;          
            mazo1.aumento[i] = false;
            mazo1.clima[i] = false;
            mazo2.Aumento[i].texture = null;
            mazo2.Clima[i].texture = null;
            mazo2.aumento[i] = false;
            mazo2.clima[i] = false;
        }
    }
}

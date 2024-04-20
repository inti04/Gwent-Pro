using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class mazo : MonoBehaviour
{
    public GameObject[] mazos = new GameObject[42];
    public List<GameObject> hand = new List<GameObject>();
    public RawImage[] pics = new RawImage[10];
    private int Post_Robo = 0;
    public RawImage[] CortoAlcance = new RawImage[5];
    public RawImage[] MedioAlcance = new RawImage[5];
    public RawImage[] LargoAlcance = new RawImage[5];
    public RawImage[] Aumento = new RawImage[3];
    public RawImage[] Clima = new RawImage[3];
    public RawImage Despeje;
    public bool[] Corto = new bool[5];
    public bool[] medio = new bool[5];
    public bool[] largo = new bool[5] ;
    public bool[] aumento = new bool[3];
    public bool[] clima = new bool[3] ;
    private GameManager gameManager;
    public RawImage Cementerio;
    public int player;
    public void PosicionarCartas()
    
    {
        for (int i = 0; i < pics.Length; i++)
        {
            pics[i].texture = hand[i].GetComponent<SpriteRenderer>().sprite.texture;
        }
    }


    public void RobarCarta(int cartas)
    {
        for (int RoboRecorrido = 0; RoboRecorrido < cartas; RoboRecorrido++)
        {
            if (hand.Count < 10)
            {
                hand.Add(mazos[Post_Robo]);
                Post_Robo++;
            }
            else
            {
                Cementerio.texture = mazos[Post_Robo].GetComponent<SpriteRenderer>().sprite.texture;
                Post_Robo++;
            }
        }
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        Barajear_Carta();
        RobarCarta(10);
        PosicionarCartas();
    }
    private void Barajear_Carta()
    {
        for (int CartaRecorrido = 0; CartaRecorrido < mazos.Length; CartaRecorrido++)
        {
            int CartaRandom = Random.Range(0, mazos.Length);
            GameObject card = mazos[CartaRecorrido];
            mazos[CartaRecorrido] = mazos[CartaRandom];
            mazos[CartaRandom] = card;
        }
    }
    public void Invocar_Carta(int cardPosition,string campo)
    {
        if(!gameManager.jugada)
        {
            if(gameManager.turno == player)
            {
                bool invocada = false;
                //Melee
                for (int i = 0; i < Corto.Length; i++)
                {
                    if (Corto[i] == false && !invocada && pics[cardPosition].texture != null)
                    {
                        if (Verificar_Posicion("corto", hand[cardPosition], campo))
                        {
                            CortoAlcance[i].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                            Corto[i] = true;
                            invocada = true;
                            gameManager.hecho = false;
                            gameManager.hecho2 = false;
                            if (gameObject.CompareTag("Poke1") && hand[cardPosition].GetComponent<cartas>().TipoDecarta != "señuelo")
                            {
                                gameManager.poder1 += hand[cardPosition].GetComponent<cartaunidad>().poder;
                            }
                            if (gameObject.CompareTag("Poke2") && hand[cardPosition].GetComponent<cartas>().TipoDecarta != "señuelo")
                            {
                                gameManager.poder2 += hand[cardPosition].GetComponent<cartaunidad>().poder;
                            }
                            hand[cardPosition] = null;
                            pics[cardPosition].texture = null;
                            gameManager.jugada =true;                          
                            break;
                        }

                    }
                }
                //Range
                for (int i = 0; i < medio.Length; i++)
                {
                    if (medio[i] == false && !invocada && pics[cardPosition].texture != null)
                    {
                        if (Verificar_Posicion("medio", hand[cardPosition], campo))
                        {
                            MedioAlcance[i].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                            medio[i] = true;
                            invocada = true;
                            gameManager.hecho = false;
                            gameManager.hecho2 = false;
                            if (gameObject.CompareTag("Poke1") && hand[cardPosition].GetComponent<cartas>().TipoDecarta != "señuelo")
                            {
                                gameManager.poder1 += hand[cardPosition].GetComponent<cartaunidad>().poder;
                            }
                            if (gameObject.CompareTag("Poke2") && hand[cardPosition].GetComponent<cartas>().TipoDecarta != "señuelo")
                            {
                                gameManager.poder2 += hand[cardPosition].GetComponent<cartaunidad>().poder;
                            }
                            hand[cardPosition] = null;
                            pics[cardPosition].texture = null;
                            gameManager.jugada =true;
                            break;
                        }

                    }
                }
                //Asedio
                for (int i = 0; i < largo.Length; i++)
                {
                    if (largo[i] == false && !invocada && pics[cardPosition].texture != null)
                    {
                        if (Verificar_Posicion("largo", hand[cardPosition], campo))
                        {
                            LargoAlcance[i].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                            largo[i] = true;
                            invocada = true;
                            gameManager.hecho = false;
                            gameManager.hecho2 = false;
                            if (gameObject.CompareTag("Poke1") && hand[cardPosition].GetComponent<cartas>().TipoDecarta != "señuelo")
                            {
                                gameManager.poder1 += hand[cardPosition].GetComponent<cartaunidad>().poder;
                            }
                            if (gameObject.CompareTag("Poke2") && hand[cardPosition].GetComponent<cartas>().TipoDecarta != "señuelo")
                            {
                                gameManager.poder2 += hand[cardPosition].GetComponent<cartaunidad>().poder;
                            }
                            hand[cardPosition] = null;
                            pics[cardPosition].texture = null;
                            gameManager.jugada=true;
                            break;
                        }

                    }
                }
                //Aumento
                if (aumento[0] == false && !invocada && pics[cardPosition].texture != null && Verificar_Posicion("Acorto", hand[cardPosition], campo) )
                {
                    Aumento[0].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                    aumento[0] = true;
                    hand[cardPosition] = null;
                    pics[cardPosition].texture = null;
                    gameManager.jugada = true;
                }
                if (aumento[1] == false && !invocada && pics[cardPosition].texture != null && Verificar_Posicion("Amedio", hand[cardPosition], campo))
                {
                    Aumento[1].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                    aumento[1] = true;
                    hand[cardPosition] = null;
                    pics[cardPosition].texture = null;
                    gameManager.jugada = true;

                }
                if (aumento[2] == false && !invocada && pics[cardPosition].texture != null && Verificar_Posicion("Alargo", hand[cardPosition], campo))
                {
                    Aumento[2].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                    aumento[2] = true;
                    hand[cardPosition] = null;
                    pics[cardPosition].texture = null;
                    gameManager.jugada = true;
                }
                //Climas
                if (clima[0] == false && !invocada && pics[cardPosition].texture != null && Verificar_Posicion("Ccorto", hand[cardPosition], campo))
                {
                    Clima[0].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                    clima[0] = true;
                    hand[cardPosition] = null;
                    pics[cardPosition].texture = null;
                    gameManager.jugada = true;
                }
                if (clima[1] == false && !invocada && pics[cardPosition].texture != null && Verificar_Posicion("Cmedio", hand[cardPosition], campo))
                {
                    Clima[1].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                    clima[1] = true;
                    hand[cardPosition] = null;
                    pics[cardPosition].texture = null;
                    gameManager.jugada = true;

                }
                if (clima[2] == false && !invocada && pics[cardPosition].texture != null && Verificar_Posicion("Clargo", hand[cardPosition], campo))
                {   
                    Clima[2].texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                    clima[2] = true;
                    hand[cardPosition] = null;
                    pics[cardPosition].texture = null;
                    gameManager.jugada = true;
                }
                //Despeje
                if (Despeje.texture == null && !invocada && pics[cardPosition].texture != null && Verificar_Posicion("despeje", hand[cardPosition], campo))
                {
                    Despeje.texture = hand[cardPosition].GetComponent<SpriteRenderer>().sprite.texture;
                    hand[cardPosition] = null;
                    pics[cardPosition].texture = null;
                    gameManager.jugada = true;
                }

                if(gameManager.jugada)
                {
                    hand.RemoveAt(cardPosition);
                }
            }
    }
    
    }
    public bool Verificar_Posicion(string alcance, GameObject card, string campo)
    {
        string[] posiciones = card.GetComponent<cartas>().PosicionCampo.Split("-");
        for (int i = 0; i < posiciones.Length; i++)
        {
            if (posiciones[i] == alcance)
            {
                
                if (alcance == campo)
                {
                    
                    return true;
                }

                string s = "A";
                if(s+campo ==alcance)
                {
                    return true;
                }
                string f = "C";
                if (f + campo == alcance)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
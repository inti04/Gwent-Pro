using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Invocacion : MonoBehaviour
{
    public int carta;
    public mazo mazos;
    public void Activar(string campo)
    {
        mazos.Invocar_Carta(carta,campo);
    }
}

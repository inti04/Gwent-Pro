using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class definir_invocacion : MonoBehaviour
{
    public string tipo;
    public Panel_Invocacion invocar;

        public void activar()
    {
        invocar.Activar(tipo);
        invocar.gameObject.transform.localScale = Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Esconder_Imagen : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        //Ocultar RawImage si no tiene imagen
        if(GetComponent<RawImage>().texture == null)
        {
            transform.localScale = Vector3.zero;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}

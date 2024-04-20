using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Despeje : MonoBehaviour
{
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameObject.GetComponent<RawImage>().texture != null)
        {
            for (int i = 0; i < 3; i++)
            {
                manager.mazo1.clima[i] = false;
                manager.mazo1.Clima[i].texture = null;
                manager.mazo2.Clima[i].GetComponent<Clima>().Eliminar();

            }
            for (int i = 0; i < 3; i++)
            {
                manager.mazo2.clima[i] = false;
                manager.mazo2.Clima[i].texture = null;
                manager.mazo2.Clima[i].GetComponent<Clima>().Eliminar();
            }
            StartCoroutine(Destroy());
        }
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(6);
        GetComponent<RawImage>().texture = null;
    }
}

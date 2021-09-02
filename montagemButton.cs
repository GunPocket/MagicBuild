using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class montagemButton : MonoBehaviour
{
    public GameObject encomenda;
    public GameObject encomenda2;
    private bool det = false;

    private void Start()
    {
        encomenda.SetActive(true);
        encomenda2.SetActive(true);
    }

    public void active()
    {
        if (!det)
        {
            encomenda.transform.localPosition = new Vector3(0f, -780f, 0f);
            det = true;
        }
        else
        {
            encomenda.transform.localPosition = new Vector3(0f, 0f, 0f);
            det = false;
        }
        encomenda2.transform.Rotate(0, 0, 180);
    }
}
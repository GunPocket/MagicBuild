using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class montageButtonPeca : MonoBehaviour
{
    public GameObject encomenda;
    public GameObject encomenda2;
    public GameObject gbn;
    public GameObject mb;
    public GameObject peca;
    public GameObject pecaBtn;
    public GameObject escolhaPeca;
    public GameObject pecaDesc;
    public GameObject pecaImg;
    public GameObject vazio;

    public GameObject montagem;
    public GameObject pecas;

    public GameObject pecaInGabinete;

    public GameObject certo;
    public GameObject errado;

    public GameObject itemPecas;

    private bool descAtiv = false;

    private void Start()
    {
        encomenda.SetActive(true);
        encomenda2.SetActive(true);
        peca.SetActive(false);
        pecaBtn.SetActive(true);
        pecaImg.SetActive(false);
        pecas.SetActive(false);
    }

    public void addPeca()
    {
        peca.SetActive(true);
        pecaDesc.SetActive(false);
        pecaImg.SetActive(false);
        pecaBtn.SetActive(false);
    }

    public void descPeca()
    {
        if (!descAtiv)
        {
            pecaDesc.SetActive(true);
            pecaImg.SetActive(true);
            encomenda.SetActive(false);
            encomenda2.SetActive(false);
            vazio.SetActive(false);
            itemPecas.SetActive(false);
            descAtiv = true;
        }
        else
        {
            pecaDesc.SetActive(false);
            pecaImg.SetActive(false);
            encomenda.SetActive(true);
            encomenda2.SetActive(true);
            vazio.SetActive(true);
            itemPecas.SetActive(true);
            descAtiv = false;
        }
    }

    public void drawPeca()
    {
        vazio.SetActive(false);
    }

    public void chooseaGabinete()
    {
        encomenda.SetActive(true);
        encomenda2.SetActive(true);
        gbn.SetActive(true);
        mb.SetActive(true);
        peca.SetActive(false);
        pecaBtn.SetActive(false);
        vazio.SetActive(false);
        pecaDesc.SetActive(false);
        pecaImg.SetActive(true);
        pecaImg.transform.localPosition = new Vector3 (634f, 232f, 0f);
        pecas.SetActive(true);
    }

    public void choosePeca()
    {
        encomenda.SetActive(true);
        encomenda2.SetActive(true);
        escolhaPeca.SetActive(false);
        pecaDesc.SetActive(false);
        pecaBtn.SetActive(true);
        peca.SetActive(false);
        certo.SetActive(true);
        errado.SetActive(false);
        pecaImg.SetActive(false);
        itemPecas.SetActive(true);
        pecaInGabinete.SetActive(true);
    }

    public void montagemBegin()
    {
        montagem.SetActive(true);

    }
}

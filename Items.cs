using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public List<Peca> pecaInspector;
    private static List<Peca> peca;

    private void Start()
    {
        peca = pecaInspector;

    }

    public static Peca getPeca(int id)
    {
        Peca peca = new Peca();
        peca.image = Items.peca[id].image;
        peca.width = Items.peca[id].width;
        peca.height = Items.peca[id].height;

        peca.hasInventory = Items.peca[id].hasInventory;
        peca.gridX = Items.peca[id].gridX;
        peca.gridY = Items.peca[id].gridY;
        return peca;
    }
}

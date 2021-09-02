using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public abstract class Item
{
    public Texture2D image;
    public int x;
    public int y;
    public int width;
    public int height;

    public bool hasInventory = false;
    public int gridX;
    public int gridY;
    public abstract void performAction();
}
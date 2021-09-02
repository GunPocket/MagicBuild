using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItem : MonoBehaviour
{
    public static Inventory inventory;
    public static Inventory moBor;
    public static montagemPecas pecas;
    public GameObject gui;
    public GameObject MB;
    public GameObject sceneControl;
    public int itemRep;

    public Texture2D image;
    public Rect position;
    public int itemSize;
    public bool isMB = false;
    public int gridX;
    public int gridY;
    public bool inMB;

    public void OnGUI()
    {
            drawGUI();
            detectGUIAction();
    }

    private void Start()
    {
        inventory = gui.GetComponent<Inventory>();
        moBor = MB.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void drawGUI()
    {
        GUI.DrawTexture(new Rect(position.x,
                                 position.y,
                                 itemSize, itemSize), image);
    }

    void detectGUIAction()
    {
        if ((Input.mousePosition.x > position.x && Input.mousePosition.x < position.x + itemSize) &&
            (Screen.height - Input.mousePosition.y > position.y && Screen.height - Input.mousePosition.y < position.y + itemSize) &&
            (Event.current.isMouse && Input.GetMouseButtonDown(0)))
        {
            detectMouseAction();
        }
    }

    public void detectMouseAction()
    {
        if (inMB)
        {
            moBor.addItem(Items.getPeca(itemRep));
        }

        if (!inMB)
        {
            inventory.addItem(Items.getPeca(itemRep));
        }

        if (isMB)
        {
            inventory.createMB(gui, (int)position.width, (int)position.height, gridX, gridY);
        }
        
        sceneControl.GetComponent<montagemPecas>().PecasColocadas ++;
        Destroy(gameObject);
    }
}
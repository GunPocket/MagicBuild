using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject MB;
    public Texture2D image;
    private Rect position;
    private Rect positionMB;

    public int sizeX = 3;
    public int sizeY = 2;
    public int posX = 0;
    public int posY = 0;

    public int slotSize = 100;
    private int inventoryX;
    private int inventoryY;

    public List<Item> items = new List<Item>();
    public Slots[,] slots;

    private Item temp;
    private Vector2 selected;
    private Vector2 secondSelected;

    private bool hasMB = false;
    private int itemSlotSize;
    private int MBposX;
    private int MBposY;

    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        setSlots();
        if (test)
            gameObject.SetActive(false);
    }

    public void setSlots()
    {
        slots = new Slots[sizeX, sizeY];

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                slots[x, y] = new Slots(new Rect(sizeX + slotSize * x, sizeY + slotSize * y, slotSize, slotSize));
            }
        }
    }

    public void OnGUI()
    {
        drawInventory();
        drawSlots();
        drawItem();
        detectGUIAction();
        drawTempItem();
        if (hasMB)
        {
            drawMB();
        }
    }

    public void drawItem()
    {
        for (int count = 0; count < items.Count; count++)
        {
            GUI.DrawTexture(new Rect(position.x + items[count].x * slotSize + 4,
                                     position.y + items[count].y * slotSize + 4,
                                     items[count].width * slotSize - 8,
                                     items[count].height * slotSize - 8),
                                     items[count].image);
        }
    }

    public void drawTempItem()
    {

        if (temp != null)
        {
            GUI.DrawTexture(new Rect(Input.mousePosition.x - slotSize / 2 + 8,
                                     Screen.height - Input.mousePosition.y - slotSize / 2 + 8,
                                     temp.width * slotSize - 8,
                                     temp.height * slotSize - 8),
                                     temp.image);
        }
    }

    public bool addItem(Item item)
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                if (addItem(x, y, item))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool addItem(int x, int y, Item item)
    {
        for (int sX = 0; sX < item.width; sX++)
        {
            for (int sY = 0; sY < item.height; sY++)
            {
                if (slots[x, y].occupied)
                {
                    return false;
                }
            }
        }

        if (x + item.width > sizeX || y + item.height > sizeY)
        {
            return false;
        }
        item.x = x;
        item.y = y;
        items.Add(item);
        if (item.hasInventory)
        {
            MBposX = item.x;
            MBposY = item.y;
        }

        for (int sX = x; sX < item.width + x; sX++)
        {
            for (int sY = y; sY < item.height + y; sY++)
            {
                slots[sX, sY].occupied = true;
            }
        }
        return true;
    }

    public void removeItem(Item item)
    {
        for (int x = item.x; x < item.x + item.width; x++)
        {
            for (int y = item.y; y < item.y + item.height; y++)
            {
                slots[x, y].occupied = false;
            }
        }
        items.Remove(item);
    }

    public void drawSlots()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                slots[x, y].draw(position.x, position.y);
            }
        }
    }

    public void detectGUIAction()
    {
        if (Input.mousePosition.x > positionMB.x + MBposX * slotSize && Input.mousePosition.x < positionMB.x + positionMB.width + MBposX * slotSize)
        {
            if (Screen.height - Input.mousePosition.y > positionMB.y + MBposY * slotSize && Screen.height - Input.mousePosition.y < positionMB.y + positionMB.height + MBposY * slotSize)
            {
                return;
            }
        }

        if (Input.mousePosition.x > position.x && Input.mousePosition.x < position.x + position.width)
        {
            if (Screen.height - Input.mousePosition.y > position.y && Screen.height - Input.mousePosition.y < position.y + position.height)
            {
                detectMouseAction();
            }
        }
    }

    public void detectMouseAction()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Rect slot = new Rect(position.x + slots[x, y].position.x,
                                     position.y + slots[x, y].position.y,
                                     slotSize, slotSize);

                if (slot.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
                {
                    if (Event.current.isMouse && Input.GetMouseButtonDown(0))
                    {
                        selected.x = x;
                        selected.y = y;

                        for (int i = 0; i < items.Count; i++)
                        {
                            for (int countX = items[i].x; countX < items[i].x + items[i].width; countX++)
                            {
                                for (int countY = items[i].y; countY < items[i].y + items[i].height; countY++)
                                {
                                    if (countX == x && countY == y)
                                    {
                                        temp = items[i];
                                        removeItem(temp);
                                        return;
                                    }
                                }
                            }
                        }

                    }
                    else if (Event.current.isMouse && Input.GetMouseButtonUp(0))
                    {
                        secondSelected.x = x;
                        secondSelected.y = y;

                        if (secondSelected.x != selected.x || secondSelected.y != selected.y)
                        {
                            if (temp != null)
                            {
                                if (addItem((int)secondSelected.x, (int)secondSelected.y, temp))
                                {
                                }
                                else
                                {
                                    addItem(temp.x, temp.y, temp);
                                }
                                temp = null;
                            }
                        }
                        else
                        {
                            addItem(temp.x, temp.y, temp);
                            temp = null;
                        }
                    }
                    return;
                }
            }
        }
    }

    public void drawInventory()
    {
        position.x = posX;
        position.y = posY;

        position.width = sizeX * slotSize;
        position.height = sizeY * slotSize;

        inventoryX = slotSize * sizeX;
        inventoryY = slotSize * sizeY;

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                GUI.DrawTexture(new Rect(position.x + (i * slotSize),
                                         position.y + (j * slotSize),
                                         slotSize,
                                         slotSize),
                                         image);
            }
        }
    }

    public void createMB(GameObject other, int pW, int pH, int gridX, int gridY)
    {
        hasMB = true;

        int itsX = (int)((slotSize * pW / gridX) * 0.9);
        int itsY = (int)((slotSize * pH / gridY) * 0.9);

        if (itsX < itsY)
        {
            itemSlotSize = itsX;
        }
        else
        {
            itemSlotSize = itsY;
        }


        MB.GetComponent<Inventory>().sizeX = gridX;
        MB.GetComponent<Inventory>().sizeY = gridY;
        MB.GetComponent<Inventory>().slotSize = itemSlotSize;
        MB.GetComponent<Inventory>().setSlots();

        int centX = (slotSize * pW - itemSlotSize * gridX) / 2;
        int centY = (slotSize * pH - itemSlotSize * gridY) / 2;

        positionMB.x = centX + position.x;
        positionMB.y = centY + position.y;

        positionMB.width = itemSlotSize * gridX;
        positionMB.height = itemSlotSize * gridY;
    }

    private void drawMB()
    {
        MB.GetComponent<Inventory>().posX = (int)positionMB.x + slotSize * MBposX;
        MB.GetComponent<Inventory>().posY = (int)positionMB.y + slotSize * MBposY;
    }
}
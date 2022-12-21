using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> objects = new List<Item>();
    public Item currentObject = null;
    public static Action<Item> OnCurrentItemChange;
    public static Action<int> OnItemDrop;
    public static Action<int, Item> OnItemChange;
    int currentObjIndx = 0;
    void Start()
    {
        if (objects.Count > 0)
        {
            currentObject = objects[0];
        }
    }
    void Update()
    {
        CheckInput();
    }
    void CheckInput()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            currentObjIndx--;
            if (currentObjIndx <= 0)
            {
                currentObjIndx = objects.Count - 1;
            }
            currentObject = objects[currentObjIndx];
            OnCurrentItemChange?.Invoke(currentObject);
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            currentObjIndx++;
            if (currentObjIndx >= objects.Count)
            {
                currentObjIndx = 0;
            }
            currentObject = objects[currentObjIndx];
            OnCurrentItemChange?.Invoke(currentObject);
        }

    }
}

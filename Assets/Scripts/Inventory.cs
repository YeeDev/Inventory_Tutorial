using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform inventorySpace = null;

    public void AddItem(GameObject itemToAdd)
    {
        Instantiate(itemToAdd, inventorySpace);
    }
}

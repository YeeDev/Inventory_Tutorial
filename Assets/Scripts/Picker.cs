using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Always use CompareTag, it is way faster.
        if (collision.CompareTag("Item"))
        {
            inventory.AddItem(collision.GetComponent<Itemizer>().GetItemToAdd);
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Always use CompareTag, it is way faster.
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
        }
    }
}

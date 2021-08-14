using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemizer : MonoBehaviour
{
    [SerializeField] GameObject itemToAdd;

    public GameObject GetItemToAdd { get => itemToAdd; }
}

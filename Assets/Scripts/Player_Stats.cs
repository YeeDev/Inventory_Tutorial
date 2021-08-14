using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    [SerializeField] float currentHp = 0;
    [SerializeField] float currentMp = 0;

    UI_Controller uI;

    private void Awake()
    {
        uI = FindObjectOfType<UI_Controller>();
    }

    //Set the size of the stats bars based on "current" variables.
    private void Start()
    {
        uI.SetBarSize(true, currentHp);
        uI.SetBarSize(false, currentMp);
    }
}

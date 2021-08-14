using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    [Header("Health Points")]
    [Range(1, 10)][SerializeField] float currentHp = 0;
    [Range(1, 10)] [SerializeField] float maxHP = 3;
    [Header("Magic Points")]
    [Range(1, 10)] [SerializeField] float currentMp = 0;
    [Range(1, 10)] [SerializeField] float maxMP = 10;

    UI_Controller uI;

    private void Awake()
    {
        uI = FindObjectOfType<UI_Controller>();
        ClampCurrentValues();
    }

    //Prevents having unwanted values, like having a current HP larger than max HP.
    //You could create a Custom Inspector to save you this lines of code!
    private void ClampCurrentValues()
    {
        currentHp = Mathf.Clamp(currentHp, 1, maxHP);
        currentMp = Mathf.Clamp(currentMp, 1, maxMP);
    }

    //This is called in Start instead of Awake to avoid racing issues.
    private void Start()
    {
        InitializeUI();
    }

    //Set the size of the stats bars based on "current" variables.
    private void InitializeUI()
    {
        uI.SetMaxSize(maxHP, maxMP);
        uI.SetBarSize(true, currentHp);
        uI.SetBarSize(false, currentMp);
    }
}

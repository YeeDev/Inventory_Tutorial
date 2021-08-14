using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    //The sizes are serialized in case the sprites change later on.
    //You could always code getting this value, but I find it easier this way.
    [Header("Health Power")]
    [Tooltip("Based on the Heart Bar single heart width value")]
    [SerializeField] float hPSizePerPoint = 0;
    [SerializeField] RectTransform heartBar = null;

    //In the case of the mana size per point, it should be coded based on the mana maximum value.
    //But for simplicity purposes I serialized it.
    [Header("Magic Power")]
    [Tooltip("Based on the Mana Bar max width value divided by the max number of mana points")]
    [SerializeField] float mPSizePerPoint = 0;
    [SerializeField] RectTransform manaBar = null;

    float maxHPSize;
    float maxMPSize;

    //Sets the maximum width value.
    //Called from Player_Stats.
    public void SetMaxSize(float maxHP, float maxMP)
    {
        maxHPSize = hPSizePerPoint * maxHP;
        print(maxHPSize);
        maxMPSize = mPSizePerPoint * maxMP;
        print(maxMPSize);
    }

    //Adjust the size of any of the bars based on the passed bool.
    //Called from Player_Stats and ItemAbilities scripts.
    public void SetBarSize(bool adjustHealth, float amount)
    {
        float statToModify = adjustHealth ? hPSizePerPoint * amount : mPSizePerPoint * amount;
        float maxStatToUse = adjustHealth ? maxHPSize : maxMPSize; 
        RectTransform barToModify = adjustHealth ? heartBar : manaBar;

        Vector2 newSize = barToModify.sizeDelta;
        newSize.x += Mathf.Clamp(statToModify, 0, maxStatToUse);
        barToModify.sizeDelta = newSize;
    }
}

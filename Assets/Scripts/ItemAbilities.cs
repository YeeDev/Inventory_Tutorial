using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbilities : MonoBehaviour
{
    Player_Stats stats;

    private void Awake()
    {
        stats = FindObjectOfType<Player_Stats>();
    }

    //Called in button.
    public void RestoreHealth(float healthToRestore)
    {
        stats.ChangeHealth(healthToRestore);
        Destroy(gameObject);
    }

    //Called in button.
    public void RestoreMana(float manaToRestore)
    {
        stats.ChangeMana(manaToRestore);
        Destroy(gameObject);
    }
}

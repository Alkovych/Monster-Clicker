using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenefitHelper : MonoBehaviour
{
    [Header("Gold and Ruby variables")]

    private int monsterGold = 0; // Mons

    #region Monster Gold set and get functions
    public void SetGold(int monsterGold)
    {
        if (monsterGold >= 0 && monsterGold <= 1000000)
        {
            this.monsterGold = monsterGold;
        }
        else
        {
            Debug.Log("Out of index Array"); // Just for test
        }
    }
    public int GetGold()
    {
        return this.monsterGold;
    }
    #endregion

    public void GoldMonsterUpdateFunction(float _health)
    {
        monsterGold = (int)_health;

        //(int)Mathf.Sqrt()

    }
}

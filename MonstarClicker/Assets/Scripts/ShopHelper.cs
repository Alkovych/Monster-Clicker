using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHelper : MonoBehaviour
{
    private BenefitHelper benefitHelper;


    private int[] upgratePrice = new []{10,500,2000,5000,10000,20000};
    private int[] upgrateDamage = new []{1,50,200,500,1000,2000};

    void Start()
    {
        benefitHelper = GameObject.FindObjectOfType<BenefitHelper>();
    }

    public void UpgradeFunction(float _damage, int _level, int _tir)
    {
        int level = UgradeLevel(_level);
        int price = upgratePrice[_tir];

        Calculate(benefitHelper.GetGold(), price);

        float newPrice = price + (price * Mathf.Sqrt(level));

        upgratePrice[_tir] = (int)newPrice;
        return;
    }

    private int UgradeLevel(int _level)
    {
        return _level++;
    }

    private void Calculate(int currentPlayerGold , int price)
    {
        if (currentPlayerGold >= price)
        {
            currentPlayerGold -= price;
            benefitHelper.SetGold(currentPlayerGold);
        }
    }

}

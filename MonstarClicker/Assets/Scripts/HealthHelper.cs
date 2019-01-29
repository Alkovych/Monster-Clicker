using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HealthHelper : MonoBehaviour
{
    //Monster Health helper script located on Monster prafeb

    private GameHelper gameHelper;
    private BenefitHelper benefitHelper;
    private BarHelper barHelper;
    private float _health;


    [SerializeField]
    private float startHealth = 100;

    #region Player Gold Set and Get function
    public void SetMonsterHealth(float startHealth)
    {
        this.startHealth = startHealth;
    }
    public float GetGetmonsterHealth()
    {
        return this.startHealth;
    }
    #endregion

    void Start()
    {
        gameHelper = FindObjectOfType<GameHelper>();
        benefitHelper = FindObjectOfType<BenefitHelper>();
        barHelper = FindObjectOfType<BarHelper>();

        startHealth = barHelper.MonsterHealthUpdate(startHealth);
        benefitHelper.GoldMonsterUpdateFunction(startHealth);

        barHelper.HealtBar = startHealth;
        barHelper.HealthBarText = startHealth;
    }

    public void GetHitMethod(float damage)
    {
        _health = startHealth - damage;

        barHelper.HealthBarUpdate(_health);


        if (_health <= 0)
        {
            gameHelper.TakeGold(benefitHelper.GetGold());
            Destroy(gameObject);     

        }
        else
        {
            startHealth = _health;
        }
    }

}

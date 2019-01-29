using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHelper : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text healthBarText;

    private float monsterLevel;

    public float HealtBar
    {
        set { healthBar.fillAmount = value; }
    }

    public float HealthBarText
    {
        set { healthBarText.text = value.ToString(); }
    }

    public void HealthBarUpdate(float health)// checks monster health and updated after each hit from players or comrades
    {
        healthBar.fillAmount = health / 100.0f;
        healthBarText.text = health.ToString();
    }

    public float MonsterHealthUpdate(float health)
    {
        monsterLevel++;
        health += (Mathf.Pow(monsterLevel, 2) / 2);
        return health;
    }

}

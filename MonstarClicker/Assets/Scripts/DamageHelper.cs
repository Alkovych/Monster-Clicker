using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageHelper : MonoBehaviour {

    [Header("Text")]
    [SerializeField]
    private Text clickDamageText;
    [SerializeField]
    private Text comdaresDamageText;


    [Header("Variables")]
    private float clickDamage = 10.0f;
    private float comradesDamage = 0.0f;
    private int[] weaponsLevel = new[] {0, 0, 0, 0, 0, 0};

    public float ClickDamage {
        get { return clickDamage; }
    }

    public float ComradesDamage
    {
        get { return comradesDamage; }
    }



    private ShopHelper shopHelper;

    private void Start()
    {
        shopHelper = GameObject.FindObjectOfType<ShopHelper>();
    }

    private void Update ()
	{

	    clickDamageText.text = clickDamage.ToString();
	    comdaresDamageText.text = comradesDamage.ToString();

	}

    public void SetDamageFunction(int _tir)
    {

        int _level = weaponsLevel[_tir-1];

        shopHelper.UpgradeFunction(clickDamage, _level, _tir);
    }


}

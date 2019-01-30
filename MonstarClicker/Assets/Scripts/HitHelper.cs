using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour
{
    // Sctipts located on Monster prefab

    private ButtonHelper buttonHelper;
    private DamageHelper damageHelper;

    void Start()
    {
        buttonHelper = GameObject.FindObjectOfType<ButtonHelper>();
        damageHelper = GameObject.FindObjectOfType<DamageHelper>();
    }

    private void OnMouseDown()
    {
        if (buttonHelper.isPoused == false)
        {
            //Time.timeScale = 0;
            GetComponent<Animator>().SetTrigger("GetHit"); // Play Monster Hit animation when pressed left mouse button
            GetComponent<HealthHelper>().GetHitMethod(damageHelper.ClickDamage);
        }

    }
}

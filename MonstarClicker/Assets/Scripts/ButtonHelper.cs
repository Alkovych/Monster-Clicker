using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHelper : MonoBehaviour
{
    public bool isPoused = false;
    public bool isTurnedOf = false;

    public GameObject shopPanel;

    public void Shop()
    {
        if (shopPanel.gameObject.activeSelf)
        {
            isTurnedOf = true;
            shopPanel.GetComponent<Animator>().SetTrigger("ShopWindowUp");
            shopPanel.gameObject.SetActive(false);
            isPoused = false;
        }
        else
        {
            isPoused = true;
            shopPanel.SetActive(true);
            shopPanel.layer = LayerMask.NameToLayer("ShopLayer");
            shopPanel.GetComponent<Animator>().SetTrigger("ShopWindowUp");
        }
    }
}

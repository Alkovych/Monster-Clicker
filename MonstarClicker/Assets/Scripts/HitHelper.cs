using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour {
    // Sctipts located on Monster prefab


    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("GetHit"); // Play Monster Hit animation when pressed left mouse button
        GetComponent<HealthHelper>().GetHitMethod(20);

    }
}

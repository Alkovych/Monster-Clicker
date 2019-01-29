using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class TimeHelper : MonoBehaviour{

    private float startTime;
    private float endTime = 2.0f;

    private GameHelper gameHelper;

    void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }

    void Update()
    {

        if (gameHelper.isDead == true)
        {
            startTime += 0.8f * Time.deltaTime;

            if (startTime >= endTime)
            {
                startTime = 0;
                gameHelper.SpawnMonster();
            }
        }
    }
}

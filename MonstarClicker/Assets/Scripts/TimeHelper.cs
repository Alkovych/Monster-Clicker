using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class TimeHelper : MonoBehaviour{

    private float startTime;
    private float endTime = 2.0f;

    private GameHelper gameHelper;
    private ButtonHelper buttonHelper;

    void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
        buttonHelper = GameObject.FindObjectOfType<ButtonHelper>();
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

        if (buttonHelper.isTurnedOf == true)
        {
            startTime += 0.8f * Time.deltaTime;

            if (startTime >= endTime)
            {
                startTime = 0;
                buttonHelper.isTurnedOf = false;
            }
        }
    }
}

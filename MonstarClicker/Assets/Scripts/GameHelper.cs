using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{

    [Header("Boolean")]
    [SerializeField]
    public bool isDead = false; // Checks if monster's dead or not.

    [Header("TEXT")]
    [SerializeField]
    private Text playerGoldUI; // player gold text
    [SerializeField]
    private Text playerRubyUI; // player ruby text
   // [SerializeField]
    //private Text monsterHP; // monster hp text on main scene

    [Header("Prefabs objects")]
    [SerializeField]
    private GameObject tombStonePrefab; // prefab of tombstone object
    public GameObject[] monstersPrefab; // array of monsters prefabs

    [SerializeField]
    private GameObject goldPrefab; // gold prefabs that instantiated when monster`s dead

    [Header("Transform position")]
    [SerializeField]
    private Transform monsterStartPoint; // transform position of monster spawn point

    [Header("Game variables")]
    private int playerGold; // current player gold
    private int index = 0; // current index. Created to spawn monster one by one in array. At the begining index = 0 but increase after each monster death.
    private float startTime; // timer to spawn next monster after privious monster death 
    private float endTime = 3.0f;
    private int playerRuby;

    [Header("Script refenrences")]
    private HealthHelper healthHelper; // reference to another script located on the scene
    private BenefitHelper benefitHelper; // reference to another script located on the scene

    [Header("Image")]
    public Sprite[] monsterImageArray;
    public Image monsterImage;

    #region Player Gold Set and Get function
    public void SetPlayerGold(int playerGold)
    {
        if (playerGold >= 0 && playerGold <= 10000)
        {
            this.playerGold = playerGold;
        }
        else
        {
            Debug.Log("Out of index Array"); // Just for test
        }
    }
    public int GetPlayerGold()
    {
        return this.playerGold;
    }
    #endregion

    #region Index Set and Get function for monsters array
    public void SetMonsterIndex(int index)
    {
        if (index >= 0 && index <= 50)
        {
            this.index = index;
        }
        else
        {
            Debug.Log("Out of index Array"); // Just for test
        }
    }
    public int GetMonsterIndex()
    {
        return this.index;
    }
    #endregion


    void Start()
    {
        healthHelper = GameObject.FindObjectOfType<HealthHelper>(); // reference to HealthHelper script
        benefitHelper = GameObject.FindObjectOfType<BenefitHelper>(); // reference to BenefitHelper script

        SpawnMonster();// Function to spawn new Monster
    }

    void Update()
    {
        playerGoldUI.text = playerGold.ToString();// checks player gold every update.
        playerRubyUI.text = playerRuby.ToString();

    }

    // Method instantiated tombstone object after monster death
    public void TombstoneDownMethod()
    {
        // Creates tombstone when monster`s dead and destroying after 1 seconds
        GameObject tombStoneObj = Instantiate(tombStonePrefab, monsterStartPoint.transform.position + new Vector3(0, 2, 0), Quaternion.identity) as GameObject;
        monsterImage.sprite = monsterImageArray[1];

        Destroy(tombStoneObj, 1.9f);// Destroying tombstone after 1 second after spawn
    }

    //After monster`s death that function take gold and instantiated gold prefabs with animation. Destroying after 2 seconds
    public void TakeGold(int _gold)
    {
        playerGold += _gold;

        GameObject goldObject = Instantiate(goldPrefab) as GameObject;
        Destroy(goldObject, 2);
        index++;

        isDead = true; // checks if monsters dead. If dead, switching to true and allows timer starts counting .

    }

    public void SpawnMonster() // Spanwn monsters at concreate point.
    {
        isDead = false;
        GameObject monsterObject = Instantiate(monstersPrefab[index]) as GameObject;

        monsterObject.transform.position = monsterStartPoint.position + new Vector3(0, 2, 0);

        monsterImage.sprite = monsterImageArray[index];
    }

}

using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReturnLoot : MonoBehaviour
{
    public float lootingEffiency;
    [SerializeField] int netWorth = 0;
    [SerializeField] TextMeshProUGUI treasuryText;
    [SerializeField] SoldierManager soldierManager;
    [SerializeField] List<TextMeshProUGUI> upgradeButtonText;

    [SerializeField] int Upgrade1cost;
    [SerializeField] int Upgrade2cost;
    [SerializeField] int Upgrade3cost;

    [SerializeField] float TimeBetweenSpawns;
    Soldier soldier;
    string upgrade1Text;
    string upgrade2Text;
    string upgrade3Text;
    void Start()
    {
        lootingEffiency = 1;
        treasuryText.text = "You have 0 Gold";
        Upgrade1cost = 1000;
        Upgrade2cost = 500;
        Upgrade3cost = 2000;
        TimeBetweenSpawns = 5.5f;
        soldier = FindAnyObjectByType<Soldier>();
        upgrade1Text = "Makes soldiers more efficient at getting loot! costs " + Upgrade1cost + " Gold";
        upgradeButtonText[0].text = upgrade1Text;
        upgrade2Text = "Sends out automatically soldiers to get loot! costs " + Upgrade2cost + " Gold";
        upgradeButtonText[1].text = upgrade2Text;
        upgrade3Text = "Makes the soldiers faster at getting loot! costs " + Upgrade3cost + " Gold";
        upgradeButtonText[2].text = upgrade3Text;
    }

    // Update is called once per frame
    void Update()
    {


    }

    //Sends a solder depending on the number given, different soldiers give different loot
    public void sendSoldier(int soldierType)
    {

        if (soldierType == 0)
        {
            Debug.Log("Cat,Moving Out!");
        }
    }



    //Determines how much loot you get when the soldier returns
    public void LootGet()
    {
        int lootValue = Random.Range(1, 3);
        lootValue = (int)(lootValue * 10 * lootingEffiency);
        netWorth += lootValue;
        treasuryText.text = "You have " + netWorth.ToString() + " Gold";
        Debug.Log("My liege, i have returned with" + netWorth.ToString() + "Gold!");
    }

    #region Upgrade that sends soldiers
    public void Upgrade2()
    {
        if (netWorth >= Upgrade2cost)
        {
            if (TimeBetweenSpawns >= 1)
            {
                netWorth = netWorth - Upgrade2cost;
                treasuryText.text = "You have " + netWorth.ToString() + " Gold";
                StartCoroutine(Upgrade2cor());
                Upgrade2cost = Upgrade2cost * 5;
                TimeBetweenSpawns = TimeBetweenSpawns - 0.5f;
                upgrade2Text = "Sends out automatically soldiers to get loot! costs " + Upgrade2cost + " Gold";
                upgradeButtonText[1].text = upgrade2Text;
            }

        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }

    IEnumerator Upgrade2cor()
    {
        yield return new WaitForSeconds(TimeBetweenSpawns);
        soldierManager.SpawnSoldier();
        sendSoldier(0);
        StartCoroutine(Upgrade2cor());
    }
    #endregion Upgrade that sends soldiers

    public void Upgrade1()
    {
        if (netWorth >= Upgrade1cost)
        {

            netWorth -= Upgrade1cost;
            if (lootingEffiency >= 1)
            {
                lootingEffiency += 0.2f;
                Upgrade1cost = Upgrade1cost * 5;
                upgrade1Text = "Makes soldiers more efficient at getting loot! costs " + Upgrade1cost + " Gold";
                upgradeButtonText[0].text = upgrade1Text;
            }

        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }


    public void Upgrade3()
    {
        if (netWorth >= Upgrade3cost)
        {
            netWorth -= Upgrade3cost;
            if (soldier.moveSpeed >= 15)
            {
                soldier.moveSpeed += 2;
                Upgrade3cost = Upgrade3cost * 6;
                upgrade3Text = "Makes the soldiers faster at getting loot! costs " + Upgrade3cost + " Gold";
                upgradeButtonText[2].text = upgrade3Text;
            }
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }



}


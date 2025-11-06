using System.Collections;
using TMPro;
using UnityEngine;

public class ReturnLoot : MonoBehaviour
{
    public float lootingEffiency;
    [SerializeField] int netWorth = 0;
    [SerializeField] TextMeshProUGUI treasuryText;

    [SerializeField] int Upgrade1cost;
    [SerializeField] int Upgrade2cost;
    
    [SerializeField] float TimeBetweenSpawns;
    void Start()
    {
        lootingEffiency = 1;
        treasuryText.text = "You have 0 Gold";
        Upgrade1cost = 1000;
        Upgrade2cost = 500;
        TimeBetweenSpawns = 5.5f;
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
            StartCoroutine(CatGuardLootGet());
            Debug.Log("Cat,Moving Out!");
        }
    }


    IEnumerator CatGuardLootGet()
    {
        Debug.Log("Cat,Moving Out!");
        yield return new WaitForSeconds(1);
        LootGet();
        
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
        sendSoldier(0);
        StartCoroutine(Upgrade2cor());
    }
        public void Upgrade1()
    {
            if (netWorth >= Upgrade1cost)
            {

                netWorth -= Upgrade1cost;
                if (lootingEffiency == 1)
                {
                    lootingEffiency += 0.2f;
                Upgrade1cost = Upgrade1cost * 5;
                }
                
            }
            else
            {
                Debug.Log("Not enough gold!");
            }

        
        
    }
}

using System.Collections;
using TMPro;
using UnityEngine;

public class ReturnLoot : MonoBehaviour
{
    public int lootingEffiency;
    [SerializeField] int netWorth = 0;
    [SerializeField] TextMeshProUGUI treasuryText;
    
    [SerializeField] int Upgrade1cost;

   
   
    [SerializeField] int Upgrade2cost;
    [SerializeField] bool Upgrade2purchased;

    [SerializeField] float TimeBetweenSpawns;
    void Start()
    {
        lootingEffiency = 1;
        treasuryText.text = "You have 0 Gold";
       
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
    void LootGet()
    {
        int lootValue = Random.Range(1, 3);
        lootValue = lootValue * 10 * lootingEffiency;
        netWorth += lootValue;
        treasuryText.text = "You have " + netWorth.ToString() + " Gold";
        Debug.Log("My liege, i have returned with" + netWorth.ToString() + "Gold!");
    }


    public void Upgrade1()
    {    
         if (netWorth >= Upgrade1cost)
         {
                if (TimeBetweenSpawns >= 1)
                {
                netWorth = netWorth - Upgrade1cost;
                treasuryText.text = "You have " + netWorth.ToString() + " Gold";
                StartCoroutine(Upgrade1cor());
                Upgrade1cost = Upgrade1cost * 5;    
                TimeBetweenSpawns = TimeBetweenSpawns - 0.5f;
                }

         }
         else
         {
                Debug.Log("Not enough gold!");
         }
    }
         
    

    IEnumerator Upgrade1cor()
    {
        yield return new WaitForSeconds(TimeBetweenSpawns);
        sendSoldier(0);
        StartCoroutine(Upgrade1cor());
    }
        void Upgrade2()
    {
        
        if (Upgrade2purchased == false)
        {
            if (netWorth >= Upgrade1cost)
            {

                netWorth -= Upgrade2cost;
                Upgrade2purchased = true;
                lootingEffiency += 1;
            }
            else
            {
                Debug.Log("Not enough gold!");
            }

        }
        
    }
}

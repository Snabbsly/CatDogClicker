using System.Collections;
using TMPro;
using UnityEngine;

public class ReturnLoot : MonoBehaviour
{
    public int lootingEffiency;
    int netWorth = 0;
    [SerializeField] TextMeshProUGUI treasuryText;
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
    public void LootGet()
    {
        int lootValue = Random.Range(1, 3);
        lootValue = lootValue * 10 * lootingEffiency;
        netWorth += lootValue;
        treasuryText.text = "You have " + netWorth.ToString() + " Gold";
        Debug.Log("My liege, i have returned with" + netWorth.ToString() + "Gold!");

    }
}

using System.Collections;
using UnityEngine;

public class King : MonoBehaviour
{
    ReturnLoot treasury;
    bool trainingTime;

    // makes it so there is a short delay ao you can not send soldiers infinitely quickly
    void Start()
    {
        treasury = FindAnyObjectByType<ReturnLoot>();
        trainingTime = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void KingsOrders(int troopType)
    {
        if (trainingTime == true)
        {
            StartCoroutine(SendTheTroops(troopType));
        }
    }

    IEnumerator SendTheTroops(int troopType)
    {
        trainingTime = false;
        yield return new WaitForSeconds(0.5f);
        treasury.sendSoldier(troopType);
        trainingTime = true;
    }
}

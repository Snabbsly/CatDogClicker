using System.Collections;
using UnityEngine;

public class King : MonoBehaviour
{
    ReturnLoot treasury;
    public bool trainingTime;

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
    public void KingsOrders()
    {
        if (trainingTime == true)
        {
            Debug.Log("This works");
            StartCoroutine(SendTheTroops());
        }
    }
    // Forces a delay between troops sent
    IEnumerator SendTheTroops()
    {
        trainingTime = false;
        yield return new WaitForSeconds(0.5f);
        trainingTime = true;
    }
}

using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    [SerializeField] GameObject _soldier;
    [SerializeField] King king;

    [Header("Sprite par")]
    [SerializeField] Sprite[] hasNoLootSprites;
    [SerializeField] Sprite[] hasLootSprites;

    public void SpawnSoldier()
    {
        if (king.trainingTime == true)
        {
            Debug.Log("This works");

            GameObject newSoldier = Instantiate(_soldier, transform.position, Quaternion.identity);
            Soldier soldier = newSoldier.GetComponent<Soldier>();
            if (soldier == null)
            {
                Debug.LogWarning("lägg in soldier raaa");
                return;
            }

            int r = Random.Range(0, hasNoLootSprites.Length);  // väljer random av no loot sprites 

            // Välj samma nummer för båda sprites
            soldier.SetSpritePair(hasNoLootSprites[r], hasLootSprites[r]);
        }
    }

}

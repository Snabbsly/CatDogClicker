using UnityEngine;

public class CatMove : MonoBehaviour
{
    [SerializeField] Animator CatWithLoot;
    //nextanimation

    //[SerializeField] string catTag = Soilder;

    //[SerializeField] string animationName = animCatLoot;
    
    //Animation animCatLoot;
    //string animationName:
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soilder"))
        {
            Debug.Log("Cat walked into collider");
            CatWithLoot.Play("animCatLoot");
        }
    }
}

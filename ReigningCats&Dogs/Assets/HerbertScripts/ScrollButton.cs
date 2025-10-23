using UnityEngine;

public class ScrollButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    bool onScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Make it enable and disable the button
    public void slideIn()
    {
        AlterValue();
        animator.SetTrigger("SlideIn");
        animator.SetBool("OnScreenOrNot", onScreen);
    }
  


    void AlterValue()
    {
        onScreen = !onScreen;
    }
}

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

    
    // Slides in the menu so it can be seen, and makes it so that pressing the button pulls it back up
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

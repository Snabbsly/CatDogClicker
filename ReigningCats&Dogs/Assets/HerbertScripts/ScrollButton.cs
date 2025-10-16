using UnityEngine;

public class ScrollButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Make it enable and disable the button
    public void slideIn()
    {
        animator.SetTrigger("SlideIn");
        animator.SetBool("OnScreenOrNot", false);
    }
    public void slideout()
    {
        animator.SetBool("OnScreenOrNot", true) ;
    }
}

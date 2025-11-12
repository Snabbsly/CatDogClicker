using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    [SerializeField] float target = 5f;
    [SerializeField] float moveCameraSpeed = 10f;
    [SerializeField] Button rightButton;
    [SerializeField] Button leftButton;

    Vector3 startPos;
    Vector3 targetPos;

    bool movingRight = false;
    bool movingLeft = false;

    void Start()
    {
        startPos = transform.position;  
        targetPos = new Vector3(target, transform.position.y, transform.position.z);
        leftButton.gameObject.SetActive(false);
    }
    void Update()
    {
        if (movingRight)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveCameraSpeed);

            if (Vector3.Distance(transform.position, targetPos) < 0.05f)  // om distance är mindre än 0.05 stannar vi så det blir ett smooth stopp 
            {
                transform.position = targetPos;
                movingRight = false;
                leftButton.gameObject.SetActive(true);
                rightButton.gameObject.SetActive(false);
            }

        }

        if (movingLeft)
        {   
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * moveCameraSpeed);

            if (Vector3.Distance(transform.position, startPos) < 0.05f)
            {
                transform.position = startPos;
                movingLeft = false;
                leftButton.gameObject.SetActive(false);
                rightButton.gameObject.SetActive(true);
            }
        }
    }

    public void MoveCameraRight()
    {
        movingRight = true;
    }

    public void MoveCameraLeft()
    {
        movingLeft = true;
    }
}

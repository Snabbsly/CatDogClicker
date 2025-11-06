using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    [SerializeField] float target = 5f;    // ny x position för dit kameran ska åka
    [SerializeField] float moveCameraSpeed = 10f;  // hur snabbt
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject leftButton;


    Vector3 startPos;   //position vi startar vid
    Vector3 targetPos;  //position vi vill till

    bool movingRight = false;
    bool movingLeft = false;

    void Start()
    {
        //leftButton = GetComponent<GameObject>;

        //cameraTransform = gameObject.transform;
        //gameObject.transform.Translate(moveCameraSpeed, 0, 0);
        startPos = transform.position;  
        targetPos = new Vector3(target, transform.position.y, transform.position.z);
        leftButton.SetActive(false);  //bytte från enabled = false; till set active, bytte även från button till gameobject
    }
    void Update()
    {
       // cameraTransform.Translate(7, 0, 0);
        if (movingRight)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveCameraSpeed);
            if (Vector3.Distance(transform.position, targetPos) < 0.05f)  // om distance är mindre än 0.05 stannar vi så det blir ett smooth stopp 
            {
                transform.position = targetPos;
                movingRight = false;
                leftButton.SetActive(true);
                rightButton.SetActive(false);
            }
        }
        if (movingLeft)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * moveCameraSpeed);
            if (Vector3.Distance(transform.position, startPos) < 0.05f)  // om distance är mindre än 0.05 stannar vi så det blir ett smooth stopp 
            {
                transform.position = startPos;
                movingLeft = false;
                leftButton.SetActive(false);
            }
        }
    }

    public void MoveCameraRight()
    {
        //this.transform.position = cameraTransform[moveCameraSpeed].position;
        movingRight = true;
    }

    public void MoveCameraLeft()
    {
        movingLeft = true;
    }

    
    /*
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(
            () =>
            {
                Camera.main.gameObject.transform.Translate(step, 0, 0);
            }
        );
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> bodyParts = new List<Transform>();
    public double minDistence = 0.25;
    public float speed =3f;
    public float rotationSpeed =100;
    public float timeFromLastTry;
    public GameObject bodyPreFeb;
    
    private float dis;
    private Transform curBodyPart;
    private Transform PrevBodyPart;
    
    public float beginSize;

    public Text currentScore;
    public Text score;
    public GameObject deadScreen;
    public bool isAlive;



    public Vector2 startPos;
    public Vector2 direction;

    public Text m_Text;
    string message;

    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
    }
void StartLevel()
    {
        timeFromLastTry = Time.time;
        deadScreen.SetActive(false);

        for (int i= bodyParts.Count - 1;i >1; i++)
        {
            Destroy(bodyParts[i].gameObject);
            bodyParts.Remove(bodyParts[i]);

        }

        bodyParts[0].position = new Vector3(0f,0.5f, 0f);
        bodyParts[0].rotation = Quaternion.identity;

        currentScore.gameObject.SetActive(true);
        currentScore.text = "Score: 0";

        isAlive = true;


        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
        }

    }
    // Update is called once per frame
    private void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                case TouchPhase.Stationary:
                    direction = new Vector2(0f, 0f);
                    break;

            }

            if(direction.x > 0)
            {
                bodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * 0.9f);
            }
            else if (direction.x < 0)
            {
                bodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * -0.9f);

            }
            else if (direction.y > 0)
            {
                bodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * 0.9f);
            }
            else if (direction.y < 0)
            {
                bodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * -0.9f);

            }
            Debug.Log( "touc"  + direction);
        }
    }


    void Update()
    {


        if(isAlive)
            Move();

        if (Input.GetKey(KeyCode.Q))
            AddBodyPart();
    }
public void Move()
    {
        float curSpeed = speed;
        if (Input.GetKey(KeyCode.W))
        {
            curSpeed *= 2;
        }
        bodyParts[0].Translate(bodyParts[0].forward * curSpeed * Time.smoothDeltaTime, Space.World);

        if (Input.GetAxis("Horizontal") != 0)
        {
            bodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
            //Debug.Log("keyboard" + Input.GetAxis("Horizontal"));

        }


        for (int i = 1; i < bodyParts.Count;i++)
        {
            curBodyPart = bodyParts[i];
            PrevBodyPart = bodyParts[i - 1];
            dis = Vector3.Distance(PrevBodyPart.position, curBodyPart.position);
            Vector3 newPos = PrevBodyPart.position;
            newPos.y = bodyParts[0].position.y;
            double t = Time.deltaTime * dis / minDistence * curSpeed;

            if(t > 0.5)
            {
                t = 0.5;
            }
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, (float)t);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, PrevBodyPart.rotation, (float)t);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            speed = 20f;
        }
        else
        {
            speed = 3f;
        }
    }
public void AddBodyPart()
    {
        Transform newPart = (Instantiate(bodyPreFeb,
            bodyParts[bodyParts.Count - 1].position,
            bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;

        newPart.SetParent(this.transform);
        bodyParts.Add(newPart);
        currentScore.text = "Score " + (bodyParts.Count - beginSize).ToString();
    }
public void Die()
    {
        isAlive = false;
        score.text = "Your Score Was " + (bodyParts.Count - beginSize).ToString();
        currentScore.gameObject.SetActive(false);
        deadScreen.SetActive(true);
    }
}

using UnityEngine;
using System.Collections;

public class enemyB : MonoBehaviour {

    public float moveValue = 50f;
    public float moveMaxSpeed = 1.0f;

    public enum mode
    {
        UpDown,
        RightLeft,
    }
    public mode moveMode;

    GameObject origin;
    GameObject wing;

    Vector3 firstPos;

    float reverseTime;
	// Use this for initialization
	void Start () {
        origin = transform.FindChild("origin").gameObject;
        wing = transform.FindChild("origin/model_enemyB/wing").gameObject;
        if (moveMode == mode.UpDown)
        {
            wing.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        }

        swingDelt = new Vector3
            (
            (Random.value - 0.5f),
            (Random.value - 0.5f),
            (Random.value - 0.5f)
            );
        swingSpeed = new Vector3
            (
            (Random.value + 0.5f),
            (Random.value + 0.5f),
            (Random.value + 0.5f)
            );
        swingTheta = Vector3.zero;
        firstPos = transform.position;
    }

    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        Move();
        Swing();
        Wing();

        if (moveMode == mode.RightLeft)
        {
            //左右方向
            Debug.DrawRay(transform.position, Vector3.left * 22f);
            Debug.DrawRay(transform.position, Vector3.right * 22f);
            if (Physics.Raycast(transform.position, Vector3.right, out hit, 18) || Physics.Raycast(transform.position, Vector3.left, out hit, 18))
            {
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.tag == "Object" || hit.collider.tag == "Toge" || hit.collider.tag == "Goal")
                {
                    Reverse();
                }
            }
        }else if (moveMode == mode.UpDown)
        {
            Debug.DrawRay(transform.position, Vector3.up * 30f);
            Debug.DrawRay(transform.position, Vector3.down * 25f);
            //上下方向
            if (Physics.Raycast(transform.position , Vector3.up, out hit, 25) || Physics.Raycast(transform.position, Vector3.down, out hit, 20))
            {


                if (hit.collider.tag == "Object" || hit.collider.tag == "Toge" || hit.collider.tag == "Goal")
                {
                    Reverse();
                }
            }
        }
        if(reverseTime > 0)
        {
            reverseTime -= Time.deltaTime;
            if (reverseTime < 0) reverseTime = 0;
        }
    }

    
    Vector3 swingDelt;
    Vector3 swingSpeed;
    Vector3 swingTheta;
    void Swing()
    {
        origin.transform.localRotation = Quaternion.EulerAngles
            (
            Mathf.Sin(swingTheta.x) * swingDelt.x,
            Mathf.Sin(swingTheta.y) * swingDelt.y,
            Mathf.Sin(swingTheta.z) * swingDelt.z
            );
        swingTheta += swingSpeed * Time.deltaTime * 3.0f;
    }

    void Wing()
    {
        wing.transform.Rotate(Vector3.up * Time.deltaTime * 500f);
    }

    bool isReturn = false;
    float moveSpeed = 0.0f;
    void Move()
    {
        if (!isReturn)
        {
            if (moveSpeed < moveMaxSpeed)
            {
                moveSpeed += 100.0f * Time.deltaTime;
            }
            else
            {
                moveSpeed = moveMaxSpeed;
            }
        }
        else
        {
            if (moveSpeed > -moveMaxSpeed)
            {
                moveSpeed -= 100.0f * Time.deltaTime;
            }
            else
            {
                moveSpeed = -moveMaxSpeed;
            }
        }

        switch (moveMode)
        {
            case mode.RightLeft:
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
                if (!isReturn)
                {
                    if (firstPos.x + moveValue < transform.position.x)
                    {
                        isReturn = true;
                    }
                }
                else
                {
                    if (firstPos.x - moveValue > transform.position.x)
                    {
                        isReturn = false;
                    }
                }
                break;
            case mode.UpDown:
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
                if (!isReturn)
                {
                    if (firstPos.y + moveValue < transform.position.y)
                    {
                        isReturn = true;
                    }
                }
                else
                {
                    if (firstPos.y - moveValue > transform.position.y)
                    {
                        isReturn = false;
                    }
                }
                break;
            default:
                Debug.Log("ERROR");
                break;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.name == "GameOverLine")
        {
            Destroy(gameObject);
        }
    }

    //強制的に引き返す時に呼ぶ
    public void Reverse()
    {
        if (reverseTime > 0) return;
        moveSpeed = 0.0f;
        reverseTime = 1.0f;
        if (isReturn)
        {
            isReturn = false;
        }
        else
        {
            isReturn = true;
        }
    }
}

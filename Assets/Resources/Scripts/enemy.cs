using UnityEngine;
using System.Collections;
using System;

public class enemy : MonoBehaviour {
    float speed = 50f;
    float lotspeed = -500f;
    Vector3 pos;
    public int gra;
    bool Fall;
    Animator anim;

    public enum status
    {
        run_left,
        run_right,
        idle,
        rotate
    };

    public status command;

    [SerializeField]
    int direction = 0;
    [SerializeField]
    float newAngle;

    // Use this for initialization
    void Start () {
        anim = transform.FindChild("model_monster").GetComponent<Animator>();
        command = status.run_left;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameParameter.instance.isMenu) return;

        switch (command)
        {
            case status.run_left:
                transform.eulerAngles = new Vector3(0, 270, 0);
                transform.Translate(transform.right * 1 * speed * Time.deltaTime);
                direction = 0;
                anim.SetBool("Running", true);
                break;
            case status.run_right:
                transform.eulerAngles = new Vector3(0, 90, 0);
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
                direction = 1;
                anim.SetBool("Running", true);
                break;
            case status.idle:
                //transform.eulerAngles = new Vector3(0, 180, 0);
                anim.SetBool("Running", false);
                break;
            case status.rotate:
                anim.SetBool("Running", false);
                if (direction == 0 || direction == 180)
                {
                    newAngle = 90f;
                    transform.Rotate(new Vector3(0f, lotspeed, 0f) * Time.deltaTime);
                    

                    if (Mathf.DeltaAngle(transform.eulerAngles.y, newAngle) > -5f && Mathf.DeltaAngle(transform.eulerAngles.y, newAngle) < 5f)
                    {
                        transform.eulerAngles = new Vector3(0, 90, 0);
                        command = status.run_right;
                    }
                }
                if (direction == 1)
                {
                    newAngle = 270f;
                    transform.Rotate(new Vector3(0f, -lotspeed, 0f) * Time.deltaTime);
                    
                    if (Mathf.DeltaAngle(transform.eulerAngles.y, newAngle) > -5f && Mathf.DeltaAngle(transform.eulerAngles.y, newAngle) < 5f)
                    {
                        transform.eulerAngles = new Vector3(0, 270, 0);
                        command = status.run_left;
                    }
                }
               
                break;
            default:
                break;
        }


        //Debug.DrawRay(transform.position + (Vector3.up * 10f + transform.forward * (-15f)), Vector3.down * 15f);
        if (!Physics.Raycast(transform.position + Vector3.up * 10f + transform.forward * (-15f), Vector3.down, 15))
        {
            Debug.Log("!");
            pos = gameObject.transform.position;
            pos.y -= gra * Time.deltaTime;
            gameObject.transform.position = pos;
            Fall = true;
            command = status.idle;
        }
        else
        {
            if (Fall) command = status.rotate;
            Fall = false;
            if(gameObject.transform.position.y < -90)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.name == "GameOverLine")
        {
            Destroy(gameObject);
        }
    }
    public bool getFALL()
    {
        return Fall;
    }
}

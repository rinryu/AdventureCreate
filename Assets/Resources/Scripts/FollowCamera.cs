using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public float distance = 450.0f;
	public float horizontalAngle = 0.0f;
	public float rotAngle = 180.0f;
	
	public float verticalAngle = 0.0f;
	public Transform lookTarget;
    public Vector3 offset;

    Vector3 moveToPos;


    void SetTarget(Transform target)
    {
        lookTarget = target;
    }

    // Use this for initialization
    void Start () {

        //SetTarget(GameObject.Find("player(Clone)").transform);
        //offset = new Vector3(0, (float)Screen.height * 0.4f, 0);
        offset = new Vector3(0, 239, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (lookTarget != null) { 
            Vector3 lookPosition = new Vector3(lookTarget.position.x + offset.x, offset.y, lookTarget.position.z + offset.z);
            Vector3 relativePos = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * new Vector3(0, 0, -distance);

            //transform.position = lookPosition + relativePos;
            moveToPos = lookPosition + relativePos;
            transform.Translate((moveToPos - transform.position) * 0.05f, Space.World);
            //transform.LookAt (lookPosition);
            /*
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                   Quaternion.LookRotation(lookPosition - transform.position), 0.095f * 2.0f);
                                                   */

        }
        else
        {
            SetTarget(GameObject.Find("player(Clone)").transform);
        }
    }

	}


using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

    public float speed;
    public float deadZone;

    GameObject cube;
    Vector3 tr;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //move left
        if (Input.GetAxis("L_XAxis_1") < -deadZone)
            transform.Translate(-speed, 0f, 0f);

        //move right
        if (Input.GetAxis("L_XAxis_1") > deadZone)
            transform.Translate(speed, 0f, 0f);


        //move up move up, rough comme une louve
        if (Input.GetAxis("L_YAxis_1") > deadZone)
            transform.Translate(0f, 0f, -speed);


        //move down
        if (Input.GetAxis("L_YAxis_1") < -deadZone)
            transform.Translate(0f, 0f, speed);

        
       /* tr = this.gameObject.transform.position;
        if (Input.GetButton("Attack_"))
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = tr;
        }*/
            
        

	    
	}
}

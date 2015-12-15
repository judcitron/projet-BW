using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {

    public float f_movementSpeed;
    Rigidbody myRB;


	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") != 0)
        {
            myRB.AddForce(Vector3.forward * Input.GetAxis("Vertical") * f_movementSpeed, ForceMode.Force);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            myRB.AddForce(Vector3.right * Input.GetAxis("Horizontal") * f_movementSpeed, ForceMode.Force);

        }
    }
}

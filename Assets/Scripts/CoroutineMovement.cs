using UnityEngine;
using System.Collections;

public class CoroutineMovement : MonoBehaviour {

    public float f_movementSpeed;

    Rigidbody myRB;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody>();
        StartCoroutine(Movement());
        Debug.Log("time is " + Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
	    

	}

    IEnumerator Movement()
    {
        while (true)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                //myRB.AddForce(Vector3.forward * Input.GetAxis("Vertical") * f_movementSpeed, ForceMode.Force);
                myRB.AddForce(Vector3.forward * Input.GetAxisRaw("Vertical") * f_movementSpeed, ForceMode.Force);

            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                //myRB.AddForce(Vector3.right * Input.GetAxis("Horizontal") * f_movementSpeed, ForceMode.Force);
                myRB.AddForce(Vector3.right * Input.GetAxisRaw("Horizontal") * f_movementSpeed, ForceMode.Force);


            }
            yield return null;

        }

    }
}

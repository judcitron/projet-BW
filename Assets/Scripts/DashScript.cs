using UnityEngine;
using System.Collections;

public class DashScript : MonoBehaviour {

	public float f_dashPower;
	public float f_cooldown;

	private float f_timer = 0;

	bool isInCooldown;
	
	Rigidbody myRB;

	// Use this for initialization
	void Start () {

		myRB = GetComponent<Rigidbody> ();
		Debug.Log("time is "+ Time.deltaTime); 
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isInCooldown == true) 
		{
			f_timer += Time.deltaTime;
			if (f_timer >= f_cooldown) 
			{
				isInCooldown = false;
				f_timer = 0;
			}
		}

		if (isInCooldown == false)
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				myRB.AddForce( myRB.velocity.normalized * f_dashPower, ForceMode.Impulse);
				isInCooldown = true;
			}
		}




	
	}
}

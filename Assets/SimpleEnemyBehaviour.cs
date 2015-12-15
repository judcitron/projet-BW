using UnityEngine;
using System.Collections;

public class SimpleEnemyBehaviour : MonoBehaviour {

    GameObject target;

    public float f_speed;
    bool b_stopChasing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("PlayerTrigger"))
        {
            StartCoroutine(ChasePlayer(col.transform.parent.parent.gameObject));
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("PlayerTrigger"))
        {
            Debug.Log("hmm?");
            b_stopChasing = true;
        }
    }

    IEnumerator ChasePlayer(GameObject target)
    {
        while (gameObject.transform.position != target.transform.position)
        {
            if(b_stopChasing == true)
            {
                b_stopChasing = false;
                yield break;
            }
            float step = f_speed * Time.deltaTime;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, step);
            gameObject.transform.LookAt(target.transform);
            yield return new WaitForEndOfFrame();
        }

        yield return null;

    }
}

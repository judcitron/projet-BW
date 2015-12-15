using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

    [Tooltip("The amount of degenerescence")]
    public float f_degeneresceneLevel;

    [Tooltip("Max player HP")]
    public int i_maxHP; 

    public float f_MaxTime;
    [HideInInspector]
    public float f_MinTime;

    [HideInInspector]
    public int i_watchedTileType;

    // Use this for initialization
    void Start () {
        f_MinTime = -f_MaxTime;

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void TakeDamage(int damage)
    {
        i_maxHP -= damage;
    }
}

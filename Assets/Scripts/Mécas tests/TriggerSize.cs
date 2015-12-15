using UnityEngine;
using System.Collections;

public class TriggerSize : MonoBehaviour {

    GameObject childTrigger;
    PlayerState myPlayerState;

    [Tooltip("Maximum size of trigger compared to initial size")]
    public float f_maxSize;

    Vector3 initSize;
    Vector3 maxSize;

	// Use this for initialization
	void Start () {
        childTrigger = gameObject.transform.Find("Physics").Find("Trigger").gameObject;
        myPlayerState = GetComponent<PlayerState>();

        initSize = childTrigger.transform.localScale;
        maxSize = initSize * f_maxSize;
    }
	
	// Update is called once per frame
	void Update () {

        //float perc2 = (myPlayerState.f_degeneresceneLevel + (-myPlayerState.f_MinTime)) / (myPlayerState.f_MaxTime + (-myPlayerState.f_MinTime));

        float perc1 = myPlayerState.f_degeneresceneLevel / myPlayerState.i_watchedTileType;

        float perc2 = (perc1 + (-myPlayerState.f_MinTime)) / (myPlayerState.f_MaxTime + (-myPlayerState.f_MinTime));


        childTrigger.transform.localScale = Vector3.Lerp(initSize, maxSize, perc2);
    }
}

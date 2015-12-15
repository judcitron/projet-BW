using UnityEngine;
using System.Collections;

public class SwitchStateRay : MonoBehaviour {

    //mon renderer
    Renderer myRenderer;

    //mon state
    PlayerState myPlayerState;

    int i_lookDown = 3;

    //material de case blanche, material de case noire
    public Material black, white;

    //the int of the case i was in at the last frame
    public int lastSeen;

    bool b_startGauge = true;

    // Use this for initialization
    void Start () {
        myPlayerState = GetComponent<PlayerState>();

        myRenderer = transform.Find("Graph").GetComponent<Renderer>();
        //pr que le raycast fonctionne, disregard
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0.1f, 0);
    }

    // Update is called once per frame
    void Update () {
        if(myPlayerState.f_degeneresceneLevel <= myPlayerState.f_MinTime || myPlayerState.f_degeneresceneLevel >= myPlayerState.f_MaxTime)
        {
            b_startGauge = false;
        }

        myPlayerState.f_degeneresceneLevel = Mathf.Clamp(myPlayerState.f_degeneresceneLevel, myPlayerState.f_MinTime, myPlayerState.f_MaxTime);

        RaycastHit hit = new RaycastHit();
        Vector3 dir = Vector3.down;

        //si j'ai un truc en dessous de moi
        if (Physics.Raycast(transform.position, dir, out hit, i_lookDown)) {
            //si ce truc a le script ZoneState, donc si c'est bien une zone
            if (hit.transform.parent.parent.gameObject.GetComponent<ZoneState>() != null)
            {

                if(hit.transform.parent.parent.gameObject.GetComponent<ZoneState>().i_type != lastSeen)
                {
                    b_startGauge = true;
                }

                lastSeen = hit.transform.parent.parent.GetComponent<ZoneState>().i_type;
                myPlayerState.i_watchedTileType = lastSeen;

                if (b_startGauge == true)
                {
                    myPlayerState.f_degeneresceneLevel += Time.deltaTime * lastSeen;
                }

                //SECOND LERP
                float perc2 = (myPlayerState.f_degeneresceneLevel + (-myPlayerState.f_MinTime)) / (myPlayerState.f_MaxTime + (-myPlayerState.f_MinTime));
                //Debug.Log("perc2 is " + perc2);
                myRenderer.material.Lerp(white, black, perc2);
            }
            else
            {
                Debug.Log("aint got no ZoneState() brah !");
            }
        }
    }
}

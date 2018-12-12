using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour {

    public float speed = 0;
    public int points = 1;
    Vector3 moveingVec3 = new Vector3(0.0f,0.0f,0.0f);
    float oldX = 0;
    public PlayerManager pm;
    public CrushThatTaxi ct;
    // Use this for initialization
    void Start () {
        oldX = this.transform.localPosition.x;

    }
	
	// Update is called once per frame
	void Update () {
        //moveingVec3.Set(oldX - this.transform.localPosition.x, (speed - pm.speed) * 0.02f,0.0f);
        //this.transform.position += moveingVec3;

        if (this.gameObject.activeSelf && Vector3.Distance(this.transform.localPosition, this.pm.transform.localPosition) < 0.5f)
        {
            this.gameObject.SetActive(false);
        }
    }

    
}

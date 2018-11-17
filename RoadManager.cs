using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {
    public GameObject road1;
    public GameObject road2;
    public Transform CamTranform;
    public PlayerManager pm;
    // Use this for initialization
    void Start () {
        road1.transform.position = new Vector3(CamTranform.position.x, CamTranform.position.y, 0);
        road2.transform.position = new Vector3(CamTranform.position.x, CamTranform.position.y + 10, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(road1.transform.position.y + "||" + CamTranform.position.y);
        move();
        rotate();
        if (road1.transform.position.y > road2.transform.position.y)
        {
            
            if (Mathf.Abs(road2.transform.position.y - CamTranform.position.y) > 9.5f)
            {
                this.road2.transform.position += new Vector3(0, 20f, 0);
            }
        }
        else
        {
            if (Mathf.Abs( road1.transform.position.y - CamTranform.position.y) > 9.5f)
            {
                this.road1.transform.position += new Vector3(0,20f,0);
            }
        }
        
	}

    void move()
    {

        road1.transform.Translate(this.transform.up * pm.moveUp.y * (pm.speed ) * -1f);
        road2.transform.Translate(this.transform.up * pm.moveUp.y * (pm.speed) * -1f);
    }
    void rotate()
    {
        road1.transform.Translate(this.transform.right * pm.transform.rotation.z * 0.01f * pm.speed);
        road2.transform.Translate(this.transform.right * pm.transform.rotation.z * 0.01f * pm.speed);
    }

}

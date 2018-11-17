using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public int playerState = 0;// 0 - 匀速 1 - 加速 2 - 减速 3 - 左转 4 - 右转
                     

    void Start () {
        rend = this.GetComponent<Renderer>();
        cm = this.GetComponent<ControlManager>();
    }
    public ControlManager cm;
    public float speedUpRate = 0.1f;
    public float brakeRate = 2f;
    public float turnRate = 2f;
    public float autoBrakeRate = 0.1f;
    public float autoTurnBackRate = 0.3f;
    public float speedMax = 120f;

    public float turnRateUp = 500f;

    public Vector3 moveUp = new Vector3(0,0.01f,0);
    public float speed = 60f;
    public float speedFound = 60f;
    public Vector3 rotatePoint;



    
    Renderer rend;
    // Update is called once per frame
    void Update () {
       // this.transform.Translate(this.transform.up * moveUp.y*(speed - speedFound));
        //this.transform.position += moveUp*(speed - speedFound);

        rotatePoint.Set(this.transform.position.x, this.transform.position.y - this.rend.bounds.size.y/2,0);
        switch (playerState)
        {
            case 1:
                speedUp(false);
                autoTurnControl();
                break;
            case 2:
                this.speed -= brakeRate;
                autoTurnControl();
                break;
            case 3:

                this.transform.RotateAround(rotatePoint, Vector3.forward, turnRate * cm.disDownToNow/this.turnRateUp);
                speedUp(true);
                
                break;
            case 4:
                this.transform.RotateAround(rotatePoint, Vector3.forward, -turnRate * cm.disDownToNow / this.turnRateUp);
                speedUp(true);
                
                break;
            case 0:
                autoSpeedControl();
                autoTurnControl();
                break;
            default:break;
        }
	}

    void speedUp(bool isTuring)
    {
        if (this.speed < this.speedMax)
        {
            if(isTuring)
                this.speed += speedUpRate*0.5f;
            else
                this.speed += speedUpRate;
        }
    }

    void autoSpeedControl()
    {
        // if (this.speed - this.speedFound > 0)
        if (this.speed > 0)
        {
            this.speed -= autoBrakeRate;
        }
        if (this.speed < 0)
        {
            this.speed = 0;
        }
        if (this.speed - this.speedFound < 0)
        {
           // this.speed += autoBrakeRate;
        }
    }

    void autoTurnControl()
    {
        if (this.transform.rotation.z < 0f)
        {
            this.transform.RotateAround(rotatePoint, Vector3.forward, autoTurnBackRate);
        }
        if (this.transform.rotation.z > 0f)
        {
            this.transform.RotateAround(rotatePoint, Vector3.forward, -autoTurnBackRate);
        }
        if (Mathf.Abs(this.transform.rotation.z) < 0.01f)
        {
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x
                , this.transform.rotation.y
                , 0);
        }
    }
}

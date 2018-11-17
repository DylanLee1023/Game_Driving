using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour {

    public float outR = 540f;
    public float inR = 180f;
    public GameObject player;

    //for test
    public GameObject button;
    public GameObject buttonNow;


    // Use this for initialization
    void Start () {
        this.cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }
    public float disDownToNow = 0f;
    Vector2 point_Down = new Vector2(-999,-999);
    Vector2 point_Now = new Vector2(-999, -999);
    Vector2 pA = Vector2.zero;
    Vector2 pB = Vector2.zero;
    Vector2 pC = Vector2.zero;
    Vector2 pD = Vector2.zero;
    bool isDownSet = false;
    CameraFollow cameraFollow;
    // Update is called once per frame
    void Update () {
        //Is left button being pressed?
        if (Input.GetMouseButton(0)) {
            //
            if (this.point_Down.x == -999 && this.point_Down.y == -999)
            {
                if (this.isDownSet)
                {
                    Debug.Log("Left Button Pressed");
                    this.point_Down.Set(Input.mousePosition.x, Input.mousePosition.y);
                    Debug.Log(point_Down.ToString());
                    point_Down = Camera.main.ScreenToWorldPoint(point_Down);
                    this.button.transform.localPosition = new Vector3(point_Down.x, point_Down.y,-1f);
                    point_Down = Camera.main.WorldToScreenPoint(point_Down);
                    this.cameraFollow.disCB_Cam = this.button.transform.position - Camera.main.transform.position;

                    this.button.SetActive(true);
                }
                else
                {
                    this.isDownSet = true;
                }
            }
            else
            {
                this.point_Now.Set(Input.mousePosition.x, Input.mousePosition.y);

                point_Now = Camera.main.ScreenToWorldPoint(point_Now);
                this.buttonNow.transform.localPosition = new Vector3(point_Now.x, point_Now.y, -1f);
                this.buttonNow.SetActive(true);
                point_Now = Camera.main.WorldToScreenPoint(point_Now);
                disDownToNow = Vector2.Distance(this.point_Down, point_Now);
                if (disDownToNow < this.inR)
                {
                    //Debug.Log("0");
                    return;
                }
               // Debug.Log(this.point_Down.ToString() +"||"+this.point_Now.ToString());

                int stateNew = this.checkNowPoition(this.point_Down, this.point_Now);
                Debug.Log(stateNew.ToString());
                switch (stateNew)
                {
                    case 1:
                        this.carSpeedUp();
                        break;
                    case 2:
                        this.carRight();
                        break;
                    case 3:
                        this.carBrake();
                        break;
                    case 4:
                        this.carLeft();
                        break;
                    case -1:
                        Debug.Log("不知道");
                        break;
                }

            }
            

        }

        if (Input.GetMouseButtonUp(0))
        {
            this.player.GetComponent<PlayerManager>().playerState = 0;
            point_Down = new Vector2(-999, -999);
            point_Now = new Vector2(-999, -999);
            pA = Vector2.zero;
            pB = Vector2.zero;
            pC = Vector2.zero;
            pD = Vector2.zero;
            isDownSet = false;
            this.button.SetActive(false);
            this.buttonNow.SetActive(false);
            
        }
    }

    public void carBrake()
    {
        this.player.GetComponent<PlayerManager>().playerState = 2;
    }
    public void carSpeedUp()
    {
        this.player.GetComponent<PlayerManager>().playerState = 1;
    }
    public void carLeft()
    {
        this.player.GetComponent<PlayerManager>().playerState = 3;
    }
    public void carRight()
    {
        this.player.GetComponent<PlayerManager>().playerState = 4;
    }




    float nowToR1 = -1;
    float nowToR2 = -1;
    float nowToR3 = -1;
    float nowToR4 = -1;
    // Determine whether point P in triangle ABC
    int checkNowPoition(Vector2 down, Vector2 now)
    {
        pA.Set(down.x, down.y + outR);
        pB.Set(down.x + outR, down.y);
        pC.Set(down.x , down.y - outR);
        pD.Set(down.x - outR, down.y);
        
        nowToR1 = Vector2.Distance(pA, now);
        nowToR2 = Vector2.Distance(pB, now);
        nowToR3 = Vector2.Distance(pC, now);
        nowToR4 = Vector2.Distance(pD, now);

        if (nowToR1 == nowToR2)
        {
            return 1;
        }
        if (nowToR2 == nowToR3)
        {
            return 3;
        }
        if (nowToR3 == nowToR4)
        {
            return 3;
        }
        if (nowToR4 == nowToR1)
        {
            return 1;
        }

        if (nowToR1 < nowToR2 && nowToR1 < nowToR3 && nowToR1 < nowToR4)
        {
            return 1;
        }
        if (nowToR2 < nowToR1 && nowToR2 < nowToR3 && nowToR2 < nowToR4)
        {
            return 2;
        }
        if (nowToR3 < nowToR2 && nowToR3 < nowToR1 && nowToR3 < nowToR4)
        {
            return 3;
        }
        if (nowToR4 < nowToR2 && nowToR4 < nowToR3 && nowToR4 < nowToR1)
        {
            return 4;
        }



        return -1;
    }
}

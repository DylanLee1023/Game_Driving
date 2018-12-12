using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushThatTaxi : MonoBehaviour {

    public bool Crush = false;

    public GameObject player;
    PlayerManager pm;
    public GameObject TaxiRoot;
    public GameObject Taxi_p;
    public float speed_min = 0;
    public float speed_max = 0;
    public int count_taxi = 0;
    public int count_taxi_max = 0;
    public int allPoints = 0;
    List<Taxi> taxis = new List<Taxi>();
    

    // Use this for initialization
    void Start () {
        if (player != null)
        {
            pm = player.GetComponent<PlayerManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Crush)
        {
            this.createTaxi();
        }

    }

    void createTaxi()
    {
        if (this.count_taxi < this.count_taxi_max)
        {
            GameObject g = GameObject.Instantiate(this.Taxi_p, this.TaxiRoot.transform);
            
            Taxi t = g.GetComponent<Taxi>();
            taxis.Add(t);
            t.speed = Random.Range(this.speed_min,this.speed_max);
            t.pm = this.pm;
            t.ct = this;
            g.transform.localScale *= 2;
            int randPostion = (int)Random.Range(0, 6);
            float x = 0.0f;
            float y = 0.0f;
            switch (randPostion)
            {
                case 1:
                    x = -5f;
                    break;
                case 2:
                    x = -2.9f;
                    break;
                case 3:
                    x = -0.7f;
                    break;
                case 4:
                    x = 1.5f;
                    break;
                case 5:
                    x = 4f;
                    break;
                default:
                    x = 4f;
                    break;
            }
            randPostion = (int)Random.Range(0, 6);
            switch (randPostion)
            {
                case 1:
                    y = 2f;
                    break;
                case 2:
                    y = 4f;
                    break;
                case 3:
                    y = 6f;
                    break;
                case 4:
                    y = 8f;
                    break;
                case 5:
                    y = 10f;
                    break;
                default:
                    y = 10f;
                    break;

            }
            g.transform.localPosition = new Vector3(x,y,0.0f);


            this.count_taxi++;

        }
        


    }

    public void taxiCrushed(int points)
    {
        this.allPoints += points;
        this.count_taxi--;



    }

    public void taxiReset()
    {
        for (int i = 0; i < this.taxis.Count; i++)
        {
            int randPostion = (int)Random.Range(0, 6);
            float x = 0.0f;
            float y = 0.0f;
            switch (randPostion)
            {
                case 1:
                    x = -5f;
                    break;
                case 2:
                    x = -2.9f;
                    break;
                case 3:
                    x = -0.7f;
                    break;
                case 4:
                    x = 1.5f;
                    break;
                case 5:
                    x = 4f;
                    break;
                default:
                    x = 4f;
                    break;
            }
            randPostion = (int)Random.Range(0, 6);
            switch (randPostion)
            {
                case 1:
                    y = 2f;
                    break;
                case 2:
                    y = 4f;
                    break;
                case 3:
                    y = 6f;
                    break;
                case 4:
                    y = 8f;
                    break;
                case 5:
                    y = 10f;
                    break;
                default:
                    y = 10f;
                    break;

            }
            this.taxis[i].transform.localPosition = new Vector3(x, y, 0.0f);
            this.taxis[i].gameObject.SetActive(true);
        }
 

    }

}

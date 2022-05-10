using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platFormMoving : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float yStart;
    private float dist;
    public float xPosition;
    public float zPosition;
    public float amp;
    // Update is called once per frame
    void Update()
    {
        TouchBottomLevel();
    }
    public void TouchBottomLevel(){
        dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist <300){
            Moving();
        }
    }
    public void Moving(){    
    float yPosition = yStart+Mathf.Sin(Time.time*speed)*amp;
    transform.position = new Vector3(xPosition,yPosition , zPosition);

    }
}

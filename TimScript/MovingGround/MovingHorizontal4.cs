using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHorizontal4 : MonoBehaviour
{
    Player_MovementTim playerClass;
    public float amp;
    public float speed;
    public float xStart;
    public GameObject player;
    private float dist;
    public float yPosition;
    public float zPosition;
    public bool isGround;
    public bool isCube;
    public bool moveLeft;
    // Start is called before the first frame update
    void Start()
    {
         playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_MovementTim>();
    }
    // Update is called once per frame
    void Update()
    {
        SawMove();
        SawCollision();
    }
    // move the saw up and down
    void SawMove(){
        float xPosition;
        if(moveLeft){
            xPosition = xStart-Mathf.Sin(Time.time*speed)*amp;
        }
        else{
            xPosition = xStart+Mathf.Sin(Time.time*speed)*amp;
        }

        transform.position = new Vector3(xPosition,yPosition , zPosition);
    }
   
    
    // check if the player colide the saw and di
     void SawCollision(){
        dist = Vector3.Distance(transform.position, player.transform.position);
        // check if the object is 'ground' 'saw' or 'spider' 
        if(!isGround){
            if(dist<100){
                player.SetActive(false);
                
            }
        }
        else if(isCube){
            if(dist<100){
                for(int i=0; i<10; i++){
                    playerClass.FollowGroundCube4();
                }
                
            }
        }
    }
}

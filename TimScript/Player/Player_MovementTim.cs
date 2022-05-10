using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_MovementTim : MonoBehaviour
{
      public int zScale;
      public int speed = 25;
      private Rigidbody rb;
      public float jumpForce;
      private int gravitymodifier = 20;
      public bool touchingGround;
      private bool jumped;
      private bool isGround;
      private float h;
      private bool cont =true;
      public static bool IsInputEnabled;
      public GameObject groundCube1;
      public GameObject groundCube2;
      public GameObject groundCube3;
      public GameObject groundCube4;
      public GameObject groundBottom;
      public GameObject groundStopTime;
      private Text Time;
      private Image Clock;
      private Text GameOverText;
      public bool touchBottom =false; 
      private float dist;
      RockBall rockBall; 
      RotationRock rockRolling;
      public GameObject fallRockZone;
      FallRock fallRock;
      private float dist1;
      private float dist2;
      public bool go;
      private bool push;
      private Animator anim;
      
      void Start(){
            
            GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
            Time= GameObject.Find("Time").GetComponent<Text>();
            Clock = GameObject.Find("Clock").GetComponent<Image>();
            fallRock = GameObject.FindGameObjectWithTag("FallRock").GetComponent<FallRock>();
            rockBall = GameObject.FindGameObjectWithTag("Rock").GetComponent<RockBall>();
            rockRolling = GameObject.FindGameObjectWithTag("Rock").GetComponent<RotationRock>();
            IsInputEnabled= true;
            go=false;  
            Time.enabled=false;
            Clock.enabled=false;
            GameOverText.enabled=false;     
      }
      void Update() {
            StopTime();
            Playerjump();
            HitRockFallZone();
            TouchingBottomGround();
            JumpAnimation();
            if(touchBottom){
                  rockBall.SawMove();
                  rockRolling.RockRolling();
            }
      }
      void FixedUpdate (){
            PlayerWalk();
      }
      void Awake(){
            rb = GetComponent<Rigidbody>();
            anim=GetComponent<Animator>();
      }
      void PlayerWalk(){
             h = Input.GetAxisRaw("Horizontal"); // input from key left or right
            if(h>0 && IsInputEnabled){
                 rb.velocity = new Vector2(2*speed, rb.velocity.y);// the charactor moving to right(position speed), but continue hold the ypos
                   ChangeDirection(zScale);  
            }
            else if (h<0 && IsInputEnabled){
                  rb.velocity = new Vector2(-2*speed, rb.velocity.y);
                  ChangeDirection(-zScale);
            }
              else{
                  rb.velocity = new Vector2(0f, rb.velocity.y);
            }
            anim.SetInteger("Speed", Mathf.Abs((int)rb.velocity.x));

      }
      // method to disable the input arrow keys when the player on the skateboard 
      public void BreakInput(){
                IsInputEnabled = true;  
      }
     
       // fucntion to make the player follow the ground
     
      public void FollowGroundCube1(){
            transform.position= new Vector3(groundCube1.transform.position.x, transform.position.y, transform.position.z);
      }
      public void FollowGroundCube2(){ 
            transform.position= new Vector3(groundCube2.transform.position.x, transform.position.y, transform.position.z);
      }
      public void FollowGroundCube3(){      
            transform.position= new Vector3(groundCube3.transform.position.x, transform.position.y, transform.position.z);
      }
        public void FollowGroundCube4(){ 
            transform.position= new Vector3(groundCube4.transform.position.x, transform.position.y, transform.position.z);
      }
      public void ChangeDirection(int direction){
        Vector3 tempScale = transform.localScale;
        tempScale.z = direction;
        transform.localScale = tempScale;
      }
       // function for jump movement after pressing the space key
      void Playerjump(){ 
            if(touchingGround){
                  if(Input.GetKey(KeyCode.Space) && (touchingGround)){
                       
                        jumped = true;
                        rb.velocity= new Vector2(rb.velocity.x, jumpForce);
                  }
            }
      }

// Detect collision with floor
      void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BottomGround"){
            touchingGround=true;
                 
        }
      }
       // Detect collision exit with floor
     void OnCollisionExit(Collision collision)
     {
         if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BottomGround" )
         {
            touchingGround = false;
         }
     }
     void JumpAnimation(){
           if(touchingGround==true){
                 anim.SetBool("Jump", false);
           }
           else{
                 anim.SetBool("Jump", true);
           }
     }
       // check if the player touch the 1st bottom ground
      void TouchingBottomGround(){
            float dist = Vector3.Distance(groundBottom.transform.position, transform.position);
        if(dist<=400){
            touchBottom=true;   
        }
    }
    // hit the limit zone and triger the rock to fall down 
     public void HitRockFallZone(){
           dist1 = Vector3.Distance(transform.position, fallRockZone.transform.position);
          
           if(dist1 <300){
                 fallRock.Fall();
           }
     }
     // make the counting timer stop when the player get out of the hole
     private void StopTime(){
           dist2= Vector3.Distance(transform.position, groundStopTime.transform.position);
           if(dist2<1120){
                 Time.enabled=false;
                 Clock.enabled=false;
                 cont=true;
                  GameOverText.enabled=false;
           }
          
     }
}
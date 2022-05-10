using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class BugMovement : MonoBehaviour
{
    public float speed = 50f;
    private bool moveLeft;
    public GameObject Player;
    public Transform down_collison;
    private Text GameOverText;
    public GameObject spiderFireLeft;
    public GameObject spiderFireRight;
    private float dist;
    private float nextFire; 
    private float fireRate; 
    public bool Fire;
    private List<GameObject> fireClones = new List<GameObject>();
  
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
        fireRate = 2f;
        GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
        GameOverText.enabled=false;  
        Player = GameObject.FindWithTag("Player");
        moveLeft=false;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moveLeft){
            this.transform.position += new Vector3(-speed*Time.deltaTime, 0f, 0f);
            if(Fire){
                Fireball_Left();
            }
            
        }
        else{
             this.transform.position += new Vector3(speed*Time.deltaTime, 0f, 0f);
             if(Fire){
                Fireball_Right();
             }
             
        }
        CheckCollison();
    }
    // detect the collison between the player and bug
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="Player"){
            Player.SetActive(false);
            GameOverText.enabled=true; 
            StartCoroutine(RestartGame());
        }
    }
    // check Collision between the bug and the ground
    void CheckCollison(){
        RaycastHit hit;
         Vector3 dwn = down_collison.TransformDirection(Vector3.down);
        //  detect if the spider is not collide with the ground
        if(!Physics.Raycast(down_collison.position,dwn,out hit, 100.0f)){
          moveLeft= !moveLeft;
          if(moveLeft){
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z );
          }
          else{
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z );
          }
        }
    }


    void Fireball_Left(){
        dist = Vector3.Distance(Player.transform.position, transform.position);
        if(dist <= 700){
            if(Time.time > nextFire){
                GameObject fireClone = (GameObject)Instantiate(spiderFireLeft, transform.position, Quaternion.identity);
                fireClones.Add(fireClone);
                nextFire = Time.time + fireRate;
            }
        }
    }
    void Fireball_Right(){
        dist = Vector3.Distance(Player.transform.position, transform.position);
        if(dist <= 700){
            if(Time.time > nextFire){
                GameObject fireClone = (GameObject)Instantiate(spiderFireRight, transform.position, Quaternion.identity);
                fireClones.Add(fireClone);
                nextFire = Time.time + fireRate;
            }
        }
    }
    // restart the game
     IEnumerator RestartGame(){
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TimLevel");
    }
   
}

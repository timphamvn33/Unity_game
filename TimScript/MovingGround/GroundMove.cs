using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GroundMove : MonoBehaviour
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
    public bool moveLeft;
    private Text GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
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
            if(dist<80){
                player.SetActive(false);
                GameOverText.enabled=true; 
                StartCoroutine(RestartGame());
            }
        }  
    }
     // restart the game
     IEnumerator RestartGame(){
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TimLevel");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RockBall : MonoBehaviour
{
    public float speed;
    public float xStart;
    public GameObject player;
    private float dist;
    public float yPosition;
    public float zPosition;
    private float dist1;
    private float xPosition;
    public int xLimit;
    private Text GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
        GameOverText.enabled=false;
        xPosition=2687;
    }
    // Update is called once per frame
    void Update()
    {
        SawCollision();
    }
    // move the rock left to right
     public void SawMove(){
        if(xPosition>xLimit){
            xPosition = xStart-Time.time*speed;
            transform.position = new Vector3(xPosition,yPosition , zPosition);
        }
        else{
            xPosition=xLimit;
            transform.position = new Vector3(xPosition,yPosition , zPosition);
        }
    }
    // check if the player colide the saw and di
     void SawCollision(){
        dist = Vector3.Distance(transform.position, player.transform.position);
        // check if the object is 'ground' 'saw' or 'spider' 
            if(dist<100){
                player.SetActive(false); 
                GameOverText.enabled=true;
                StartCoroutine(RestartGame());
            }
      }
        IEnumerator RestartGame(){
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TimLevel");
    }
}

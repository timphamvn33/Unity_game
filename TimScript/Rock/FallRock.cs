using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FallRock : MonoBehaviour
{
    
    public float speed;
    public float yStart;
    public GameObject player;
    private float dist;
    public float xPosition;
    public float zPosition;
    public float speedRoll;
    private bool fall=false;
    private float yPosition;
    private GamePlayManager gameManager;
    private Text GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
        GameOverText.enabled=false;
    }
    void Update()
    {
        RockFall();
        RockCollision();
    }
    public void Fall(){
        fall=true;
    }
    void RockFall(){
        if(fall){
            yStart -= speed;
            transform.position = new Vector3(xPosition, yStart, zPosition);
            transform.Rotate(speedRoll*Time.deltaTime, 0.0f, 0.0f);
            fall=false;
        }
        else{
            transform.position = new Vector3(xPosition,yStart , zPosition);
        }
    }
     void RockCollision(){
        dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist<80){
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stopGameOver : MonoBehaviour
{
    public GameObject groundStopTime;
    private Text Time;
    private Image Clock;
    private Text GameOverText;
    private GamePlayManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager=gameObject.GetComponent<GamePlayManager>();
        gameManager=gameObject.GetComponent<GamePlayManager>();
        Time= GameObject.Find("Time").GetComponent<Text>();
        Clock = GameObject.Find("Clock").GetComponent<Image>();
        GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
        Time.enabled=false;
        Clock.enabled=false;
        GameOverText.enabled=false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // make the counting timer stop when the player get out of the hole
    void OnCollisionEnter(Collision collision){
    if(collision.gameObject.tag == "CheckPoint"){
            Time.enabled=false;
            Clock.enabled=false;
            GameOverText.enabled=false;
            gameManager.removeStop();
        }
    }
}

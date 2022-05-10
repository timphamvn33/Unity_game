using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;
    [SerializeField]
    private Text Time;
    private Image Clock;
    private Text GameOverText;
    public int countdownTimer;
    private bool startTime=false;
    private int countTouch=0;
    public bool stop;
    private float dist;
    public GameObject CheckGround;
    // Start is called before the first frame update
    void Awake(){
        if(instance ==null)
        instance=this;
    }
    void Start()
    {
       Time= GameObject.Find("Time").GetComponent<Text>();
       Clock = GameObject.Find("Clock").GetComponent<Image>();
       GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
       GameOverText.enabled=false;
       Clock.enabled=false;
       Time.enabled=false;
    }
    void Update(){
        CheckPoint();
       if(countTouch==1){
           if(startTime){
                Time.text=countdownTimer.ToString();
                StartCoroutine("CountDown");
                startTime=false;
           }
       }
    }
    IEnumerator CountDown(){
        yield return new WaitForSeconds(1f);// count down per second 
        countdownTimer-=1;
        Time.text=countdownTimer.ToString();// update the timer into the UI 
        StartCoroutine("CountDown");
        if(countdownTimer<=0){
            StopCoroutine("CountDown");
            // Timer disappear
            Time.enabled=false;
            Clock.enabled=false;
            GameOverText.enabled=true;// show the "Game Over" text.
            if(stop){
                StartCoroutine(RestartGame());
            }
        }   
    }
      // touch the bottom ground and triger the time
     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "BottomGround"){
            startTime=true;
            countTouch++; // count how many time the player touch the ground. 
            // show the Timer
            Time.enabled=true;
            Clock.enabled=true;
            stop=true;
        }
    }
    void CheckPoint(){
        dist= Vector3.Distance(transform.position, CheckGround.transform.position);
        
        if(dist<1100){
            stop=false;
            print("hello");
        }
    }
    IEnumerator RestartGame(){
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TimLevel");
    }
    // helper method used by another class
    public void removeStop(){
        stop=false;
        print("hello");
    }
}

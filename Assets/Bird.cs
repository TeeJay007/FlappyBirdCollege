using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public GameObject pipePrefab;
    public static int Points = 0;
    public static bool IsAlive = true;

    public static bool IsPlaying = false;

    public GameObject ScoreUI;
    private TextMeshProUGUI scoreText;

    void Awake()
    {
        this.rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        this.scoreText = ScoreUI.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            if(!IsAlive){
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                Points = 0;
                IsAlive = true;
                IsPlaying = false;
                
                return;
            }

            if(!IsPlaying){
                IsPlaying = true;
                gameObject.GetComponent<Rigidbody2D>().simulated = true;
                Destroy(GameObject.Find("PressToPlay"));
            }

            rigidbody2D.AddForce(new Vector2(0, 200)); //pasokimas
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Point")){
            Points++; //tasku dejimas
            Destroy(col.gameObject);
            Instantiate(pipePrefab);
            scoreText.SetText("Score: " + Bird.Points);
        }
        if(col.gameObject.CompareTag("Pipe") || col.gameObject.CompareTag("Ground")){
            IsAlive = false;
            int oldHighscore = PlayerPrefs.GetInt("Highscore", 0);
            if(Bird.Points > oldHighscore){
                PlayerPrefs.SetInt("Highscore", Bird.Points);
                oldHighscore = Bird.Points;
            }
            scoreText.SetText("Highscore: " + oldHighscore + "\n Tap to play again");
        }
    }
}

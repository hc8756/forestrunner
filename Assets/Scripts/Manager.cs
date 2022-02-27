using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //From here to 
    public GameObject player;
    public Text score;
    public static float leftBound=-2.0f;
    public static float rightBound=2.0f;
    public int distance = 0;
    public List<int> scores = new List<int>();
    public List<string> names = new List<string>();

    public static Manager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
       
    }//here is only executed once no matter how many times you replay

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        //if we are in game scene
        if (player != null) {
            //update distance tracker
            score = GameObject.FindWithTag("scoreText").GetComponent<Text>();
            //this also makes the start zero every play
            distance = (int)player.transform.position.z+ 25;
            score.text = "Current Distance:" + distance; 
        }
    }

    //method called by player at death
    public void ToGameOver()
    {
        //current distance is added to score
        scores.Add(distance);
        StartCoroutine(EndGame());
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}

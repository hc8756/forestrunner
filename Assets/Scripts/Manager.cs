using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
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
       
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null) {
            score = GameObject.FindWithTag("scoreText").GetComponent<Text>();
            distance = (int)player.transform.position.z+ 25;
            score.text = "Current Distance:" + distance; 
        }
    }

    public void ToGameOver()
    {
        scores.Add(distance);
        StartCoroutine(EndGame());
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}

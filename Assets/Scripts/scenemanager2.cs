using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scenemanager2 : MonoBehaviour
{
    public GameObject managerObject;
    public Button playButton;
    public List<Text> rows = new List<Text>();
    //lists to copy scores and names from manager
    public List<int> scores = new List<int>();
    public List<string> names = new List<string>();

    //lists used when sorting scores 
    public List<int> maxScores = new List<int>();
    public List<int> oldIndices = new List<int>();
    void Start()
    {
        managerObject = GameObject.FindWithTag("Manager");
        if (managerObject != null) {
            scores = managerObject.GetComponent<Manager>().scores;
            names = managerObject.GetComponent<Manager>().names;
            SortList();
            for (int i = 0; i < 5; i++)
            {
                if (scores.Count > i)
                {
                    rows[i].text = i + 1 + ". " + names[oldIndices[i]] + " : " + maxScores[i];
                }
            }
        }
        else {
            for (int i = 0; i < 5; i++)
            {
                rows[i].text = "";
            }
        }
        playButton.onClick.AddListener(StartGame);
    }


    void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void SortList() {
        int maxIndex = -1;
        for (int j = 0; j < scores.Count; j++) {
            //loop through scores
            int max = 0;
            //find max value and store location on scores list
            for (int i = 0; i < scores.Count;i++ ) {
                if (scores[i] > max && !oldIndices.Contains(i)) {
                    max = scores[i];
                    maxIndex = i;
                }
            }
            //add the max value to max list
            maxScores.Add(max);
            //add the max location to index list
            //this will be used to locate the player's name from the names list
            oldIndices.Add(maxIndex);
        }//repeat for the number of elements in list
    }
}

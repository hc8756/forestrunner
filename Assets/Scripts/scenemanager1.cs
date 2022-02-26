using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scenemanager1 : MonoBehaviour
{
    public GameObject managerObject;
    public InputField nameInput;
    public Text score;
    public List<int> scores = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        managerObject=GameObject.FindWithTag("Manager");
        scores = managerObject.GetComponent<Manager>().scores;
        score.text = scores[scores.Count - 1].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (nameInput.text == "") { managerObject.GetComponent<Manager>().names.Add("???"); }
            else { managerObject.GetComponent<Manager>().names.Add(nameInput.text); }
            SceneManager.LoadScene("LeaderBoard");
        }
    }
}

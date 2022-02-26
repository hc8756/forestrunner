using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject[] sections;
    public List<GameObject> presentSections = new List<GameObject>();
    public int zPos = 0;
    public bool creatingSection = false;
    public int secNum;
    void Start() {
        for (int i = 2; i < 4; i++) {
            presentSections.Add(Instantiate(sections[i], new Vector3(0, 0, zPos), Quaternion.identity));
            zPos += 20;
        }
    }
    void Update()
    {
        if (creatingSection == false) {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }

        foreach (GameObject obj in presentSections.ToArray())
        {
            if (obj.transform.position.z +20 < player.transform.position.z) {
                presentSections.Remove(obj);
                Destroy(obj);
            }
        }

    }

    IEnumerator GenerateSection() {
        secNum = Random.Range(0, 6);
        presentSections.Add(Instantiate(sections[secNum], new Vector3(0, 0, zPos), Quaternion.identity));
        zPos += 20;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}

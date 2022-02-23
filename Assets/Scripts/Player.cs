using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //speed forward and speed side to side 
    public float speedF = 3;
    public float speedS = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speedF, Space.World);
        if (Input.GetKey(KeyCode.A) && this.gameObject.transform.position.x>Manager.leftBound) {
            transform.Translate(Vector3.left * Time.deltaTime * speedS, Space.World);
        }
        else if (Input.GetKey(KeyCode.D) && this.gameObject.transform.position.x < Manager.rightBound)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedS, Space.World);
        }
    }
}

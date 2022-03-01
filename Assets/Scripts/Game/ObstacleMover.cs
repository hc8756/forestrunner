using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public GameObject managerObject;
    private float speed;
    private bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        managerObject = GameObject.FindWithTag("Manager");
        //randomly generate starting direction and speed
        movingRight = (Random.value < 0.5);
        speed = Random.Range(3.0f, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //set bool that decides movement direction
        if (this.gameObject.transform.position.x >= Manager.rightBound) {
            movingRight = false;
        }
        if (this.gameObject.transform.position.x <= Manager.leftBound)
        {
            movingRight = true;
        }
        //and move obstacle
        if (movingRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
    }
}

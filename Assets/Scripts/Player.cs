using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //speed forward and speed side to side 
    Rigidbody rb;
    GameObject firstChild;
    Animator anim;
    public float speedF = 5;
    public float speedS = 4;
    public Vector3 jump;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -30.0F, 0);
        firstChild = this.gameObject.transform.GetChild(0).gameObject;
        anim = firstChild.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 13.0f, 1.0f);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
            anim.SetBool("Jumping", false);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            anim.SetBool("Hit", true);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.forward * Time.deltaTime * speedF, Space.World);
        if (Input.GetKey(KeyCode.A) && this.gameObject.transform.position.x>Manager.leftBound && isGrounded) {
            transform.Translate(Vector3.left * Time.deltaTime * speedS, Space.World);
        }
        if (Input.GetKey(KeyCode.D) && this.gameObject.transform.position.x < Manager.rightBound && isGrounded)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedS, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            if (transform.position.y <= 1.26f) {rb.AddForce(jump, ForceMode.Impulse);anim.SetBool("Jumping", true);  }
            
            
        }
    }
}

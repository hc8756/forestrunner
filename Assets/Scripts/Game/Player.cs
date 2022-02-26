using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //speed forward and speed side to side 
    Rigidbody rb;
    GameObject firstChild;
    Animator anim;
    public GameObject managerObject;
    public float speedF = 5;
    public float speedS = 4;
    public Vector3 jump;
    public bool isGrounded;
    private bool gameover = false;
    // Start is called before the first frame update
    void Start()
    {
        managerObject = GameObject.FindWithTag("Manager");
        Physics.gravity = new Vector3(0, -30.0F, 0);
        firstChild = this.gameObject.transform.GetChild(0).gameObject;
        anim = firstChild.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
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
            if (transform.position.z < collision.gameObject.transform.position.z) { 
                anim.SetBool("Hit", true);
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
                gameover = true;
                speedF = 0.0f;
                managerObject.GetComponent<Manager>().ToGameOver();
            }
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover) {speedF = speedF + 0.0003f; }
        
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

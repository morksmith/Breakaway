using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeRoam : MonoBehaviour
{
    public float MoveSpeed = 4;

    private float moveX;
    private float moveY;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        rb.velocity = new Vector2(moveX, moveY);
        //transform.position = new Vector3(moveX, moveY, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fish")
        {
            SceneManager.LoadScene(3);
        }
    }
}

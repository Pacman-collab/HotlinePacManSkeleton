using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction = Vector2.zero;
    public Text points;
    public int scoreValue;

    
    
    void Start()
    {
      scoreCheck();
       rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Checkinput();
        Move();
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

     void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    
    //Collecting the pellets and scoring
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pellet")
        {
            Destroy(collision.collider.gameObject);
            scoreValue += 1;
            scoreCheck();
        }
    }





//Updates Score everytime peelet is picked up
void scoreCheck()
{
    points.text = "Score: " + scoreValue.ToString();
}





//PLAYER MOVEMENT
void Checkinput()
{
    if (Input.GetKeyDown("left"))
    {
        direction = Vector2.left;
    }

   else if (Input.GetKeyDown("right"))
   {
        direction = Vector2.right;
   }
    
    else if (Input.GetKeyDown("up"))
   {
        direction = Vector2.up;
   }

   else if (Input.GetKeyDown("down"))
   {
       direction = Vector2.down;
   }
}

void Move ( )
{
    transform.position += (Vector3)(direction * speed) * Time.deltaTime;
}
}

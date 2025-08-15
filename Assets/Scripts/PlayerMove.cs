using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Global variables can be used in any method in this class
    public GameObject player;

    SpriteRenderer spriteRenderer;//SpriteRenderer to change the player's sprite

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null )
        {
            Debug.LogError("Are you sure this is a sprite?");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow)) direction.y = 1;
        if (Input.GetKeyDown(KeyCode.DownArrow)) direction.y = -1;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction.x = -1;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction.x = 1;
            spriteRenderer.flipX = false;
        }

        transform.position += direction;

        //Check for collision after moving - 64 is the layer mask for the "Wall" layer (7th layer in Unity; 0 indexed)
        Collider2D collision = Physics2D.OverlapCircle(transform.position, 0.1f,64);
        if (collision != null)
        {
            transform.position -= direction;
            Debug.Log("Collision detected with" + collision.gameObject.name);
        }





    }

        
        
    }
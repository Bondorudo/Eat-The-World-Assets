using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 diff;
    private Vector3 mousePos;

    public int foodEaten = 0;
    private int foodCheck;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Rotate the sprite to the mouse point
        diff = mousePos - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        // Move the sprite towards the mouse
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When colliding with food destroy food and call IncreaseSize function
        IncreaseSize();
        Destroy(collision.gameObject);
    }

    private void IncreaseSize()
    {
        // Increase food eaten and check if should increase size
        foodEaten++;
        foodCheck = foodEaten % 10;
        if (foodCheck == 0 || foodCheck == 5)
        {
            transform.localScale += new Vector3(0.15f, 0.15f, 0.15f);
            Debug.Log("Size increase");
        }
    }
}

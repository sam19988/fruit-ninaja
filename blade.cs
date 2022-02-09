using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minVelocity = 0.1f;
    private Vector3 lastMousePosition;
    private Vector3 mouseVelocity;
    private Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        col.enabled = isMouseMoving();
        setBladeToMouse();
       
    }

    private void setBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10f;

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool isMouseMoving()
    {
      
        Vector2 direction = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
        while (direction.magnitude > 0)
        {
            return true;
        }
        return false;
    }

}

using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}

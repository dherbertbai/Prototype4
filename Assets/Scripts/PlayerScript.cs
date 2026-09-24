using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer playerColor;
    public Rigidbody2D rb;
    public float speed;
    public Color baseColor;
    public bool touch;
    public bool day;
    
    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector2 vel = Vector2.zero;
        if (Keyboard.current.dKey.isPressed)
            vel.x = speed;
        else if (Keyboard.current.aKey.isPressed)
            vel.x = -speed;
        if (Keyboard.current.wKey.isPressed)
            vel.y = speed;
        else if (Keyboard.current.sKey.isPressed)
            vel.y = -speed;
        rb.linearVelocity = vel;

        if (touch && !day)
        {
            if (time < 0.2f)
            {
                playerColor.color = Color.yellow;
            }
            else
            {
                playerColor.color = baseColor;
                touch = false;
            }
        }
        else
        {
            playerColor.color = baseColor;
        }
        
        
    }

    public void NightLight()
    {
        baseColor = Color.seaGreen;
        day = false;
    }
    public void DayLight()
    {
        baseColor = Color.paleGreen;
        day = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        time = 0;
        touch = true;
        throw new NotImplementedException();
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class GameScript : MonoBehaviour
{
    public SpriteRenderer sky;
    public PlayerScript player;
    public GlowScript glow;
    public float time;
    public float timeSpeed;

    public int hour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        glow = GameObject.FindGameObjectWithTag("Glow").GetComponent<GlowScript>();
        time = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime * timeSpeed;

        if (time >= 24)
        {
            time = 0;
        }
        
        // 6-8 8-18 18-20 20-6
        if (time >= 8 && time < 18)
        {
            Day();
        }
        else if (time >= 18 && time < 20)
        {
            Dusk();
        }
        else if (time >= 20 && time < 24 || time >= 0  && time < 6)
        {
            Night();
        }
        else if (time >= 6 && time < 8)
        {
            Dawn();
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            timeSpeed = 2;
        }
        else
        {
            timeSpeed = 0.5f;
        }
    }

    public void Day()
    {
        sky.color = Color.lightSkyBlue;
        player.DayLight();
    }

    public void Dusk()
    {
        if (time <= 18.3f)
        {
            sky.color = Color.mediumPurple;
        }
        else if (time >= 19.7f)
        {
            sky.color = Color.darkRed;
        }
        else
        {
            sky.color = Color.brown;
        }
    }

    public void Night()
    {
        sky.color = Color.gray1;
        player.NightLight();
        glow.Glow();
    }

    public void Dawn()
    {
        if (time <= 6.3f)
        {
            sky.color = Color.darkRed;
        }
        else if (time >= 7.7f)
        {
            sky.color = Color.softYellow;
        }
        else
        {
            sky.color = Color.chocolate;
        }
        glow.Rest();
    }
}

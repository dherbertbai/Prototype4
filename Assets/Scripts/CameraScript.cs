using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    
    public float speed;
    public float distance;
    public float y;
    public bool follow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        y = transform.position.y;
	
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance > 1)
        {
            follow = true;
        }

        if (distance == 0)
        {
            follow = false;
        }

        if (follow)
        {
            speed = distance*5;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}

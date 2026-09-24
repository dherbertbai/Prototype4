using UnityEngine;

public class GlowScript : MonoBehaviour
{
    public GameObject sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Glow()
    {
        sprite.SetActive(true);
    }

    public void Rest()
    {
        sprite.SetActive(false);
    }
}

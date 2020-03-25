using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HealthandKnockback : MonoBehaviour
{
    // Update is called once per frame
    public Rigidbody rb;
    public Text healthAmount;
    public int health = 10;
    public int maxHealth = 15;
 
    public float knockbackImpulse = 2;
    public float iFrames = 5;
    public float invincibilityTime = 5.0f;
    float timeLeft;
    void Update()
    {
    float healthPercent = ((float)health / (float)maxHealth) * 100.0f;
        healthAmount.text = healthPercent.ToString("F1") + "%";
        timeLeft -= Time.deltaTime;
    }
        void OnCollisionEnter(Collision collision)
        {
            var asteroids = collision.gameObject.GetComponents<MonoBehaviour>().Where(script => script.GetType().GetInterface("breakable") != null);

       

        if (asteroids.Count() <= 0)
        {
            return;
        }

        rb.velocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
        if (timeLeft < 0)
        {
            health--;
            timeLeft = invincibilityTime;
        }



        }
}

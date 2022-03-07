using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public int health;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

    public void OnTriggerEnter2D ( Collider2D other )
    {
        //Inform game UI this object has been destroyed.
        GameObject gameUI = GameObject.Find("GameUI");
        gameUI.SendMessage("addPoint", SendMessageOptions.DontRequireReceiver);

        //check what kind of object was hit
        if (other.gameObject.CompareTag("Laser"))
        {

            //removes laser
            Destroy(other.gameObject);

            //reduce health
            health = health - 1;

            //if health is zero or lower, then destroys ship
            if (health <= 0) {
                Destroy(this.gameObject);

                //make the explosion
                GameObject explo= Instantiate(explosion, this.transform.position, Quaternion.identity);
                Destroy(explo, 1f);
            }
            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("EnenmyCollide");
            Destroy(this.gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = this.transform.position + new Vector3(-speed, 0f, 0f);
        this.transform.position = newPosition;
    }
}

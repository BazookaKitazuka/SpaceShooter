using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    public float speed = 15f;
    private float health;
    public float maxHealth; 
    private Rigidbody2D r2d;
    private GameObject gameUI; 

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        r2d = this.GetComponent<Rigidbody2D>();
        gameUI = GameObject.Find("GameUI");
        health = this.maxHealth;
    }

    public void EnenmyCollide()
    {

        //reduce health
        health = health - 1;
        gameUI.SendMessage("SetHealthPercent", health/this.maxHealth);

        //check if helath is less than or equalto zero
        if (health <= 0)
        {
            //Inform UI player is inactive
            gameUI.SendMessage("showRespawn", SendMessageOptions.DontRequireReceiver);

            this.gameObject.SetActive(false);

            //make the explosion
            GameObject explo= Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(explo, 1f);
        }

        
    }

    public void Respawn()
    {
        this.health = this.maxHealth;
        gameUI.SendMessage("SetHealthPercent", 1.0);
    }

    // Update is called once per frame
    void Update()
    {
        
        //simple movement vector
        Vector2 moveVec = new Vector2();
        moveVec.y = Input.GetAxis("Vertical") * speed;
        r2d.AddForce(moveVec);

        //Shoot response
        if( Input.GetButtonDown("Jump") )
        {
            Instantiate(laserPrefab, this.transform.position, Quaternion.identity);
        }

        if( Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{

    public float shootSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D r2d = this.GetComponent<Rigidbody2D>();
        r2d.AddForce( new Vector2( shootSpeed,0f) );

        Destroy(this.gameObject, 2f);
        
    }

    
}

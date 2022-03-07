using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameUI;


    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf != true)
        {
            if (Input.GetButton("Fire3"))
            {

                player.gameObject.SetActive(true);
                player.SendMessage("Respawn", SendMessageOptions.DontRequireReceiver);

                //Inform UI player is inactive
                GameObject gameUI = GameObject.Find("GameUI");
                gameUI.SendMessage("hideRespawn", SendMessageOptions.DontRequireReceiver);

            }
        }
    }
} 

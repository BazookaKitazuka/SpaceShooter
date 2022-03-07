using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void playGame()
   {
       //Change Game from title to game
        SceneManager.LoadScene("Game");
   }


}

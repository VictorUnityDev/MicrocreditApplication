using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComebackToMenu : MonoBehaviour
{
   public void Back()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   }
}

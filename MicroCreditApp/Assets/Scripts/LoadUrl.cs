
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadUrl : MonoBehaviour
{
   [SerializeField] private Link _link;
   [SerializeField] private string url;
   public void Load()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      _link.address = url;
   }
   
   
}

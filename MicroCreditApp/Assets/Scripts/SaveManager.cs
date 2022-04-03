
using UnityEngine;

public class SaveManager : MonoBehaviour
{
   public bool IsFirstEnter { get; set; }
   

   private void OnEnable()
   {
      Save.OnFirstEnter += Result;
   }

   private void Result(bool result)
   {
      IsFirstEnter = result;
   }

   private void OnDestroy()
   {
      Save.OnFirstEnter -= Result;
   }
}

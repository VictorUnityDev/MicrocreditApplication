using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
   public bool IsFirstEnter { get; set; }
   

   private void Awake()
   {
      Save.OnFirstEnter += Result;
   }

   private void Result(bool result)
   {
      Debug.Log(result);
      IsFirstEnter = result;
   }

   private void OnDestroy()
   {
      Save.OnFirstEnter -= Result;
   }
}

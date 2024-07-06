using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class RightHandColider : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other==Chapter2Sys.instance.btnCols[0])
      {
         Chapter2Sys.instance.isTriggerEnter = true;
         Chapter2Sys.instance.isClear = true;
         InputManager.instance.RightController.SendHapticImpulse(0.5f, 0.1f);
         Debug.Log("오픈");
      }
      else if (other==Chapter2Sys.instance.btnCols[1])
      {
         Chapter2Sys.instance.isTriggerEnter = true;
         Chapter2Sys.instance.isClear = false;
         InputManager.instance.RightController.SendHapticImpulse(0.5f, 0.1f);
         Debug.Log("끝");
      }
   }
}

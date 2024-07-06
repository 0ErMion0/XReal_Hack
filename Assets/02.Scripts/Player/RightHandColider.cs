using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RightHandColider : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if(SceneManager.GetActiveScene().name == "Chapter3")
      {
        if (other == Chapter2Sys.instance.btnCols[0])
        {
            Chapter2Sys.instance.isTriggerEnter = true;
            Chapter2Sys.instance.isClear = true;
            InputManager.instance.RightController.SendHapticImpulse(0.5f, 0.1f);
            Debug.Log("오픈");
        }
        else if (other == Chapter2Sys.instance.btnCols[1])
        {
            Chapter2Sys.instance.isTriggerEnter = true;
            Chapter2Sys.instance.isClear = false;
            InputManager.instance.RightController.SendHapticImpulse(0.5f, 0.1f);
            Debug.Log("끝");
        }
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
   private void onTriggerEnter(Collider other)
    {
        GameObject.Find("Character").SendMessage("Finish");
    }
}

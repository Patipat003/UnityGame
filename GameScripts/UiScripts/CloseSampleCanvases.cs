using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSampleCanvases : MonoBehaviour
{
    public GameObject exit;

    public void Trigger(){
        if(exit.activeInHierarchy == false){
            exit.SetActive(true);

        }
        else{
            exit.SetActive(false);
        }
    }
}

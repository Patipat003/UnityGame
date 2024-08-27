using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("3Warehouse");
    }
}


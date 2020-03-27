using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    public float Number;
    // Number will tell the script which index to go to.
    // Start is called before the first frame update
    void Start()
    {
        
        //if you check build settings, the scene index 0 refers to the 3D scene.
        Number = 1.0f;
        //number 1 refers to the index of 0, or the 3D scene.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Number == 1) {
        Number = 2.0f;
        SetActiveScene(SceneManagement.Scene, 1);
        } else if(Input.GetKeyDown(KeyCode.Space) && Number == 2) {
        Number = 1.0f;
        SetActiveScene(SceneManagement.Scene, 0);
        }
        //number 2 refers to the index of 1, or the 2D scene.
       
        /* This script checks the number when spacebar is pressed, and switches to the other scene, that does not have that number. 
        Right now, that's all you have to do to change scenes- press space. */
    }
}

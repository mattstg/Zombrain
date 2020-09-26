using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void FunctionThatHasSameArgs(Collider coli, string someString)
    {
        Debug.LogError("Coli: " + coli.name + " should be same name tho : " + someString);
    }
}

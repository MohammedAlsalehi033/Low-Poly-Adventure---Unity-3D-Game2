using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI : MonoBehaviour 
{
public Text Version;
public Text UnityVersion;

private void Start() {
    Version.text = "V"+Application.version;
    UnityVersion.text= "Unity"+Application.unityVersion;
}
    public void TheNextScene (string nameofthescene){
        SceneManager.LoadScene(sceneName : nameofthescene);
    }
    public void Enable(GameObject thing){
        thing.SetActive(true);

    }
    public void Disable(GameObject thing){
        thing.SetActive(false);
    }
public void Quit (){
    Application.Quit();
}
public void Internet(string URLname){
    Application.OpenURL(URLname);
}
}

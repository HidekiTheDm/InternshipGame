using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Retry_Quit : MonoBehaviour
{

    [SerializeField] KeyCode _keyCode;

    [SerializeField] UnityEvent _event;

  public void Retry(){

       SceneManager.LoadScene("Lvl_1");
        
    
    }
    public void End(){

        Application.Quit();
        
    
    }

    void Update(){

        if(Input.GetKeyDown(_keyCode)){
            _event?.Invoke();
            
        }
    }

}
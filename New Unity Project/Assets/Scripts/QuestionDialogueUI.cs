using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class QuestionDialogueUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private Button correctBtn;
    private Button wrongBtn;
    public GameObject bullet;
    public GameObject bars;
    public Animator transitionAnim;
    public string SceneName;
    public string SceneLose;
    [SerializeField] KeyCode _keyCode;
    [SerializeField] KeyCode _keyCode2;
    [SerializeField] UnityEvent _event;
    [SerializeField] UnityEvent _event2;
    private void Awake(){
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        correctBtn = transform.Find("Correct").GetComponent<Button>();
        wrongBtn = transform.Find("Wrong").GetComponent<Button>();
        ShowQuestion("Do You Want To Do This?", () => {
            Debug.Log("Correct");
        }, () => {
            Debug.Log("Wrong");
        });
    }

    void Update(){

        if(Input.GetKeyDown(_keyCode)){
            _event?.Invoke();
            
        }

         if(Input.GetKeyDown(_keyCode2)){
            _event2?.Invoke();
            
        }

        

    }
    

    public void ShowQuestion(string questionText, Action correctAction, Action wrongAction){
        textMeshPro.text = questionText;
        correctBtn.onClick.AddListener(()=>{
            //Hide();
            correctAction();
            GoScene();
            ActiveScene();
        });
        wrongBtn.onClick.AddListener(()=>{
            //Hide();
            wrongAction();
            GoLose();
            
        });

    }

    public void Hide(){
        gameObject.SetActive(false);
    }

    public void GoScene(){
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene(){
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneName);
    }
    public void GoLose(){
        StartCoroutine(LoadScene2());
    }
    IEnumerator LoadScene2(){
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneLose);
    }

     private void ActiveScene(){
        bars.SetActive(true);
        //bullet.GetComponent<Animator>().Play("Bullet_Anim");
    }

    
}

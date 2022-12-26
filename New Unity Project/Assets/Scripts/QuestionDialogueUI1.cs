using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

using System.Text;  
using System.IO;
using System.Threading.Tasks;  


public class QuestionDialogueUI1 : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private Button correctBtn;
    private Button wrongBtn;
    private Button wrongBtn1;
    private Button wrongBtn2;
     public GameObject bullet;
    public GameObject bars;
    public Animator transitionAnim;
    public string SceneName;
    public string SceneLose;
    [SerializeField] KeyCode _keyCode;
    [SerializeField] KeyCode _keyCode2;
    [SerializeField] KeyCode _keyCode3;
    [SerializeField] UnityEvent _event;
    [SerializeField] UnityEvent _event2;
    private void Awake(){
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        correctBtn = transform.Find("Correct").GetComponent<Button>();
        wrongBtn = transform.Find("Wrong").GetComponent<Button>();
        wrongBtn1 = transform.Find("Wrong1").GetComponent<Button>();
        ShowQuestion("<div style=[________];bottom:300px></div> \r\n <div style=[________];bottom:300px></div>", () => {
            Debug.Log("Correct");
        }, () => {
            Debug.Log("Wrong");
        });
    }
    
    public void GravarFicheiro(string resp)
    {
        using (StreamWriter writer = new StreamWriter("c:\\SCORE\\Respostas.txt", true))  
        {  
            writer.WriteLine(resp + "1|" + DateTime.Now.ToString());  
            writer.Close();
        } 
    }
    /*public void Carregar_Perguntas_Respostas_Ficheiro(string fich)
    {
        using(StreamReader file = new StreamReader(fich)) 
        {  
            int counter = 0;  
            string ln;  
            
            while ((ln = file.ReadLine()) != null)
            {  
               Debug.Log(ln);  
                counter++;  
            }  
            file.Close();  
        }
    }*/

    public void ShowQuestion(string questionText, Action correctAction, Action wrongAction){
        textMeshPro.text = questionText;
        correctBtn.onClick.AddListener(()=>{
            GravarFicheiro("CORRECTA");
            //Hide();
            correctAction();
            GoScene();
            ActiveScene();
        });
        wrongBtn.onClick.AddListener(()=>{
            //Hide();
            GravarFicheiro("ERRADA");
            wrongAction();
            GoLose();
            
        });
         wrongBtn1.onClick.AddListener(()=>{
            //Hide();
            GravarFicheiro("ERRADA");
            wrongAction();
            GoLose();
        });

    }
    void Update(){

        if(Input.GetKeyDown(_keyCode)){
            _event?.Invoke();
            
        }

        if(Input.GetKeyDown(_keyCode2)){
            _event2?.Invoke();
            
        }

         if(Input.GetKeyDown(_keyCode3)){
            _event2?.Invoke();
            
        }
        

    }


    private void Hide(){
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

    public void ActiveScene(){
        bars.SetActive(true);
        //bullet.GetComponent<Animator>().Play("Bullet_Anim");
    }
}

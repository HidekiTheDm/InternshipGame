using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<PromptsNAnswers> PnA;
    public GameObject[] options;
    public int currentPrompt;

    public Text PromptTxt;



    private void Start(){

        generatePrompt();

    }

    public void correct(){

        PnA.RemoveAt(currentPrompt);
        SceneManager.LoadScene("Lvl_1", LoadSceneMode.Additive);
        
    
    }

    void SetAnswers(){

        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = PnA[currentPrompt].Answers[i];

            if(PnA[currentPrompt].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        
        }
    }

    void generatePrompt(){
        if(PnA.Count > 0){
            currentPrompt =Random.Range(0, PnA.Count);
            PromptTxt.text = PnA[currentPrompt].Prompt;
            SetAnswers();

            
        }
        else{
            SceneManager.LoadScene("Lvl_1", LoadSceneMode.Additive);
        }
        


    }
}

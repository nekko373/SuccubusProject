using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{

    public Text dialogueText;
    public Animator animator;
    private bool hasChoice;
    public Queue<string> sentences;
    public GameObject button1;
    public GameObject button2;

    void Start()
    {
        sentences = new Queue<string>();
        
    }


    public void StartDialogue(Dialogue dialogue)
    {
        button1.GetComponent<Text>().text = dialogue.choice1;
        button2.GetComponent<Text>().text = dialogue.choice2;
        hasChoice = dialogue.hasChoice;
        animator.SetBool("isOpen", true);
    
       
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);


        }
        DisplayNextSentences();
    }


        public void DisplayNextSentences() {

            if (sentences.Count ==0) {
                EndDialogue();
                return;
            }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));


        }
    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }

    }

  

    void EndDialogue() {

        if (hasChoice) {
            //do this
            button1.SetActive(true);
            button2.SetActive(true);
            Debug.Log("hs choice");
            
            animator.SetBool("Choice", true);
            return;
        }
        animator.SetBool("isOpen", false);
        
    }

    public void FirstOption() {
        
        button1.SetActive(false );
        button2.SetActive(false);

    }

    public void SecondOption()
    {
        Debug.Log("Do second option");
        button1.SetActive(false);
        button2.SetActive(false);

    }


}

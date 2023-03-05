using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;
    public Animator animator;
    private Dialogue dialogueVar;
    private void Awake()
    {
        // if (instance != null)
        // {
        //     Debug.LogWarning("Il y a plus d'uns instance de Dialogue Manager dans la sc�ne");
        //     return;
        // }
        // instance = this;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueVar = dialogue;
        dialogue.image.GetComponent<RawImage>().enabled = true;
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach ( string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char  letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
    void EndDialogue()
    {
        dialogueVar.image.GetComponent<RawImage>().enabled = false;
        animator.SetBool("isOpen", false);
    }

}

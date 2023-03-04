using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Text nameText;
    public Text dialogueText;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'uns instance de Dialogue Manager dans la scène");
            return;
        }
        instance = this;
    }


}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectTrigger : MonoBehaviour
{

    public bool isInRange = false;

    private TextMeshProUGUI interactUI;

    public Inventory inventaire;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isInRange = false;
            interactUI.enabled = false;
        }
    }

    void Interact()
    {
        if(this.CompareTag("Eau") == true)
        {
            inventaire.Eau = true;
        } else if(this.CompareTag("Fleur") == true)
        {
            inventaire.Fleur = true;
        }
        else if (this.CompareTag("Regle") == true)
        {
            inventaire.Regle = true;
        }
        else if (this.CompareTag("Colle") == true)
        {
            inventaire.Colle = true;
        }
        else if (this.CompareTag("Affiche") == true)
        {
            inventaire.Affiche = true;
        }
    }
}

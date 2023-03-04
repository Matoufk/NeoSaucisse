using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool isInRange = false;
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.Mouse0))
        {
            TriggerDialogue();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            isInRange = true;
            Debug.Log("Collision");
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isInRange = false;
            Debug.Log("No Collision");
        }
    }

    void TriggerDialogue()
    {

    }
}

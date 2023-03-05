using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrayingTrigger : MonoBehaviour
{

    public bool isInRange = false;

    private TextMeshProUGUI prayingUI;

    public SocialCredit socialCredit;

    private void Awake()
    {
        prayingUI = GameObject.FindGameObjectWithTag("PrayingUI").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            isInRange = true;
            prayingUI.enabled = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isInRange = false;
            prayingUI.enabled = false;
        }
    }

    void Interact()
    {
        if (socialCredit.praying == false) socialCredit.SetSocialCredit(socialCredit.socialCredit + 15);
        socialCredit.praying = true;
    }
}

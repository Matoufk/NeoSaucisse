using UnityEngine;
using TMPro;

public class SocialCredit : MonoBehaviour
{
    public TextMeshProUGUI creditText;
    public int socialCredit = 255;

    public Camera mainCamera;
    public bool BREAK = false;
    private bool OVER = false;
    Color couleur = new Vector4(0, 255, 0, 0);
    private int green = 255;
    private int red = 0;

    private float oldTransX = 0;
    private float oldTransY = 0;

    private GameObject NPC;
    private TrafficLightsHandler TLH;

    private float x;
    private float z;

    public bool praying = false;

    private bool enteredPrayingZone = false;
    private bool hasPrayed = false;
    private bool enteredCrossingZone = false;

    public Animator animator;

    private void Start()
    {
        creditText.material.color = couleur;
        SetSocialCredit(socialCredit);

        NPC = GameObject.Find("PNJ");
        TLH = NPC.GetComponent<TrafficLightsHandler>();
    }
    private void Update()
    {

        x = gameObject.transform.position.x;
        z = gameObject.transform.position.z;

        // On vérifie si une loi est brisée

        // praying
        if (x > -5 && x < 3 && z > -2 && z < 10)
        {
            enteredPrayingZone = true;

            // Le personnage est dans la zone de prières
            if (praying == true)
            {
                hasPrayed = true;
                animator.SetBool("pray", true);



            }

        }

        else if (x > -5 && x < 3 && z > -2 && z < 18)
        {
            enteredPrayingZone = true;
        }
        else if (enteredPrayingZone != hasPrayed)
        {
            if (enteredPrayingZone = false && hasPrayed == true)
            {
                SetSocialCredit(GetSocialCredit() + 15);
                
            }
            else if (enteredPrayingZone = true && hasPrayed == false)
            {
                SetSocialCredit(GetSocialCredit() - 10);
                enteredPrayingZone = false;
            }
        }
        else
        {
            enteredPrayingZone = false;
        }
        // Si on bouge alors on quitte le praying mode
        if ((oldTransX+ oldTransY) != (this.transform.position.x+ this.transform.position.y))
        {
            animator.SetBool("pray", false);
            praying = false;

        }


        oldTransX = this.transform.position.x;
        oldTransY = this.transform.position.y;


        // traverser au rouge
        if (TLH.GetLight() == false)
        {
            if (gameObject.transform.position.x < -14 && gameObject.transform.position.x > -24 && enteredCrossingZone == false)
            {
                //il est sur la route
                enteredCrossingZone = true;
                SetSocialCredit(GetSocialCredit() - 5);
            }
        }
        else if (gameObject.transform.position.x > -14 || gameObject.transform.position.x < -24)
        {
            enteredCrossingZone = false;
        }
        else if (TLH.GetLight() == true)
        {
            enteredCrossingZone = false;
        }


        creditText.transform.LookAt(creditText.transform.position + mainCamera.transform.rotation * Vector3.back, mainCamera.transform.rotation * Vector3.up);
        creditText.GetComponent<RectTransform>().rotation = creditText.GetComponent<RectTransform>().rotation * Quaternion.Euler(0, 180, 0);
        SetSocialCredit(socialCredit);
        if (BREAK && !OVER)
        {
            if (green > 0)
            {
                green -= 1;
                red += 1;
                couleur = new Vector4(red, green, 0, 0);
                creditText.material.color = couleur;

            }
            socialCredit -= 1;
        }
        if (socialCredit <= -2000) OVER = true;
        if (OVER) creditText.text = "B̵̷̷̷̷̷̷͓̘́͜͠͝R̴̷̷̷̷̷̷͍̙͓̓̽͛Ó̸̷̷̷̷̷̷̡͇͕͌͝K̵̷̷̷̷̷̷͓̫͓̈́̾͒Ë̸̷̷̷̷̷̷̙͓̝́̐̚Ǹ̴̷̷̷̷̷̷̷̷̷̷̷̷̢̢̾͝";
    }
    public void SetSocialCredit(int credit)
    {
        socialCredit = credit;
        creditText.text = socialCredit.ToString();
    }

    public int GetSocialCredit()
    {
        return socialCredit;
    }
}

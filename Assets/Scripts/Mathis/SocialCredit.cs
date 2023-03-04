using UnityEngine;
using TMPro;

public class SocialCredit : MonoBehaviour
{
    public TextMeshProUGUI creditText;
    public int socialCredit = 255;

    public Camera mainCamera;
    public bool BREAK = false;
    private bool OVER = false;
    Color couleur = new Vector4(0, 255, 0,0);
    private int green = 255;
    private int red = 0;

    private void Start()
    {
        creditText.material.color = couleur;
        SetSocialCredit(socialCredit);

    }
    private void Update()
    {
        creditText.transform.LookAt(creditText.transform.position + mainCamera.transform.rotation * Vector3.back,mainCamera.transform.rotation * Vector3.up);
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

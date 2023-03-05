using UnityEngine;
using UnityEngine.SceneManagement;

public class SwappingScene : MonoBehaviour
{
    public string level1;
    public string level2;
    public string level3;
    public SocialCredit socialCredit;
    public int seuil = 50;

    // Update is called once per frame
    private void Start()
    {
       
    }
    void Update()
    {
        if (socialCredit.socialCredit >= 101) 
        {
            if (SceneManager.GetActiveScene().name != level1)
            {
                SceneManager.LoadScene(level1);
                
            }

        }
          else if (socialCredit.socialCredit <=seuil)
        {
            if (SceneManager.GetActiveScene().name != level2)
            {
                SceneManager.LoadScene(level2);
                
            }
        } else if(socialCredit.socialCredit <= 0)
        {
            if (SceneManager.GetActiveScene().name != level3)
            {
                SceneManager.LoadScene(level3);
                
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SwappingScene : MonoBehaviour
{
    public string levelToLoad;
    public SocialCredit socialCredit;
    public int seuil = 50;

    // Update is called once per frame
    void Update()
    {
        if (socialCredit.socialCredit <=seuil)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}

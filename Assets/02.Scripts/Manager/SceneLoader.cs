using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance { get; private set; }
    public FadeScreen fadeScreen;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void GoScene(string sceneName)
    {
        StartCoroutine(GoToNextSceneCoroutine(sceneName));
    }

    IEnumerator GoToNextSceneCoroutine(string nextScene)
    {
        fadeScreen.gameObject.SetActive(true);
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        SceneManager.LoadScene(nextScene);
    }

    public void GotoSceneAsync(string sceneName)
    {
        StartCoroutine(GoToNextSceneCoroutine(sceneName));
    }
    
}

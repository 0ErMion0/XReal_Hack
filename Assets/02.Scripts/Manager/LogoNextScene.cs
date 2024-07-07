using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogoNextScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(3f); // 3초 대기

        // another 씬으로 이동
        SceneManager.LoadScene("Chapter1");
    }
}
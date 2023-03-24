using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator anim;
    float transitionTime = 1f;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(Change(sceneName));
    }

    IEnumerator Change(string sceneName)
    {
        anim.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}

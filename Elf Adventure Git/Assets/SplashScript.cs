using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    
    public GameObject clip;

    void Start()
    {
        StartCoroutine(start());
    }

    IEnumerator start()
    {
        clip.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        clip.GetComponent<Animator>().gameObject.SetActive(false);
        SceneManager.LoadScene(1);

    }
}

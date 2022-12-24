using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform fader;

    void Start()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInCubic).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }
    public void Play()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0);
        LeanTween.scale(fader, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeInCubic).setOnComplete(() =>
        {
            SceneManager.LoadScene("Street");
        });
    }

    public void Quit()
    {
        Application.Quit();
    }
}

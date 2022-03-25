using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverMenu : MonoBehaviour
{
    private Animator anim;
    public TMP_InputField inputField;
    private HighscoreTable htb;
    private void Start()
    {
        inputField.characterLimit = 3;
        anim = GetComponent<Animator>();
        htb = FindObjectOfType<HighscoreTable>();
    }
    public void MainMenuReturn()
    {
        htb.scoreAdd((int)Score.score, inputField.text.ToUpper());
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        htb.scoreAdd((int)Score.score, inputField.text.ToUpper());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void playFadeIn()
    {
        anim.SetBool("FadeIn", true);
    }
}

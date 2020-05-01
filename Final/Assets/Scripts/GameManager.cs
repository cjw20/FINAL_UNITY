using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void EndGame()
    {
        Invoke("GameOver", 3f);
    }
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

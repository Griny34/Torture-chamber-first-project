using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{    
    public void StartGame()
    {
        int currentIndexScen = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentIndexScen + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartUı : MonoBehaviour
{

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}

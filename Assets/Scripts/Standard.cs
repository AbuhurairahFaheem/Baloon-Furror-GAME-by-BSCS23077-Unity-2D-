using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Standard : MonoBehaviour
{
  
    public void gotoBeginner()
    {
        SceneManager.LoadScene("Beginner");
    }

    public void gotoStandard()
    {
        SceneManager.LoadScene("Standard");
    }

    public void gotoProlevel()
    {
        SceneManager.LoadScene("ProLevel");
    }

    public void gotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

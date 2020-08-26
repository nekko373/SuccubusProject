using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    
    public void LoadNextLevel() {

        //call routine LoadLevel
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int index) {
    
        //play animation
        animator.SetTrigger("levelLoad");

        //wait fot seconds
        yield return new WaitForSeconds(2f);

        //load scene
        SceneManager.LoadScene(index);

    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLimit : MonoBehaviour
{
    [SerializeField] UnityEngine.GameObject heart_1;
    [SerializeField] UnityEngine.GameObject heart_2;
    [SerializeField] UnityEngine.GameObject heart_3;
    public GameOverScreen gameOverScreen;
    public AudioSource loseHeartSound;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.tag == "FoodBigTag" || other.gameObject.tag == "FoodSmallTag" || other.gameObject.tag == "FoodNormalTag")
        {
            loseHeartSound.Play();
            if (heart_1.activeInHierarchy)
            {
                heart_1.SetActive(false);
            }
            else if (heart_2.activeInHierarchy)
            {
                heart_2.SetActive(false);
            }
            else if (heart_3.activeInHierarchy)
            {
                heart_3.SetActive(false);
                gameOverScreen.Setup();
            }
        }
    }
}

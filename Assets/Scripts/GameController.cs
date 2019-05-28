using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [HideInInspector]
    public Texture tex;

    public GameObject photoShooter;

    private string sceneToLoadName = "Menu";

    [HideInInspector]
    public Menu menu;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void TakePhoto(Menu m)
    {
        Instantiate(photoShooter, Vector3.zero, Quaternion.identity);
        menu = m;
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    private void Update()
    {

    }

    public void GameOver()
    {
        GameObject.Find("SthBlack").GetComponent<Image>().color = new Color(0, 0, 0, GameObject.Find("SthBlack").GetComponent<Image>().color.a + Time.deltaTime * 5);
        if (GameObject.Find("SthBlack").GetComponent<Image>().color.a >= 1)
            SceneManager.LoadScene(0);
    }
}
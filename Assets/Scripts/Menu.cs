using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    //public RawImage customizationImage;
    public Renderer backgroundRenderer;

    [Space]
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject customizationPanel;
    public GameObject customizationBackgroundPanel;
    public GameObject customizationEnemyPanel;
    public GameObject customizationWeaponPanel;

    [Space]
    public GameObject enemiesObejct;
    public GameObject weaponsObject;


    [Space]
    [SerializeField]
    public MenuStack[] menuStacks;
    

    private void Start()
    {
        ShowMainPanel();
        LoadCustomization();
    }

    private void Update()
    {

    }

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void TakePhoto()
    {
        GameController.instance.TakePhoto(this);
    }

    public void SetPhoto(int i)
    {
        PlayerPrefs.SetInt("photo", i);
        PlayerPrefs.Save();
        if (i != -1) PhotoMaker.customPhoto = null;
        LoadCustomization();
    }

    public void Exit()
    {
        Application.Quit();
    }

    //private IEnumerator LoadImage()
    //{
    //    var url = "jar:file://" + Application.dataPath + "!/assets/custom.png";
    //    var www = new WWW(url);
    //    yield return www;

    //    var texture = www.texture;
    //    if (texture == null)
    //    {
    //        Debug.Log("Failed to load texture url:" + url);
    //        //texture = textures[1];
    //    }

    //    GameController.instance.tex = texture;
    //}

    public void LoadCustomization()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

        foreach (MenuStack stack in menuStacks)
        {
            stack.img.texture = stack.tex;
        }

        int photoNo = PlayerPrefs.GetInt("photo", 0);

        if (PhotoMaker.customPhoto == null && photoNo == -1)
            photoNo = 0;

        if (photoNo == -1) {
            backgroundRenderer.material.mainTexture = PhotoMaker.customPhoto;
            //customizationImage.texture = PhotoMaker.customPhoto;
            GameController.instance.tex = PhotoMaker.customPhoto;
            return;
        }

        backgroundRenderer.material.mainTexture = menuStacks[photoNo].tex;
        //customizationImage.texture = menuStacks[photoNo].tex;
        GameController.instance.tex = menuStacks[photoNo].tex;
        
    }

    public void ShowMainPanel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

        HidePanels();
        mainPanel.SetActive(true);
    }
    public void ShowSettingsPanel()
    {
        HidePanels();
        settingsPanel.SetActive(true);
    }
    public void ShowCustomizationPanel()
    {
        HidePanels();
        customizationPanel.SetActive(true);
        enemiesObejct.SetActive(true);
        weaponsObject.SetActive(true);
    }
    public void ShowCustomizationBackgroundPanel()
    {
        HidePanels();
        customizationBackgroundPanel.SetActive(true);
        enemiesObejct.SetActive(true);
        weaponsObject.SetActive(true);
    }
    public void ShowCustomizationEnemyPanel()
    {
        HidePanels();
        customizationEnemyPanel.SetActive(true);
        enemiesObejct.SetActive(true);
        weaponsObject.SetActive(true);
    }
    public void ShowCustomizationWeaponPanel()
    {
        HidePanels();
        customizationWeaponPanel.SetActive(true);
        enemiesObejct.SetActive(true);
        weaponsObject.SetActive(true);
    }


    private void HidePanels()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        customizationPanel.SetActive(false);
        customizationBackgroundPanel.SetActive(false);
        customizationEnemyPanel.SetActive(false);
        customizationWeaponPanel.SetActive(false);

        enemiesObejct.SetActive(false);
        weaponsObject.SetActive(false);
    }


    [System.Serializable]
    public class MenuStack
    {
        public RawImage img;
        public Texture tex;
    }
}

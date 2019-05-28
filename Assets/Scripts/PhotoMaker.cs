using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoMaker : MonoBehaviour {

    private GameObject cameraContainer;

    private WebCamTexture cam;
    public RawImage camView;
    public AspectRatioFitter fit;

    public GameObject errorText;
    public Button button;

    private bool cameraReady = false;

    public static Texture customPhoto;

    void Start()
    {
        if (WebCamTexture.devices.Length != 0)
            cam = new WebCamTexture(WebCamTexture.devices[0].name, Screen.width, Screen.height);

        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            if (!WebCamTexture.devices[i].isFrontFacing)
            {
                cam = new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
        }

        if (cam == null)
        {
            Debug.Log("I cant find camera");
            if (button != null) button.interactable = false;
            if (errorText != null) errorText.SetActive(true);
            return;
        }
        else
            cameraReady = true;

        if (errorText != null) errorText.SetActive(false);
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        cam.Play();
        camView.texture = cam;

    }

    private void Update()
    {
        if (cameraReady)
        {
            float ratio = (float)cam.width / (float)cam.height;
            fit.aspectRatio = ratio;

            float scaleY = cam.videoVerticallyMirrored ? -1.0f : 1.0f;
            camView.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
            int orient = -cam.videoRotationAngle;
            camView.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
        }
    }


    public void TakeaPicture()
    {
        if (cameraReady)
        {
            Texture2D tex = new Texture2D(cam.width, cam.height);
            tex.SetPixels(cam.GetPixels());
            tex.Apply();
            GameController.instance.tex = tex;
            customPhoto = tex;
            GameController.instance.menu.SetPhoto(-1);
            GameController.instance.menu.LoadCustomization();
        }
        Back();
    }
    
    public void Back()
    {
        if (cameraReady)
            cam.Stop();

        Destroy(gameObject);
    }


}

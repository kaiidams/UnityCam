using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCam : MonoBehaviour
{
    // https://www.youtube.com/watch?v=c6NXkZWXHnc&t=621s

    private bool camAvailable;
    private WebCamTexture webCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    private void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        webCam = new WebCamTexture(devices[0].name, 640, 480);
        webCam.Play();
        background.texture = webCam;
    }

    private void Update()
    {
        float ratio = (float)webCam.width / (float)webCam.height;
        fit.aspectRatio = ratio;
        float scaleY = webCam.videoVerticallyMirrored ? -1f : 1f;
        background.transform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -webCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0f, 0f, orient);
    }
}

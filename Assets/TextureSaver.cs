using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextureSaver : MonoBehaviour
{
    public RenderTexture[] rt;
    public string additionalFileText;

    public Camera cam;

    public Vector2 screenSize;

    public void Update()
    {
        /*
        for(var i = 0; i < rt.Length; i++)
        {
            SaveTexture(i);
        }
        */

        RenderCameraToFile();

    }
    // Use this for initialization oLD
    /*
    public void SaveTexture(int index)
    {
        byte[] bytes = toTexture2D(rt[index], index).EncodeToPNG();
        System.IO.File.WriteAllBytes("D:/Black5Pics/" + rt[index].name + additionalFileText + ".png", bytes);
    }
    Texture2D toTexture2D(RenderTexture rTex, int index)
    {
        Texture2D tex = new Texture2D(rt[index].width, rt[index].height, TextureFormat.ARGB32, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        Destroy(tex);//prevents memory leak
        return tex;
    }*/

    public void RenderCameraToFile()
    {
        Camera camera = cam.transform.GetComponent<Camera>();

        RenderTexture rt = new RenderTexture((int)screenSize.x, (int)screenSize.y, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
        RenderTexture oldRT = camera.targetTexture;
        camera.targetTexture = rt;
        camera.Render();
        camera.targetTexture = oldRT;

        RenderTexture.active = rt;
        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        RenderTexture.active = null;

        byte[] bytes = tex.EncodeToPNG();
        string path = "D:/Black5Pics/OculusGameImages/GameLevelPreviews/" + SceneManager.GetActiveScene().name + additionalFileText + ".png";
        System.IO.File.WriteAllBytes(path, bytes);
        Debug.Log("Saved to " + path);
    }
}

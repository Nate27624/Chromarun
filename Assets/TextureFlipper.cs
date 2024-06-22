using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TextureFlipper : MonoBehaviour
{
    public VideoPlayer videoClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.frameCount % 2) == 1)
        {
            FlipTexture((Texture2D)videoClip.texture);
        }
    }
    public static void FlipTexture(Texture2D texture)
    {
        int textureWidth = texture.width;
        int textureHeight = texture.height;

        Color32[] pixels = texture.GetPixels32();

        for (int y = 0; y < textureHeight; y++)
        {
            int yo = y * textureWidth;
            for (int il = yo, ir = yo + textureWidth - 1; il < ir; il++, ir--)
            {
                Color32 col = pixels[il];
                pixels[il] = pixels[ir];
                pixels[ir] = col;
            }
        }
        texture.SetPixels32(pixels);
        texture.Apply();
    }
}

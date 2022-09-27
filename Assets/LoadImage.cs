using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetBookSprite("https://tenfei04.cfp.cn/creative/vcg/veer/1600water/veer-147317368.jpg", transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetBookSprite(string url, Transform transform)
    {
        StartCoroutine(DownSprite(url, transform));
    }

    IEnumerator DownSprite(string url, Transform transform)
    {
        using (UnityWebRequest request = new UnityWebRequest(url))
        {
            //下载图像作为纹理使用
            DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
            request.downloadHandler = texDl;
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                int width = 218;
                int high = 300;
                Texture2D tex = new Texture2D(width, high);
                tex = texDl.texture;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                ;
                transform.GetComponent<Image>().sprite = sprite;
            }
        }
    }


}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPS : MonoBehaviour
{
    public Text fps;
    public Text avgFPS;
    private float count;
    private int fpsCount;
    private int fpsSum;

    void Start()
    {
        StartCoroutine("UpdateFPS");
    }

    IEnumerator UpdateFPS()
    {
        while (true)
        {
            ShowFPS();
            yield return new WaitForSeconds(1f);
        }
    }

    void ShowFPS()
    {
        count = 1f / Time.unscaledDeltaTime;
        fps.text = Mathf.RoundToInt(count).ToString() + " fps";
        fpsSum += Mathf.RoundToInt(count);
        fpsCount++;
        avgFPS.text = Mathf.RoundToInt((fpsSum / fpsCount)).ToString() + " fps";
    }

}

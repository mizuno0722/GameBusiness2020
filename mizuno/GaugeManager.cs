using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    [SerializeField]
    public Image redGauge;

    [SerializeField]
    private GameObject red;
    float amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator RedGaugeReduction(float _from, float _to, float _time)
    {
        float moveWidth = _to - _from;
        float time = _time;
        while (time > 0)
        {
            time -= Time.deltaTime;
            amount = _from + (time / _time) * moveWidth;
            RectTransform rect = red.GetComponent<RectTransform>();
            rect.localPosition = new Vector3((900 * amount - 450) * 0.99f, 0, 0);
            //float a = (900.0f * amount - 450.0f) * 0.99f;
            redGauge.fillAmount = amount;
            yield return null;
        }
        /*
        while (time > 0)
        {
            time -= Time.deltaTime;
            red.fillAmount = _from + (time / _time) * moveWidth;
            yield return null;
        }
        */
    }
    public float GetFillAmount()
    {
        return amount;
    }
    public void InitFillAmount()
    {
        amount = 0;
        RectTransform rect = red.GetComponent<RectTransform>();
        // float a = (900.0f * amount - 450.0f) * 0.99f;
        redGauge.fillAmount = amount;
        rect.localPosition = new Vector3((900 * amount - 450) * 0.99f, 0, 0);
    }
}

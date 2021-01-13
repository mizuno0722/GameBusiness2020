using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    [SerializeField]
    private Image red;
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
            red.fillAmount = _from + (time / _time) * moveWidth;
            yield return null;
        }

    }
    public float GetFillAmount()
    {
        return red.fillAmount;
    }
    public void InitFillAmount()
    {
        red.fillAmount = 0;
    }
}

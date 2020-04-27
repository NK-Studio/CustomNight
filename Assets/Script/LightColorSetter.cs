using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightColorSetter : MonoBehaviour, ColorSetterInterface
{
    [SerializeField]
    private Gradient gradient;

    private Light2D[] light2Ds;
    
    public void Refresh() => 
        light2Ds = GetComponentsInChildren<Light2D>();

    public void setColor(float time)
    {
        //그라디언트의 시작과 끝을 각각 0~1로 표현하여, time의 값에 알맞는 컬러값을 Light컬러에 적용합니다. 
        foreach (var light2D in light2Ds) 
            light2D.color = gradient.Evaluate(time);
    }
}

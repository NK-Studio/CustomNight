using UnityEngine;

public class MaterialColorSetter : MonoBehaviour, ColorSetterInterface
{
    [GradientUsage(true),SerializeField]
    private Gradient gradient;

    [SerializeField]
    private string ColorName;

    [SerializeField]
    private Material material;
    
    public void Refresh()
    { }

    public void setColor(float time) => 
        material.SetColor(ColorName,gradient.Evaluate(time));
}

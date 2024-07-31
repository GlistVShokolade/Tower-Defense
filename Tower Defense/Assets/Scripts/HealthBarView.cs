using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : HealthView
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Gradient _gradient;

    protected override void UpdateValue()
    {
        var value = Health.CurrentHealth / Health.MaxHealth;

        _bar.image.color = _gradient.Evaluate(value);
        _bar.value = value;
    }
}

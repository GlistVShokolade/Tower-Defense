using TMPro;
using UnityEngine;

public class HealthTextView : HealthView
{
    [SerializeField] private TextMeshProUGUI _value;

    protected override void UpdateValue()
    {
        _value.text = Health.CurrentHealth.ToString();
    }
}


using UnityEngine;
using UnityEngine.UI;

public class UiLifePlayer : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    public void Changelife(float hp, float maxHp)
    {
        lifeBar.fillAmount = hp / maxHp;
    }

}

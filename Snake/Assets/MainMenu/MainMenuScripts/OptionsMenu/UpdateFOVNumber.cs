using UnityEngine;
using UnityEngine.UI;

namespace RougeLike3D
{
    public class UpdateFOVNumber : MonoBehaviour
    {
        public Slider slider;

        public void UpdateText()
        {
            GetComponent<Text>().text = slider.value.ToString();
        }
    }
}
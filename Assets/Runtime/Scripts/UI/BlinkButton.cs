using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace InfinityRun.UI
{
    public class BlinkButton : MonoBehaviour
    {

        [SerializeField] float blinkTime;
        [SerializeField] float blinkFrequence;
        [SerializeField] Image buttonImage;
        [SerializeField] Color defaultColor;

        private void Start()
        {
            defaultColor = buttonImage.color;
            Blink();
        }

        private void Blink()
        {
            StartCoroutine(BlinkButtonDelayed());
        }

        IEnumerator BlinkButtonDelayed()
        {
            buttonImage.DOColor(defaultColor, blinkFrequence);
            yield return new WaitForSeconds(blinkTime);
            buttonImage.DOColor(Color.black, blinkFrequence);
            yield return new WaitForSeconds(blinkTime);
            Blink();
        }
    }
}



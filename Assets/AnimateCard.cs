using UnityEngine;
using System.Collections; // for IEnumerator
using DG.Tweening;

public class AnimateCard : MonoBehaviour
{
    

       // DOTween.Init(autoKillMode, useSafeMode, logBehaviour);

    void Start()
    {
            float randomScale = Random.Range(1.05f, 1.15f);
            float randomDuration = Random.Range(1f, 2f);

            Tween idle = 
             transform.DOScale(new Vector3(1.1f, 1.1f, 1f), 1f) 
                 .SetLoops(-1, LoopType.Yoyo)              
                 .SetEase(Ease.InOutSine);              
            // transform.DOScale(new Vector3(randomScale, randomScale, 1f), randomDuration)
            //          .SetLoops(1, LoopType.Yoyo)
            //          .SetEase(Ease.InOutSine);
            idle.Play();


    }    

    // Update is called once per frame
    void Update()
    {

    }
}

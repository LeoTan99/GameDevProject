// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using DG.Tweening;

// public class KrabbyPattyPoint : MonoBehaviour
// {
//     [SerializeField] private GameObject pileOfKrabbyPatty;
//     [SerializeField] private TextMeshProUGUI counter;
//     [SerializeField] private Vector2[] initialPos;
//     [SerializeField] private Quaternion[] initialRotation;
//     [SerializeField] private int krabbyPattyAmount;
//     void Start()
//     {
        
//         if (krabbyPattyAmount == 0) 
//             krabbyPattyAmount = 10; // you need to change this value based on the number of coins in the inspector
        
//         initialPos = new Vector2[krabbyPattyAmount];
//         initialRotation = new Quaternion[krabbyPattyAmount];
        
//         for (int i = 0; i < pileOfKrabbyPatty.transform.childCount; i++)
//         {
//             initialPos[i] = pileOfKrabbyPatty.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition;
//             initialRotation[i] = pileOfKrabbyPatty.transform.GetChild(i).GetComponent<RectTransform>().rotation;
//         }
//     }


//    public void CountKrabbyPatty()
//     {
//         pileOfKrabbyPatty.SetActive(true);
//         var delay = 0f;
        
//         for (int i = 0; i < pileOfKrabbyPatty.transform.childCount; i++)
//         {
//             pileOfKrabbyPatty.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

//             pileOfKrabbyPatty.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(400f, 840f), 0.8f)
//                 .SetDelay(delay + 0.5f).SetEase(Ease.InBack);
             

//             pileOfKrabbyPatty.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
//                 .SetEase(Ease.Flash);
            
            
//             pileOfKrabbyPatty.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);

//             delay += 0.1f;

//             counter.transform.parent.GetChild(0).transform.DOScale(1.1f, 0.1f).SetLoops(10,LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(1.2f);
//         }

//         StartCoroutine(CountDollars());
//     }
    
//     IEnumerator CountDollars()
//     {
//         yield return new WaitForSecondsRealtime(0.5f);
//         PlayerPrefs.SetInt("CountDollar",PlayerPrefs.GetInt("CountDollar") + 50 + PlayerPrefs.GetInt("BPrize"));
//         counter.text = PlayerPrefs.GetInt("CountDollar").ToString();
//         PlayerPrefs.SetInt("BPrize",0);
//     }
// }

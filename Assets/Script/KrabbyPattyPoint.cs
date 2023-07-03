using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class KrabbyPattyPoint : MonoBehaviour
{
    [SerializeField] private GameObject pileOfKrabbyPatty;
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private Vector2[] InitialPos;
    [SerializeField] private Quaternion[] InitialRotation;
    [SerializeField] private int krabbyPattyAmount;
    //0.5504991
    void Start()
    {
        
        if (krabbyPattyAmount == 0) 
            krabbyPattyAmount = 10; // you need to change this value based on the number of coins in the inspector
        
        InitialPos = new Vector2[krabbyPattyAmount];
        InitialRotation = new Quaternion[krabbyPattyAmount];
        
        for (int i = 0; i < pileOfKrabbyPatty.transform.childCount; i++)
        {
            // InitialPos[i] = pileOfKrabbyPatty.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition;
            // InitialRotation[i] = pileOfKrabbyPatty.transform.GetChild(i).GetComponent<RectTransform>().rotation;
            InitialPos[i] = pileOfKrabbyPatty.transform.GetChild(i).position;
            InitialRotation[i] = pileOfKrabbyPatty.transform.GetChild(i).rotation;
        }
    }

    private void Reset()
    {
        for (int i = 0; i < pileOfKrabbyPatty.transform.childCount; i++)
        {
            pileOfKrabbyPatty.transform.GetChild(i).position = InitialPos[i];
            pileOfKrabbyPatty.transform.GetChild(i).rotation = InitialRotation[i];
        }
    }

    public void RewardPileOfKrabbyPatty(int noKrabbyPatty)
    {
        Reset();

        var delay = 0f;
        pileOfKrabbyPatty.SetActive(true);

        for (int i = 0; i < pileOfKrabbyPatty.transform.childCount; i++)
        {
            pileOfKrabbyPatty.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);
            pileOfKrabbyPatty.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(-702f, 485f), 0.8f).SetDelay(delay + 0.5f).SetEase(Ease.OutBack);

            pileOfKrabbyPatty.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay + 0.1f).SetEase(Ease.OutBack);

            delay += 0.2f;
        }
    }


   public void CountKrabbyPatty()
    {
        pileOfKrabbyPatty.SetActive(true);
        var delay = 0f;
        
        for (int i = 0; i < pileOfKrabbyPatty.transform.childCount; i++)
        {
            pileOfKrabbyPatty.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pileOfKrabbyPatty.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(400f, 840f), 0.8f)
                .SetDelay(delay + 0.5f).SetEase(Ease.InBack);
             

            pileOfKrabbyPatty.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
                .SetEase(Ease.Flash);
            
            
            pileOfKrabbyPatty.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);

            delay += 0.1f;

            counter.transform.parent.GetChild(0).transform.DOScale(1.1f, 0.1f).SetLoops(10,LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(1.2f);
        }

        StartCoroutine(CountDollars());
    }
    
    IEnumerator CountDollars()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        PlayerPrefs.SetInt("CountDollar",PlayerPrefs.GetInt("CountDollar") + 50 + PlayerPrefs.GetInt("BPrize"));
        counter.text = PlayerPrefs.GetInt("CountDollar").ToString();
        PlayerPrefs.SetInt("BPrize",0);
    }
}

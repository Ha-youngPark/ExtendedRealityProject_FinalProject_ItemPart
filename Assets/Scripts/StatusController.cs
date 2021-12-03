using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField]
    public int coin = 0;
    public int heart = 3;
    public int currentHeart;
    public float currentMagnetTime; 
    public float currentGPTime;
    public float itemMoveSpeed = 1f;

    // UI에서 코인, 목숨을 표시하기 위해 필요한 이미지  
    [SerializeField]
    private Image[] images_Gauge;
    
    private const int HEART = 0, COIN = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHeart = heart;
    }

    // Update is called once per frame
    void Update()
    {
        // 코인 획득, 목숨 획득, 목숨 감소 UI 여기서 처리 필요.
        // 충돌 시 목숨 값 감소, 아이템 시간 감소는 여기서 함수 하나 만들어서 처리 하기.

        decreaseMagnetTime();
    }

    private void decreaseMagnetTime(){
        if(currentMagnetTime > 0){
            currentMagnetTime -= 1 * Time.deltaTime;
            Debug.Log("자석 시간: " + currentMagnetTime);
        }
    }
}

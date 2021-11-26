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
    public bool magnet = false;
    public bool gp = false;
    public int currentMagnetTime; 
    public int currentGPTime;

    private const int MAGNETTIME = 30, GPTIME = 30; // 자석 효과, 무적 지속 시간

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
        // 충돌 시 목숨 값 감소는 여기서 함수 하나 만들어서 처리 하기.

    }
}

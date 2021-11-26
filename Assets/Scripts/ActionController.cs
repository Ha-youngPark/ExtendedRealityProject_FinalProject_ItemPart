using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range; // 습득 가능한 최대 거리.
    
    private bool pickupActivated = false; //습득 가능할 시 true.

    private RaycastHit hitInfo; // 충돌체 정보 저장.
    
    // 아이템 레이어에만 반응하도록 레이어 마스크 설정.
    [SerializeField]
    private LayerMask layerMask;

    // 필요한 컴포넌트
    [SerializeField]
    private StatusController statusController;

    private const int HEART = 0, COIN = 1, MAGNET = 2, GP = 3;

    void Start() {
        statusController = FindObjectOfType<StatusController>();
    }


    // Update is called once per frame
    void Update()
    {
       CheckItem();
       CanPickUp();
    }


    private void CheckItem(){
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask)){
            if(hitInfo.transform.tag == "Item"){
                pickupActivated = true;
                CanPickUp();
            }
        }else{
            // 아이템이 획득 불가능 할 때
            pickupActivated = false;
        }
    }

    private void CanPickUp(){
        // 아이템 획득시 할 내용
        if(pickupActivated){
            if(hitInfo.transform != null){
                string hitItemName = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName;    
                switch(hitItemName){
                    case "Coin":
                        Destroy(hitInfo.transform.gameObject);
                        getCoin();
                        Debug.Log( hitItemName + " 획득"); 
                        break;
                    case "Heart":
                        Destroy(hitInfo.transform.gameObject);
                        getHeart();
                        Debug.Log( hitItemName + " 획득"); 
                        break;
                    case "Magnet":
                        Destroy(hitInfo.transform.gameObject);
                        getMagnet();
                        Debug.Log( hitItemName + " 획득"); 
                        break;
                    case "GP":
                        Destroy(hitInfo.transform.gameObject);
                        getGP();
                        Debug.Log( hitItemName + " 획득"); 
                        break;
                    default:
                        break;
                }

                
            }
        }
    }

    private void getCoin(){
        // 코인 획득 시 점수 증가
        statusController.coin++;
    }

    private void getHeart(){
        // 하트 획득 시 목숨 증가
        if(statusController.currentHeart < statusController.heart){
            statusController.currentHeart++;
        }else{
            return;
        }
        
    }

    private void getMagnet(){
        // 자석 획득 시 자석 효과
        statusController.magnet = true;
        // 플레이어와 아이템들에 리짓바디 붙이고 당김효과?



    }

    private void getGP(){
       // GP 획득 시 무적 효과
       statusController.gp = true;
       // 콜라이더를 비활성화 시키면 될듯.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;

    // 필요한 컴포넌트
    [SerializeField]
    private StatusController statusController;

    // Start is called before the first frame update
    void Start()
    {
        statusController = FindObjectOfType<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        //자석 유효 시
        if(statusController.currentMagnetTime > 0){
            // player.GetComponent<Rigidbody>().isKinematic = true;
            if(distance < 6){
                Vector3 dir = player.transform.position - transform.position;
                transform.Translate(dir.normalized * statusController.itemMoveSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.tag.CompareTo("Player") == 0){
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    bool stepped;
    int count;

    private void OnEnable()
    {
        count = 0;
        stepped = false;

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 2)
            {
                obstacles[i].SetActive(true);
                count++;
                //count = count + 1; count += 1; ++count;
            }
            else
                obstacles[i].SetActive(false);
        }
    }

    //충돌
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (!stepped && coll.transform.tag == "Player")
        {
            stepped = true;
            int newScore = count + 1;
            GameManager.instance.AddScore(newScore);
        }
    }
}


    // 발판으로서 필요한 동작을 담은 스크립트
    //   public GameObject[] obstacles; // 장애물 오브젝트들
    //   private bool stepped = false; // 플레이어 캐릭터가 밟았는가

    // 컴포넌트가 활성화될 때 마다 매번 실행되는 메서드
    //   private void OnEnable()
    //  {
    //       // 발판을 리셋하는 처리
    //}
    //
    //  private void OnCollisionEnter2D(Collision2D collision)
    //  {
    // 플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
    // }

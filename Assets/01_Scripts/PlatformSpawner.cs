using UnityEngine;
//오브젝트 폴링->미리 몇개의 오브젝트를 생성하고 재활용
public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platPrefab;
    int count = 3;

    //발판의 생성 간격->timer
    float spawnMin = 1.25f;
    float spawnMax = 2.25f;
    float spawnTime;

    //발판의 출발지
    float posX = 20;
    float yMin = -3.5f;
    float yMax = 1.5f;
    float posY;

    GameObject[] platforms;
    int currIndex = 0;

    Vector3 poolPosition = new Vector3(0, -25, 0);
    float lastSpawnTime;

    void Start()
    {
        platforms = new GameObject[count];
        //ctrl+k,d
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platPrefab, poolPosition, Quaternion.identity);
        }

        // 마지막 배치 시점 초기화
        lastSpawnTime = 0f;
        // 다은번 배치까지의 시간 간격을 0으로 초기화
        spawnTime = 0f;
    }


    void Update()
    {
        if (GameManager.instance.isGameover) return;

        //마지막 배치 시점 이후....
        if (Time.time >= lastSpawnTime + spawnTime)
        {
            lastSpawnTime = Time.time;
            spawnTime = Random.Range(spawnMin, spawnMax); // 1.25 ~ 2.25

            platforms[currIndex].SetActive(false);
            platforms[currIndex].SetActive(true);

            posY = Random.Range(yMin, yMax); // -3.5 ~ 1.5
            platforms[currIndex].transform.position = new Vector2(posX, posY);

            if (++currIndex == count) currIndex = 0;
        }
    }
}
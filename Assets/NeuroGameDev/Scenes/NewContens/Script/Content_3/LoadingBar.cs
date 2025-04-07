using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro 사용

public class LoadingBar : MonoBehaviour
{
    public Slider progressBar;
    public TMP_Text loadingText; // TextMeshPro 적용

    private float targetProgress = 0f;
    private float velocity = 0f;
    private float smoothTime = 0.5f;
    private bool isPaused = false;

    void Start()
    {
        StartCoroutine(LoadProgress());
    }

    void Update()
    {
        // 목표 값까지 부드럽게 변화 (SmoothDamp 사용)
        progressBar.value = Mathf.SmoothDamp(progressBar.value, targetProgress, ref velocity, smoothTime);
    }

    IEnumerator LoadProgress()
    {
        while (targetProgress < 1f)
        {
            if (isPaused) yield return null; // 멈춤 상태면 대기

            float delay = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(delay);

            // 10% 확률로 5% 후퇴 (더 열받게!)
            if (Random.value < 0.1f)
            {
                targetProgress = Mathf.Clamp(targetProgress - 0.05f, 0f, 1f);
                UpdateLoadingText("뒤로 가는 중...");
                continue;
            }

            // 99%에서 멈춤 (최대 10초 동안)
            if (targetProgress >= 0.99f)
            {
                UpdateLoadingText("거의 완료됨...");
                yield return new WaitForSeconds(Random.Range(5f, 10f)); // 최대 10초 멈춤
            }

            // 5% 확률로 오류 발생 메시지 출력
            if (Random.value < 0.05f)
            {
                UpdateLoadingText("오류 발생! 다시 시도 중...");
                yield return new WaitForSeconds(Random.Range(2f, 5f)); // 2~5초 대기 후 다시 진행
            }

            float increaseAmount = Random.Range(0.05f, 0.2f);
            targetProgress = Mathf.Clamp(targetProgress + increaseAmount, 0f, 1f);

            UpdateLoadingText();
        }

        UpdateLoadingText("완료!");
    }

    void UpdateLoadingText(string customMessage = "")
    {
        if (!string.IsNullOrEmpty(customMessage))
        {
            loadingText.text = customMessage;
            return;
        }

        if (targetProgress < 1f)
        {
            string[] loadingMessages = {
                "로딩 중...",
                "잠시만 기다려 주세요...",
                "데이터를 가져오는 중...",
                "이거 왜 이렇게 느려?",
                "거의 다 왔다고 했잖아?"
            };
            loadingText.text = loadingMessages[Random.Range(0, loadingMessages.Length)];
        }
        else
        {
            loadingText.text = "완료!";
        }
    }
}

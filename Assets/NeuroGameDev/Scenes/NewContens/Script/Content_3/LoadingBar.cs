using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro ���

public class LoadingBar : MonoBehaviour
{
    public Slider progressBar;
    public TMP_Text loadingText; // TextMeshPro ����

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
        // ��ǥ ������ �ε巴�� ��ȭ (SmoothDamp ���)
        progressBar.value = Mathf.SmoothDamp(progressBar.value, targetProgress, ref velocity, smoothTime);
    }

    IEnumerator LoadProgress()
    {
        while (targetProgress < 1f)
        {
            if (isPaused) yield return null; // ���� ���¸� ���

            float delay = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(delay);

            // 10% Ȯ���� 5% ���� (�� ���ް�!)
            if (Random.value < 0.1f)
            {
                targetProgress = Mathf.Clamp(targetProgress - 0.05f, 0f, 1f);
                UpdateLoadingText("�ڷ� ���� ��...");
                continue;
            }

            // 99%���� ���� (�ִ� 10�� ����)
            if (targetProgress >= 0.99f)
            {
                UpdateLoadingText("���� �Ϸ��...");
                yield return new WaitForSeconds(Random.Range(5f, 10f)); // �ִ� 10�� ����
            }

            // 5% Ȯ���� ���� �߻� �޽��� ���
            if (Random.value < 0.05f)
            {
                UpdateLoadingText("���� �߻�! �ٽ� �õ� ��...");
                yield return new WaitForSeconds(Random.Range(2f, 5f)); // 2~5�� ��� �� �ٽ� ����
            }

            float increaseAmount = Random.Range(0.05f, 0.2f);
            targetProgress = Mathf.Clamp(targetProgress + increaseAmount, 0f, 1f);

            UpdateLoadingText();
        }

        UpdateLoadingText("�Ϸ�!");
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
                "�ε� ��...",
                "��ø� ��ٷ� �ּ���...",
                "�����͸� �������� ��...",
                "�̰� �� �̷��� ����?",
                "���� �� �Դٰ� ���ݾ�?"
            };
            loadingText.text = loadingMessages[Random.Range(0, loadingMessages.Length)];
        }
        else
        {
            loadingText.text = "�Ϸ�!";
        }
    }
}

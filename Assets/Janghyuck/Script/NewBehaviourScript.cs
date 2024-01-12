using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider volumeSlider;

    void Start()
    {
        // AudioSource �� Slider ������Ʈ�� ���� ������ �����ɴϴ�.
        musicSource = GetComponent<AudioSource>();
        volumeSlider = GetComponent<Slider>();

        // �ʱ� ���� ����
        volumeSlider.value = musicSource.volume;

        // Slider�� ���� ����� �� ȣ��Ǵ� �̺�Ʈ�� ����մϴ�.
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    void UpdateVolume(float volume)
    {
        // Slider�� ���� ���� AudioSource�� ������ �����մϴ�.
        musicSource.volume = volume;
    }
}

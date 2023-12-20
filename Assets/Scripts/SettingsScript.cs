using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public DataScript data;

    void Start()
    {
        var toggle = GameObject.Find("1Toggle").GetComponent<Toggle>();
        toggle.isOn = data.OptAudioEnRu;
        toggle.onValueChanged.AddListener(b => data.OptAudioEnRu = b);
        var button4Text = GameObject.Find("4Button").GetComponentInChildren<Text>();
        var dropdown = GameObject.Find("2Dropdown").GetComponent<Dropdown>();
        dropdown.value = data.OptTopicName;
        dropdown.onValueChanged.AddListener(v =>
        {
            data.OptTopicName = v;
            button4Text.text = data.Topic(0);
        });
        data.GetWords(0);
        var text3 = GameObject.Find("3Text").GetComponent<Text>();
        var slider = GameObject.Find("3Slider").GetComponent<Slider>();
        slider.onValueChanged.AddListener(v =>
        {
            data.OptVolume = (int)v;
            text3.text = $" ������� ��������� ({(int)v}):";
        });
        slider.value = data.OptVolume;
        GameObject.Find("3Button").GetComponent<Button>()
        .onClick.AddListener(() =>
        {
            button4Text.text = data.Word(0);
            data.PlayAudio(0);
        });
        var text4 = GameObject.Find("4Text").GetComponent<Text>();
        var button4 = GameObject.Find("4Button").GetComponent<Button>();
        slider = GameObject.Find("4Slider1").GetComponent<Slider>();
        slider.onValueChanged.AddListener(v =>
        {
            data.OptMainButtonFontSize = (int)v;
            button4Text.fontSize = (int)v;
            text4.text = Opt4Comment();
        });
        slider.value = data.OptMainButtonFontSize;
        slider = GameObject.Find("4Slider2").GetComponent<Slider>();
        slider.onValueChanged.AddListener(v =>
        {
            data.OptMainButtonHeight = (int)v;
            data.SetHeight(button4, (int)v);
            text4.text = Opt4Comment();
        });
        slider.value = data.OptMainButtonHeight;
        button4Text.text = data.Topic(0);
        button4.onClick.AddListener(() =>
        {
            if (button4Text.text == data.Word(0))
                button4Text.text = data.Topic(0);
            else
                button4Text.text = data.Word(0);
        });

        var text5 = GameObject.Find("5Text").GetComponent<Text>();
        var toggle5 = GameObject.Find("5Toggle").GetComponent<Toggle>();
        var toggle5Text = toggle5.GetComponentInChildren<Text>();
        slider = GameObject.Find("5Slider1").GetComponent<Slider>();
        slider.onValueChanged.AddListener(v =>
        {
            data.OptMainToggleFontSize = (int)v;
            toggle5Text.fontSize = (int)v;
            text5.text = Opt5Comment();
            Debug.Log(data.OptMainToggleFontSize);
        });
        slider.value = data.OptMainToggleFontSize;
        slider = GameObject.Find("5Slider2").GetComponent<Slider>();
        slider.onValueChanged.AddListener(v =>
        {
            data.OptMainToggleHeight = (int)v;
            data.SetHeight(toggle5, (int)v);
            text5.text = Opt5Comment();
        });
        slider.value = data.OptMainToggleHeight;

        toggle5Text.text = data.Topic(0);
    }
    string Opt4Comment() =>
        $"  ����� ({data.OptMainButtonFontSize}) � ������ "
        + $"({data.OptMainButtonHeight})\n  ������ � �������:";

    string Opt5Comment() =>
        $"  ����� ({data.OptMainToggleFontSize}) � ������ "
        + $"({data.OptMainToggleHeight})\n  �������������� � �������:";

}

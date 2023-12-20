using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsMenuScript : MenuScript
{
    public DataScript data;
    public Canvas dialogCanvas;
    DialogScript dialog;
    protected new void Start()
    {
        InitMenu(new string[] { "Удалить первый результат",
            "Удалить все результаты" }, MenuHandler);
        dialog = dialogCanvas.GetComponent<DialogScript>();
        base.Start();
    }
    void MenuHandler(int n)
    {
        if (n == 0)
        {
            var content = GameObject.Find("Content").transform;
            if (content.childCount > 0) {
                Destroy(content.GetChild(0).gameObject);
                data.RemoveFristResult();
            }
            if (content.childCount > 1)
                es.SetSelectedGameObject(content.GetChild(1).gameObject);
            else
                DisableAll();
        }
        else if (n == 1)
            dialog.ShowDialog("Подтверждение",
            "Удалить всю информацию\nо результатах тестирования?",
            new string[] { "Да", "Нет" }, DeleteAllHandler, 1, 1);
    }

    void DeleteAllHandler(int n)
    {
        if (n == 1)
            return;
        var content = GameObject.Find("Content").transform;
        for (int i = 0; i < content.childCount; i++)
            Destroy(content.GetChild(i).gameObject);
        DisableAll();
        data.RemoveAllResults();
    }
    void DisableAll()
    {
        es.SetSelectedGameObject(GameObject.Find("HLButton"));
        DisableMenuItem(0);
        DisableMenuItem(1);
    }
}

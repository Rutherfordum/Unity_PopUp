# Простой Popup для вашего приложения на Unity
![](https://github.com/Rutherfordum/Unity_PopUp/blob/main/Demo/2023-12-07%2017-38-34%20-%20Trim.gif)

## Описание
Пример простого реализации popup в игровом движке Unity, можно использовать в своих проектах свободно, из функционала доступен popup с одной кнопкой, либо же с двумя. Легко и просто интегрирвать в свои проекты.

## Поддерживаемые платформы
Абсолютнос все платформы которые поддерживает Unity 

## Особенности пакета
Popup использется совместно с расширяющимся ObjectPool патерном, так что вам не нужно переживать если у вас просиходит вызов более одного окна Popup, все они будут висеть пока вы не выполните действие подтверждения либо отмены. Сам префаб (окно popup) оптимизирован и использует 2D Sprite пакет для запекания UI текстур в один атлас для отрисовки в один проход.  

## Как использовать ?
### 1. Импорт пакета
    1.1 Клонируте этот репозиторий себе 
    1.2 Откройте в своем проекте менеджер пакетов Unity, выберите добавить пакет с диска, в открывшемся окне выберите /Unity_PopUp/Packages/PopupPackage/package.json
    1.3 Тепрь вы можете скопировать, из добавленого пакета, префаб PopupPrefab в свою папку Assets, вы можете свободно кастомизировать его  
### 2. Код
2.1 Добавьте пространство имен в ваш код:

```C#
using Services.PopUp;
using Services.PopUp.View;
```

2.2 Создайте переменную для ссылки на префаб, который добавите в инспекторе Unity, в методе Awake создайте класс PopUpService:

```C#
public PopUpView PopUpViewPrefab;
private PopUpService _popUpService;

private void Awake()
{
    _popUpService = new PopUpService(PopUpViewPrefab);
}
```

2.3 Чтобы вызвать popup достаточно написать:
```C#
// Выводит popup с одной кнопкой ответа
// Укажите Заголовок и Текст сообщения, для обработки ответа используется Action
 _popUpService.Show("Title example text", "Body example text", OnApproveAction);

// Выводит popup с двумя кнопками ответа
// Укажите Заголовок и Текст сообщения, для обработки ответа используется Action
_popUpService.Show("Title example text", "Body example text", OnApproveAction, OnCancelAction);
```

### 3. Весь код 
```C#
using Services.PopUp;
using Services.PopUp.View;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExamplePopUp : MonoBehaviour
{
    public PopUpView PopUpViewPrefab;

    private PopUpService _popUpService;
    private int _countPopUps = 5;

    private void Awake()
    {
        _popUpService = new PopUpService(PopUpViewPrefab);
    }

    public void ShowPopUpWithOneButton()
    {
        _popUpService.Show("Title example text", "Body example text", OnApproveAction);
    }

    public void ShowPopUpWithTwoButton()
    {
        _popUpService.Show("Title example text", "Body example text", OnApproveAction, OnCancelAction);
    }

    private void OnApproveAction()
    {
        int number = Random.Range(0, 1000);
        Debug.Log($"Is clicked Approved {number}");
    }

    private void OnCancelAction()
    {
        int number = Random.Range(0, 1000);
        Debug.Log($"Is clicked cancel {number}");
    }
}
```



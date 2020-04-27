using UnityEngine;

public interface ColorSetterInterface
{
    /// <summary>
    /// 새로고침을 처리할 함수
    /// </summary>
    void Refresh();

    /// <summary>
    /// 컬러의 값을 time으로 하여금 0~1로 처리함
    /// </summary>
    /// <param name="time"></param>
    void setColor(float time);
}

public class LightColorController : MonoBehaviour
{
    //외부에서 시간에 대한 변수를 컨드롤하기 위한 변수입니다.
    [SerializeField,Range(0,1)]
    private float time;

    //time의 값이 바뀌어 preTime != time이 되었을 때, 변경사항을 처리할 변수입니다. 
    public float TimeValue { get; private set; }
    
    //컬러에 대한 인터페이스를 수록한 세터들입니다.
    private ColorSetterInterface[] setters;

    /// <summary>
    /// 자식으로 있는 세터들을 전부 새로고침 해줍니다.
    /// </summary>
    public void RefreshSetters()
    {
        setters = GetComponentsInChildren<ColorSetterInterface>();
        foreach (var setter in setters) 
            setter.Refresh();
    }

    /// <summary>
    /// 세터들의 컬러를 시간 변수를 기반하여 업데이트해줍니다.
    /// </summary>
    public void notifyTimeChangeToSetters()
    {
        TimeValue = time;
        foreach (var setter in setters) 
            setter.setColor(time);
    }

    private void OnEnable()
    {
        //초기화
        time = 0;
        
        //새로고침
        RefreshSetters();
        
        //값 교체
        notifyTimeChangeToSetters();
    }

    private void OnDisable()
    {
        //초기화
        time = 0f;
        
        //값 교체
        notifyTimeChangeToSetters();
    }

    private bool Cha;
    
    private void Update()
    {
        //time의 값이 변경되었을 때, 변경 사항을 갱신합니다.
        if(TimeValue != time)
            notifyTimeChangeToSetters();

        if (Input.GetKeyDown(KeyCode.Space))
            Cha = !Cha;

        time = Mathf.MoveTowards(time, Cha == false ? 0f : 1f, Time.deltaTime * 0.45f);
    }
    
}

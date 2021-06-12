//using System;

namespace Field
{
    public class Armor
    {
        //변수(Variable)
        public string name;

        //상수(constant) : 정적 접근
        public const int m_defence = 1000;

        //읽기 전용 필드(ReadOnly)
        public static readonly string _Color = "Black";
    }

    public class Man
    {
        //이름을 저장할 공간 =  필드
        private string userName;

        //이름을 외부에서 사용 : 속성(Property)
        public string _Name // 속성명으로 지정, 메인 이름에 속성 부여시 사용
        {
            get
            {
                return userName; // 필드명
            }
            set
            {
                userName = value; // 필드명
            }
        }
    }
    //사용자가 정한 필드의 속성을 사용하기 위해서는 필드의 이름 그대로 속성에서 리턴하여 사용

}

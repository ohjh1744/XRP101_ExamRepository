# 2번 문제

주어진 프로젝트 내에서 제공된 스크립트(클래스)는 다음의 책임을 가진다
- PlayerStatus : 플레이어 캐릭터가 가지는 기본 능력치를 보관하고, 객체 생성 시 초기화한다
- PlayerMovement : 유저의 입력을 받고 플레이어 캐릭터를 이동시킨다.

프로젝트에는 현재 2가지 문제가 있다.
- 유니티 에디터에서 Run 실행 시 윈도우에서는 Stack Overflow가 발생하고, MacOS의 유니티에서는 에디터가 강제종료된다.
- 플레이어 캐릭터가 X, Z축의 입력을 동시입력 받아서 대각선으로 이동 시 하나의 축 기준으로 움직일 때 보다 약 1.414배 빠르다.

두 가지 문제가 발생한 원인과 해결 방법을 모두 서술하시오.

## 답안
- 1) Stack Overflow가 발생하는 이유는 MoveSpeed 프로퍼티 내부에서 get set을 MoveSpeed 본인을 또 지정하여 사용이 되어,
  반복해서 호출되어 발생한다.
- 해결방안: 프로퍼티와 연결해줄 private 변수를 따로 만들어, get 내부에 private 변수를 return 해주고, private set{}으로 수정.
           Init()에서 private 변수값으로 대체.
- 2) 대각선 이동시 1.414배 정도 빠른 이유는 (1:1: 루트2) 에따라서 대각선 벡터는 크기가 루트2로 좀더 크기 때문이다.
- 해결방안:  transform.Translate(_status.MoveSpeed * Time.deltaTime * direction.normalized);
            normalized를 통해 방향벡터로 바꾸어 사용한다면 이동크기는 오로지 MoveSpeed에 의해 결정된다.
     
# 4번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Player
- 상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
- Idle상태에서 Q를 누르면 Attack 상태로 진입한다
  - 진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다
- 상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

### 2. NormalMonster
- 데미지를 입을 수 있는 몬스터

### 3. ShieldeMonster
- 데미지를 입지 않는 몬스터

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 문제 1: 공격상태로 전환되고나서, Attack함수 내부 foreach문에서 IDamagable이 없는 Monster의 경우에는 문제 발생.
- 해결방안: IDamagable이 있는 몬스터들만 TakeHit하도록 조건문을 넣어 수정.
- 문제 2: StateAttack에서 공격이 끝나고나서 Exit함수를 호출함으로서, Exit와 ChangeState가 서로 호출되어 stack문제 발생.
- 해결방안: DelayRoutine에서 Exit를 제거하고, bool변수를 하나만들어, enter할때 true로 초기화하고,
          공격이 끝나면 false로 바꾸어 OnUpdate쪽에서 그 변수가 false가 된다면 ChangeState(StateType.Idle)하도록 수정.
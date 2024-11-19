# 3번 문제

주어진 프로젝트 는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Turret
- Trigger 범위 내로 플레이어가 들어왔을 때 1.5초에 한번씩 플레이어를 바라보면서 총알을 발사한다
- Trigger 범위 바깥으로 플레이어가 나가면 발사를 중지한다.
- 오브젝트 풀을 사용해 총알을 관리한다.

### 2. Bullet :
- 20만큼의 힘으로 전방을 향해 발사된다
- 발사 후 5초 경과 시 비활성화 처리된다
- 플레이어를 가격했을 경우 2의 데미지를 준다

### 3. Player
- 총알과 충돌했을 때, 데미지를 입는다
- 체력이 0 이하가 될 경우 효과음을 재생하며 비활성화된다.
- 플레이어의 이동은 씬 뷰를 사용해 이동하도록 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 문제 1 : Player가 Turret 범위로 들어가도 Turret이 공격하지 않는다.
          이유로는 Player에 Trigger 체크가 안되어있었고, 또한 collider나 trigger함수의 경우 둘중 하나는 rigidbody가 필요한데 rigidbody 컴포넌트 존재x.
- 해결방안: Player body의 collider에 trigger 체크하고, body쪽에 Rigidbody 컴포넌트 추가한뒤 Use Gravity는 false.
- 문제 2 : Bullet에 Rigidbody 컴포넌트가 없어 addforce관련 에러 발생.
- 해결방안: Bullet 프리펩에 Rigidbody 컴포넌트 추가.
- 문제 3: BulletController쪽에서 triggerEnter 함수내부에서  other.GetComponent<PlayerController>().TakeHit(_damageValue);
        쪽 NullReference오류 발생. 그이유는, Player와 Body 둘다 Player Tag가 달려있는데, Body에는 playerController이 없음.
        또한, Bullet의 Collider가 Body에 달려있어 triggerEnter함수 작동 관련 문제 발생.
- 해결방안: Body가 감지되면 GetComponentInparent함수를 통해 Player의 PlayerController을 가지고 오도록 수정. 또한 Bullet의 Body collider를 제거하고, 스크립트가 달려있는 부모 오브젝트쪽에 Collider를 단뒤 
           trigger 추가.
- 문제 4: Bullet이 생성될때 속도가 일정하지 않음.
- 해결방안: BullectController의 enable에서 velocity를 0으로 초기화.
- 문제 5 : Player가 Turret 공격범위 내부에서 나갈때와 player가 죽었을때 (ActiveSelf == false)Turret이 계속 공격하는 문제 발생.
- 해결방안: TurretController에서 OnTriggerExit함수를 이용해 Player가 나가면 코루틴을 중지시켜 해결. 또한 Player를 GameObject로 변수로 참조하여
           죽어서 false된다면 코루틴 중지시켜 해결.
- 문제 6: Player가 죽을때 바로 False되어 Sound Play가 묻히는 문제 발생.
- 해결방안 :DIe함수를 코루틴으로 수정하여 Sound가 들리고 몇 초 뒤에 False되도록 수정.
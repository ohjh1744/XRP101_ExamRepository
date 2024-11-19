# 6번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### FPS 조작 구현
- 실행 시, 마우스 커서가 비활성화되며 마우스 회전으로 플레이어의 시야가 회전한다.
- 현재 바라보고 있는 방향 기준으로 W, A, S, D로 전, 후, 좌, 우 이동을 수행한다
- 마우스 좌클릭 시, 시야 정면 방향으로 레이를 발사하고 레이캐스트에 검출된 적의 이름을 콘솔에 로그로 출력한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안

- 문제 1: 카메라가 Player의 muzzlePoint에 위치하지 않아 따라오지 않는 문제 발생.
- 해결 방안: CameraController의 SetTransform()에서  transform.SetPositionAndRotation(_followTarget.position,_followTarget.rotation);
            로 수정.
- 문제 2: Gun의 Target Layer가 Enemy로 안되어 있어 Ray에 Enemy가 걸리지 않는 문제 발생.
- 해결 방안: 인스펙터창에서 Gun의 Target Layer를 Enemy로 지정.
- 문제 3: Gun의 Fire함수 내부에서 ray 방향을 Vector3.forward로 해서, ray방향이 바뀌지 않는 문제 발생.
- 해결 방안: Vector3.forward를 origin.forward로 수정하여 가리키고 있는방향으로 ray가향하도록함.

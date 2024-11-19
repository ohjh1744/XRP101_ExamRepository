# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다
- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다
- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안
- 원인 1: CubeController의 SetPosition은 object의 position을 Setpoint의 해당 위치로 이동시키는것인데,
         CubeManager에서 Awake에서 인스턴스가 존재하지도 않는 _cubeController를 이동시키려함으로서 오류가 발생. 
- 원인 2: SetCubePosition에서 object가 이동해야하는 위치 값이 존재해야하는데, SetCUbePosition함수에서 
         결과적으로 CubeController의 SetPoint의 값이 따로 지정이 되지않는 상태로 원하는 위치로 이동못하는 문제 발생.
- 해결방안: cubecontroller의 프로퍼티에서 set의 private한정자를 제거하고, CubeManager에서 Awake함수를 제거 한뒤
           Start함수에서 CreateCube() - SetCubePosition 순으로 호출되도록 한다.
           그리고, SetCubePosition에서 _cubeController의 Setpoint 값을 _cubeSetPoint로 지정해준다.